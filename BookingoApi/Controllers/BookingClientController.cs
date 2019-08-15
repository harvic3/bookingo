using BookingoApi.Modules.AppSettings;
using BookingoApi.Modules.BookingClient;
using BoxAgileDev;
using System;
using System.Net.Http;
using System.Web.Http.Cors;

namespace BookingoApi.Controllers
{
    [HandleError]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BookingClientController : HttpApi<BookingClientContract>
    {
        public HttpResponseMessage Get()
        {
            return HttpUtility.HandleResult(Instance.GetBookingSupplies(), Request);
        }

        public HttpResponseMessage Get(string email)
        {
            return HttpUtility.HandleResult(Instance.GetMyBookings(email), Request);
        }

        public HttpResponseMessage Get(string startDate, string endDate, short guests, int cityId, int take, int skip)
        {
            DateTime start = DateTime.Parse(startDate.Replace("\"", ""));
            DateTime end = DateTime.Parse(endDate.Replace("\"", ""));
            return HttpUtility.HandleResult(Instance.GetFreeHotels(start, end, guests, cityId, take, skip), Request);
        }

        public HttpResponseMessage Get(long hotelId, string startDate, string endDate, short guests, int take, int skip)
        {
            DateTime start = DateTime.Parse(startDate.Replace("\"", ""));
            DateTime end = DateTime.Parse(endDate.Replace("\"", ""));
            return HttpUtility.HandleResult(Instance.GetFreeHotelRooms(start, end, guests, hotelId, take, skip), Request);
        }

        public HttpResponseMessage Post(dynamic customBooking)
        {
            BookingModel booking = PostUtility.Get<BookingModel>(customBooking);
            return HttpUtility.HandleResult(Instance.CreateBooking(booking), Request);
        }

    }
}