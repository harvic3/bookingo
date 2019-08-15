using BookingoApi.Modules.AppSettings;
using BookingoApi.Modules.BookingAdmin;
using BoxAgileDev;
using System;
using System.Net.Http;
using System.Web.Http.Cors;

namespace BookingoApi.Controllers
{
    [HandleError]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BookingAdminController : HttpApi<BookingAdminContract>
    {
        //[AuthRequestFilter(ModuleName = "BookingAdmin", ModuleAction = "Read")]
        public HttpResponseMessage Get(long hotelId, string startDate, string endDate)
        {
            DateTime start = DateTime.Parse(startDate.Replace("\"", ""));
            DateTime end = DateTime.Parse(endDate.Replace("\"", ""));
            return HttpUtility.HandleResult(Instance.GetHotelBooking(hotelId, start, end), Request);
        }

        //[AuthRequestFilter(ModuleName = "BookingAdmin", ModuleAction = "Read")]
        public HttpResponseMessage Get(long bookingId)
        {
            return HttpUtility.HandleResult(Instance.GetDetailBooking(bookingId), Request);
        }

    }
}