using BookingoApi.Modules.AppSettings;
using BookingoApi.Modules.RoomAdmin;
using BoxAgileDev;
using System.Net.Http;
using System.Web.Http.Cors;

namespace BookingoApi.Controllers
{
    [HandleError]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RoomAdminController : HttpApi<RoomAdminContract>
    {
        //[AuthRequestFilter(ModuleName = "RoomAdmin", ModuleAction = "Read")]
        public HttpResponseMessage Get(long roomId)
        {
            return HttpUtility.HandleResult(Instance.GetRoom(roomId), Request);
        }

        //[AuthRequestFilter(ModuleName = "RoomAdmin", ModuleAction = "Create")]
        public HttpResponseMessage Post(dynamic customRoom)
        {
            RoomModel room = PostUtility.Get<RoomModel>(customRoom);
            return HttpUtility.HandleResult(Instance.CreateRoom(room), Request);
        }

        //[AuthRequestFilter(ModuleName = "RoomAdmin", ModuleAction = "Edit")]
        public HttpResponseMessage Put(dynamic customRoom)
        {
            RoomModel room = PostUtility.Get<RoomModel>(customRoom);
            return HttpUtility.HandleResult(Instance.UpdateRoom(room), Request);
        }

        //[AuthRequestFilter(ModuleName = "RoomAdmin", ModuleAction = "Delete")]
        public HttpResponseMessage Delete(long roomId)
        {
            return HttpUtility.HandleResult(Instance.DeleteRoom(roomId), Request);
        }
    }
}