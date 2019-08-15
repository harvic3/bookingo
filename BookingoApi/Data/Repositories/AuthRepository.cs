using BoxAgileDev;
using FirebaseAdmin.Auth;
using FireBaseAdmin.OAuth;
using Ninject.Modules;
using System.Threading.Tasks;
using BookingoApi.Modules.AppSettings;
using BookingoApi.Modules.Auth;
using BookingoApi.Modules.UserAdmin;
using System.Collections.Generic;

namespace BookingoApi.Data.Repositories
{
    public class AuthRepository : NinjectModule, IAuth
    {
        public override void Load()
        {
            this.Bind<IAuth>().To<AuthRepository>();
            InitilizeAuthProvider();
        }

        private void InitilizeAuthProvider()
        {
            string credentialsFilePath = AppSettings.GetFullPathOfFileName(AppSettings.GetAppSettingsParameter(AppSettings.AuthAppCredentialsFileName));
            string appName = AppSettings.GetAppSettingsParameter(AppSettings.AuthAppNameParameter);
            AuthProvider.InitializeAuthApp(credentialsFilePath, appName);
        }
    
        public TokenModel IsValidToken(string token)
        {
            FirebaseToken firebaseToken = AuthProvider.IsValidToken(token);
            return SimpleMapper.Map<TokenModel>(firebaseToken);
        }

        public string RenewCustomAuthToken(string uid, Dictionary<string, object> clains)
        {
            string token = AuthProvider.RenewCustomAuthToken(uid, clains);
            return token;
        }

        public UserModel CreateUserAuth(UserModel user)
        {
            UserRecord userUpdated = AuthProvider.CreateUser(user.Email, user.DisplayName, user.PhoneNumber, user.Password, user.PhotoUrl);
            return SimpleMapper.Map<UserModel>(userUpdated);
        }

        public UserModel UpdateUserAuth(UserModel user)
        {
            UserRecord userUpdated = AuthProvider.UpdateUser(user.Uid, user.Email, user.DisplayName, user.PhoneNumber, user.Password, user.Disabled, user.EmailVerified, user.PhotoUrl);
            return SimpleMapper.Map<UserModel>(userUpdated);
        }

        public UserModel DisableUserAuth(UserModel user)
        {
            user.Disabled = true;
            UserRecord userUpdated = AuthProvider.UpdateUser(user.Uid, user.Email, user.DisplayName, user.PhoneNumber, user.Password, user.Disabled, user.EmailVerified, user.PhotoUrl);
            return SimpleMapper.Map<UserModel>(userUpdated);
        }

        public UserModel GetUserByUid(string uid)
        {
            UserRecord user = AuthProvider.GetUserByUid(uid);
            return SimpleMapper.Map<UserModel>(user);
        }

        public UserModel GetUserByEmail(string email)
        {
            UserRecord user = AuthProvider.GetUserByEmail(email);
            return SimpleMapper.Map<UserModel>(user);
        }
        
        public void DeleteUser(string uid)
        {
            AuthProvider.DeleteUser(uid);
        }

    }
}