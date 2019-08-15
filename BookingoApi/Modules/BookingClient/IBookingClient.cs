using BookingoApi.Modules.HotelAdmin;
using BookingoApi.Modules.RoomAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingoApi.Modules.BookingClient
{
    public interface IBookingClient
    {
        List<HotelModel> GetFreeHotels(DateTime startDate, DateTime endDate, Int16 guests, int cityId, int take, int skip);
        List<RoomModel> GetFreeHotelRooms(DateTime startDate, DateTime endDate, Int16 guests, long hotelId, int take, int skip);
        BookingModel CreateBooking(BookingModel booking);
        RoomModel GetRoom(long hotelId, long roomId);
        HotelModel GetHotel(long hotelId);
        (bool, BookingModel) IsRoomAvailable(long roomId, DateTime startDate, DateTime endDate);
        List<BookingModel> GetMyBooking(string email, DateTime currentDate);
        List<string> GetIdentifications();
        List<string> GetGenres();
        List<BookingModel> GetHotelBookings(long hotelId, DateTime startDate, DateTime endDate);
        BookingModel GetHotelDetailBooking(long bookingId);
    }
}
