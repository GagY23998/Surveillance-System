using AppCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DAL.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public AppDbContext(DbContextOptions options):base(options)
        {

        }

        public static string GenerateSalt()
        {
            var buffer = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buffer);
            return Convert.ToBase64String(buffer);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var adminSalt = GenerateSalt();

            modelBuilder.Entity<UserRole>().HasKey(key => new {key.UserId,key.RoleId });
            modelBuilder.Entity<User>().HasData(new User
            {   Id = 1,
                UserName = "admin",
                PasswordSalt = adminSalt,
                PasswordHash = GenerateHash(adminSalt, "admin"),
                FirstName="admin",
                LastName="admin"
            });
            //modelBuilder.Entity<Log>().HasData(new Log { Id=1,UserId = 1, TimeStamp = DateTime.Now, Entered = true, });
            //modelBuilder.Entity<Log>().HasData(new Log { Id=2,UserId = 2, TimeStamp = DateTime.Now, Left = true, });
            //modelBuilder.Entity<Log>().HasData(new Log { Id=3,UserId = 1, TimeStamp = DateTime.Now, Left = true, });
            //modelBuilder.Entity<Log>().HasData(new Log { Id=4,UserId = 1, TimeStamp = DateTime.Now, Left = true, });
            //modelBuilder.Entity<Log>().HasData(new Log { Id=5,UserId = 2, TimeStamp = DateTime.Now, Entered = true, });
            //modelBuilder.Entity<Log>().HasData(new Log { Id=6,UserId = 2, TimeStamp = DateTime.Now, Entered = true, });
            modelBuilder.Entity<Role>().HasData(new Role { Id=1, Name = "Admin" }, new Role { Id=2, Name = "User" });
            modelBuilder.Entity<UserRole>().HasData(new UserRole { UserId = 1, RoleId = 1 });
        }
    }
}
