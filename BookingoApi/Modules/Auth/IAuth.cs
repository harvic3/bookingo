using System.Collections.Generic;
using BookingoApi.Modules.UserAdmin;

namespace BookingoApi.Modules.Auth
{
    public interface IAuth
    {
        UserModel UpdateUserAuth(UserModel user);
        UserModel CreateUserAuth(UserModel user);
        TokenModel IsValidToken(string token);
        UserModel DisableUserAuth(UserModel user);
        string RenewCustomAuthToken(string uid, Dictionary<string, object> clains);
        UserModel GetUserByUid(string uid);
        UserModel GetUserByEmail(string email);
        void DeleteUser(string uid);
    }
}
