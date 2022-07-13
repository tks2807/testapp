using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using TestApp.Context;
using TestApp.EFCore;


namespace TestApp.Repository
{
    public class DbRepository
    {
        private DataContext _context;
  

        public DbRepository(DataContext context) 
        {
            _context = context;
        }

        public List<User> GetUsers()
        {
            var users = _context.Users.Include(z => z.UserPermissions).ThenInclude(y => y.Permissions).ToList();   
            return users;
            
        }  

        public List<User> GetUserById(int id)
        {
            var user = _context.Users.Include(z => z.UserPermissions).ThenInclude(y => y.Permissions).Where(x => x.Id == id).ToList();
            return user;
        }

        public void SaveUser(User user)
        {
            var usr = new User
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Login = user.Login,
            };

            _context.Users.Add(usr);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            User usr = new User();
            usr = _context.Users.Where(x => x.Id == user.Id).FirstOrDefault();
            if (usr != null)
            {
                usr.Name = user.Name;
                usr.Email = user.Email;
                usr.Login = user.Login;
            }
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Where(x => x.Id.Equals(id)).FirstOrDefault();
            if(user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public void AssignPermission(UserPermission userPermission)
        {
            var up = new UserPermission
            {
                UserId = userPermission.UserId,
                PermissionId = userPermission.PermissionId,
            };

            _context.UserPermissions.Add(up);
            _context.SaveChanges();
        }

        public void RemovePermission(int uid, int pid)
        {
            var user = _context.UserPermissions.Where(x => x.UserId.Equals(uid)).Where(y => y.PermissionId.Equals(pid)).FirstOrDefault();
            if (user != null)
            {
                _context.UserPermissions.Remove(user);
                _context.SaveChanges();
            }
        }

    }
}