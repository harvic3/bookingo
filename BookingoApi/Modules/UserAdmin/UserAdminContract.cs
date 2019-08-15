using BoxAgileDev;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookingoApi.Modules.AppSettings;
using BookingoApi.Modules.Auth;

namespace BookingoApi.Modules.UserAdmin
{
    public class UserAdminContract
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

        private bool IsValidUser(UserModel user, Result result, bool updating = false)
        {
            if (TypeValidator.Validate(user) == FlowOptions.Failed)
            {
                result.AddMessageToList(UserResource.NotValid);
            }
            else
            {
                if (updating && TypeValidator.Validate(user.Uid) == FlowOptions.Failed)
                {
                    result.AddMessageToList(UserResource.UidRequired);
                }
                if (TypeValidator.Validate(user.DisplayName) == FlowOptions.Failed)
                {
                    result.AddMessageToList(UserResource.NameRequired);
                }
                if (TypeValidator.Validate(user.Email) == FlowOptions.Failed)
                {
                    result.AddMessageToList(UserResource.EmailRequired);
                }
                if (TypeValidator.Validate(user.RoleId) == FlowOptions.Failed)
                {
                    result.AddMessageToList(UserResource.RoleRequired);
                }
            }
            return (result.Messages.Count() == 0) ? true : false;
        }

        public Result GetRoles()
        {
            Result result = new Result();
            List<RoleModel> roles = UserRepository.GetRoles();
            if (roles != null && roles.Count > 0)
            {
                result.Data = roles;
                result.FlowControl = FlowOptions.Success;
            }
            else
            {
                result.FlowControl = FlowOptions.Nothing;
                result.Message = UserResource.RolesNotFound;
            }
            return result;
        }

        public Result GetUsers()
        {
            Result result = new Result();
            List<UserModel> users = UserRepository.GetUsers();
            if (users != null && users.Count > 0)
            {
                result.Data = users;
                result.FlowControl = FlowOptions.Success;
            }
            else
            {
                result.Message = UserResource.UsersNotFound;
                result.FlowControl = FlowOptions.Nothing;
            }
            return result;
        }

        public Result CreateUser(UserModel newUser)
        {
            Result result = new Result();
            if (!IsValidUser(newUser, result))
            {
                result.Message = result.GetMessages(" - ");
                result.FlowControl = FlowOptions.Failed;
                result.Data = newUser;
                return result;
            }
            var existUsers = VerifyIfUserExists(newUser.Email);
            if (existUsers.Item1 == null && existUsers.Item2 == null)
            {
                var createdUsers = CreateUsers(newUser);
                if (createdUsers.Item1 == null && createdUsers.Item2 == null)
                {
                    result.AddMessageToList(UserResource.NoCreated);
                    result.Message = result.GetMessages(" - ");
                    result.FlowControl = FlowOptions.Failed;
                    return result;
                }
                if (createdUsers.Item1 == null)
                {
                    result.AddMessageToList(UserResource.ErrorAuthCreate);
                    result.Message = result.GetMessages(" - ");
                    result.FlowControl = FlowOptions.Failed;
                    return result;
                }
                if (createdUsers.Item2 == null)
                {
                    AuthProvider.DeleteUser(createdUsers.Item1.Uid);
                    result.AddMessageToList(UserResource.ErrorLocalCreate);
                    result.Message = result.GetMessages(" - ");
                    result.FlowControl = FlowOptions.Failed;
                    return result;
                }
                result.Data = createdUsers.Item2;
                result.Message = UserResource.Created;
                result.FlowControl = FlowOptions.Success;
                return result;
            }
            if (existUsers.Item1 != null && existUsers.Item2 == null)
            {
                newUser.Uid = existUsers.Item1.Uid;
                UserModel localUser = UserRepository.CreateUser(newUser);
                if (localUser != null)
                {
                    result.Data = localUser;
                    result.Message = UserResource.Created;
                    result.FlowControl = FlowOptions.Success;
                }
            }

            result.Message = result.GetMessages(" - ");
            return result;

            (UserModel, UserModel) VerifyIfUserExists(string email)
            {
                UserModel authUser = new UserModel();
                UserModel localUser = new UserModel();
                try
                {
                    authUser = AuthProvider.GetUserByEmail(email);
                    localUser = UserRepository.GetUserByEmail(email);
                    result.AddMessageToList(UserResource.AuthUserExist);
                    result.AddMessageToList(UserResource.LocalUserExist);
                    return (authUser, localUser);
                }
                catch (Exception ex)
                {
                    result.AddMessageToList(ex?.InnerException?.Message ?? ex.Message);
                    return (authUser.Uid != null ? authUser : null, localUser.Uid != null ? localUser : null);
                }
            }

            (UserModel, UserModel) CreateUsers(UserModel user)
            {
                UserModel authUser = new UserModel();
                UserModel localUser = new UserModel();
                try
                {
                    authUser = AuthProvider.CreateUserAuth(user);
                    user.Uid = authUser.Uid;
                    localUser = UserRepository.CreateUser(user);
                    return (authUser, localUser);
                }
                catch (Exception ex)
                {
                    result.AddMessageToList(ex?.InnerException?.Message ?? ex.Message);
                    return (authUser.Uid != null ? authUser : null, localUser.Uid != null ? localUser : null);
                }
            }
        }

        public Result UpdateUser(UserModel user)
        {
            Result result = new Result();
            if (!IsValidUser(user, result, true))
            {
                result.Message = result.GetMessages(" - ");
                result.FlowControl = FlowOptions.Failed;
                result.Data = user;
                return result;
            }
            UserModel userUpdated = AuthProvider.UpdateUserAuth(user);
            if (userUpdated != null)
            {
                result.Data = userUpdated;
                result.FlowControl = FlowOptions.Success;
            }
            return result;
        }

        public Result DeleteUser(string userId)
        {
            Result result = new Result();
            // TODO: Delete User
            return result;
        }

    }
}