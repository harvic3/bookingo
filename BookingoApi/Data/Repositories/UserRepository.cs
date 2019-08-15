using BookingoApi.Data.DBContext;
using BookingoApi.Modules.UserAdmin;
using BoxAgileDev;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingoApi.Data.Repositories
{
    public class UserRepository : NinjectModule, IUserAdmin
    {
        public override void Load()
        {
            this.Bind<IUserAdmin>().To<UserRepository>();
        }

        private BookingoContext _bookingoContext;
        private BookingoContext BookingoContext
        {
            get
            {
                _bookingoContext = _bookingoContext ?? new BookingoContext();
                return _bookingoContext;
            }
        }

        public UserModel CreateUser(UserModel user)
        {
            User newUser = SimpleMapper.Map<User>(user);
            BookingoContext.DataBase().Users.Add(newUser);
            BookingoContext.DataBase().SaveChanges();
            return SimpleMapper.Map<UserModel>(newUser);
        }

        public void DeleteUser(UserModel user)
        {
            user.Disabled = true;
            user.Deleted = true;
            User deletedUser = SimpleMapper.Map<User>(user);
            User currentUser = BookingoContext.DataBase().Users.Where(x => x.Uid == user.Uid).FirstOrDefault();
            BookingoContext.DataBase().Entry(currentUser).CurrentValues.SetValues(deletedUser);
            BookingoContext.DataBase().SaveChanges();
        }

        public List<UserModel> GetUsers()
        {
            List<User> users = BookingoContext.DataBase().Users.Where(x => x.Deleted == false).ToList();
            return SimpleMapper.MapCollection<UserModel>(users);
        }

        public UserModel UpdateUser(UserModel user)
        {
            User userUpdated = SimpleMapper.Map<User>(user);
            User currentUser = BookingoContext.DataBase().Users.Where(x => x.Uid == user.Uid).FirstOrDefault();
            BookingoContext.DataBase().Entry(currentUser).CurrentValues.SetValues(userUpdated);
            BookingoContext.DataBase().SaveChanges();
            return SimpleMapper.Map<UserModel>(currentUser);
        }

        public UserModel GetUserByEmail(string email)
        {
            User user = BookingoContext.DataBase().Users.Where(x => x.Email == email).FirstOrDefault();
            return SimpleMapper.Map<UserModel>(user);
        }

        public UserModel GetUserByUid(string uid)
        {
            User user = BookingoContext.DataBase().Users.Where(x => x.Uid == uid).FirstOrDefault();
            user.Role = BookingoContext.DataBase().Roles.Where(x => x.Id == user.RoleId).FirstOrDefault();
            UserModel recUser = SimpleMapper.Map<UserModel>(user);
            recUser.Role = SimpleMapper.Map<RoleModel>(user.Role);
            return recUser;
        }

        public List<RoleModel> GetRoles()
        {
            List<Role> roles = BookingoContext.DataBase().Roles.ToList();
            return SimpleMapper.MapCollection<RoleModel>(roles);
        }
    }
}