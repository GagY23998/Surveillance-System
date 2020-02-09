using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace reactApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ColumnOptions columnOptions = new ColumnOptions();
            columnOptions.AdditionalColumns = new Collection<SqlColumn>();
            columnOptions.AdditionalColumns.Add(new SqlColumn { ColumnName = "UserId", DataType = System.Data.SqlDbType.Int, AllowNull = false });
            columnOptions.AdditionalColumns.Add(new SqlColumn { ColumnName = "Entered", DataType = System.Data.SqlDbType.Bit, AllowNull = false });
            columnOptions.AdditionalColumns.Add(new SqlColumn { ColumnName = "Left", DataType = System.Data.SqlDbType.Bit, AllowNull = false });

            Log.Logger = new LoggerConfiguration().WriteTo.MSSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;","Log",
                                                                       columnOptions: columnOptions)
                                                                       .CreateLogger();
            try
            {
                Log.Information("What's up");
            }catch(Exception e)
            {
                
            }
            finally
            {
                Log.CloseAndFlush();
            }


            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseSerilog()
                .UseStartup<Startup>();
    }
}
