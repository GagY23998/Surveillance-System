using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using DAL.Services;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Logging;
using reactApp.Hubs;
using System;

namespace reactApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors();
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(config => config.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Surveillance;Trusted_Connection=True;"));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AppCore.Helper.AppMapper());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mappingConfig.CreateMapper());

            //services.AddAutoMapper(typeof(Startup));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserInterface, UserService>();
            services.AddScoped<ILogInterface, LogService>();
            services.AddScoped<ILabelService, LabelService>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddAuthentication(o=>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x=>
            {
               
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.FromSeconds(10)
                };
            });
            services.AddAuthorization(config =>
            {
                config.AddPolicy("Bearer",new AuthorizationPolicyBuilder()
                                             .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme).RequireRole("Admin","User")
                                             .RequireAuthenticatedUser()
                                             .Build());
            });
            services.AddSignalR();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                IdentityModelEventSource.ShowPII = true;
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

             app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ArchiveHub>("/archivehub");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller}/{action=Index}/{id?}");
            });
          

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1");
            });
        }
    }
}
