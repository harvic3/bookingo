using BookingoApi.Modules.AppSettings;
using BookingoApi.Modules.Auth;
using BookingoApi.Modules.UserAdmin;
using BoxAgileDev;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace BookingoApi.Controllers
{
    [HandleError]
    [RoutePrefix("api/UserAdmin")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserAdminController : HttpApi<UserAdminContract>
    {
        [AuthRequestFilter(ModuleName = "UserAdmin", ModuleAction = "Read")]
        [Route("GetRoles"), HttpGet, ResponseType(typeof(HttpResponseMessage))]
        public HttpResponseMessage GetRoles()
        {
            return HttpUtility.HandleResult(Instance.GetRoles(), Request);
        }

        //[AuthRequestFilter(ModuleName = "UserAdmin", ModuleAction = "Read")]
        public HttpResponseMessage Get()
        {
            return HttpUtility.HandleResult(Instance.GetUsers(), Request);
        }

        //[AuthRequestFilter(ModuleName = "UserAdmin", ModuleAction = "Create")]
        public HttpResponseMessage Post(dynamic customUser)
        {
            UserModel user = PostUtility.Get<UserModel>(customUser);
            return HttpUtility.HandleResult(Instance.CreateUser(user), Request);
        }

        //[AuthRequestFilter(ModuleName = "UserAdmin", ModuleAction = "Edit")]
        public HttpResponseMessage Put(dynamic customUser)
        {
            UserModel user = PostUtility.Get<UserModel>(customUser);
            return HttpUtility.HandleResult(Instance.UpdateUser(user), Request);
        }

        //[AuthRequestFilter(ModuleName = "UserAdmin", ModuleAction = "Delete")]
        public HttpResponseMessage Delete(string userUid)
        {
            return HttpUtility.HandleResult(Instance.DeleteUser(userUid), Request);
        }

    }
}