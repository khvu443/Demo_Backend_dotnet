using BusinessObject.Context;
using BusinessObject.Model;
using BusinessObject.Model.Authenticate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UserDAO
{
    public class UserDAO
    {
        public User GetUser(UserLogin login)
        {
            var user = new User();
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    user = ctx.Users.FirstOrDefault(o => o.UserName == login.UserName && o.Password == login.Password);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

        public void CreateUser(User user)
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    ctx.Users.Add(user);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    
        public User GetUserByUid(Guid id)
        {
            var user = new User();
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    user = ctx.Users.FirstOrDefault(o => o.UserId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

        public void UpdateUser(Guid id, User user)
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    if(GetUserByUid(id) != null)
                    {
                        ctx.Users.Add(user);
                        ctx.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        ctx.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
