using AppCore.Models;
using AppCore.Requests;
using AutoMapper;
using DAL.Data;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DAL.Services
{
    public class UserService: CRUDService<User,UserDTO,UserInsertRequest,UserInsertRequest, UserSearchRequest>,IUserInterface
    {
        public UserService(AppDbContext _context,IMapper mapper):base(_context,mapper)
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
        public override UserDTO Insert(UserInsertRequest InsertRequest)
        {
            if (InsertRequest.Password != InsertRequest.PasswordConfirmation) return null;
            var newEntity = MyMapper.Map<User>(InsertRequest);
            newEntity.PasswordSalt = GenerateSalt();
            newEntity.PasswordHash = GenerateHash(newEntity.PasswordSalt, InsertRequest.Password);
            _context.Add(newEntity);
            _context.SaveChanges();

            foreach (var item in InsertRequest.Roles)
            {
                _context.UserRoles.Add(new UserRole { RoleId = item.Id, UserId = newEntity.Id });

            }

            _context.SaveChanges();
            return MyMapper.Map<UserDTO>(newEntity);
        }

        public override UserDTO Update(int objectId, UserInsertRequest updateRequest)
        {
            if (updateRequest.Password != updateRequest.PasswordConfirmation) return null;

            User user = _context.Users.Find(objectId);
            if (user == null) return null;
            _context.Entry<User>(user).State = EntityState.Detached;

            var updateEntity = MyMapper.Map<User>(updateRequest);
            user = MyMapper.Map<User>(updateEntity);
            user.PasswordSalt = GenerateSalt();
            user.PasswordHash = GenerateHash(updateEntity.PasswordSalt, updateRequest.Password);
            user.Id = objectId;
            _context.Users.Update(user);
            _context.SaveChanges();
            if (updateRequest.Roles.Count != 0)
            {
                var userRoles = _context.UserRoles.Where(_ => _.UserId == updateEntity.Id).ToList();
                _context.UserRoles.RemoveRange(userRoles);
                _context.SaveChanges();
                foreach (var role in updateRequest.Roles)
                {
                    _context.UserRoles.Add(new UserRole { UserId = updateEntity.Id, RoleId = role.Id });
                    _context.SaveChanges();
                }
            }
            return MyMapper.Map<UserDTO>(updateEntity);
        }


        public UserDTO Authenticate(string username, string password)
        {
            var user = _context.Users.Include("UserRoles.Role").FirstOrDefault(_ => _.UserName == username);
            if (user != null)
            {
                var passwordHash = GenerateHash(user.PasswordSalt, password);
                if (passwordHash == user.PasswordHash) return MyMapper.Map<UserDTO>(user);
            }
            return null;
        }
    }
}
