using BookingoApi.Modules.AppSettings;
using BookingoApi.Modules.Auth;
using BookingoApi.Modules.HotelAdmin;
using BoxAgileDev;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace BookingoApi.Controllers
{
    [HandleError]
    [RoutePrefix("api/HotelAdmin")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HotelAdminController : HttpApi<HotelAdminContract>
    {
        //[AuthRequestFilter(ModuleName = "HotelAdmin", ModuleAction = "Read")]
        [Route("GetCities"), HttpGet, ResponseType(typeof(HttpResponseMessage))]
        public HttpResponseMessage GetCities()
        {
            return HttpUtility.HandleResult(Instance.GetCities(), Request);
        }

        //[AuthRequestFilter(ModuleName = "HotelAdmin", ModuleAction = "Read")]
        public HttpResponseMessage Get()
        {
            return HttpUtility.HandleResult(Instance.GetHotels(), Request);
        }

        //[AuthRequestFilter(ModuleName = "HotelAdmin", ModuleAction = "Read")]
        public HttpResponseMessage Get(long hotelId)
        {
            return HttpUtility.HandleResult(Instance.GetHotel(hotelId), Request);
        }

        //[AuthRequestFilter(ModuleName = "HotelAdmin", ModuleAction = "Create")]
        public HttpResponseMessage Post(dynamic customHotel)
        {
            HotelModel hotel = PostUtility.Get<HotelModel>(customHotel);
            return HttpUtility.HandleResult(Instance.CreateHotel(hotel), Request);
        }

        //[AuthRequestFilter(ModuleName = "HotelAdmin", ModuleAction = "Edit")]
        public HttpResponseMessage Put(dynamic customHotel)
        {
            HotelModel hotel = PostUtility.Get<HotelModel>(customHotel);
            return HttpUtility.HandleResult(Instance.UpdateHotel(hotel), Request);
        }

        //[AuthRequestFilter(ModuleName = "HotelAdmin", ModuleAction = "Delete")]
        public HttpResponseMessage Delete(long hotelId)
        {
            return HttpUtility.HandleResult(Instance.DeleteHotel(hotelId), Request);
        }

    }
}