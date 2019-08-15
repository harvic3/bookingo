using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using BookingoApi.Modules.AppSettings;
using BoxAgileDev;
using BookingoApi.Modules.UserAdmin;

namespace BookingoApi.Modules.Auth
{
    public class AuthContract
    {
        private IAuth _authProvider;
        private IAuth AuthProvider
        {
            get
            {
                _authProvider = _authProvider ?? ModuleManager.Kernel.Get<IAuth>();
                return _authProvider;
            }
        }

        private IUserAdmin _userRepository;
        private IUserAdmin UserRepository
        {
            get
            {
                _userRepository = _userRepository ?? ModuleManager.Kernel.Get<IUserAdmin>();
                return _userRepository;
            }
        }

        public TokenModel IsValidToken(string token)
        {
            TokenModel tokenModel = AuthProvider.IsValidToken(token);
            return tokenModel;
        }

        public string RenewAuthToken(string uid)
        {
            Dictionary<string, object> clains = new Dictionary<string, object>();
            UserModel user = UserRepository.GetUserByUid(uid);
            clains.Add("role", user.Role.Name);
            clains.Add("roleId", user.RoleId);
            string token = AuthProvider.RenewCustomAuthToken(uid, clains);
            return token;
        }
        
    }
}