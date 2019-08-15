using System.Collections.Generic;

namespace BookingoApi.Modules.UserAdmin
{
    public interface IUserAdmin
    {
        UserModel CreateUser(UserModel user);
        UserModel UpdateUser(UserModel user);
        List<UserModel> GetUsers();
        void DeleteUser(UserModel user);
        UserModel GetUserByEmail(string email);
        UserModel GetUserByUid(string uid);
        List<RoleModel> GetRoles();
    }
}
