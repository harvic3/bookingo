using BookingoApi.Data.DBContext;
using BookingoApi.Modules.BookingClient;
using BookingoApi.Modules.HotelAdmin;
using BookingoApi.Modules.RoomAdmin;
using BoxAgileDev;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingoApi.Data.Repositories
{
    public class BookingRepository : NinjectModule, IBookingClient
    {
        public override void Load()
        {
            this.Bind<IBookingClient>().To<BookingRepository>();
        }

        private BookingoContext _bookingoContext;
        private BookingoContext BookingoContext
        {
            get
            {
                _bookingoContext = _bookingoContext ?? new BookingoContext();
                return _bookingoContext;
            }
        }

        public BookingModel CreateBooking(BookingModel booking)
        {
            var result = CreateBooking(SimpleMapper.Map<Booking>(booking), SimpleMapper.MapCollection<Guest>(booking.Guests));
            if (result.Item1)
            {
                BookingModel newBoooking = SimpleMapper.Map<BookingModel>(result.Item2);
                newBoooking.Guests = SimpleMapper.MapCollection<GuestModel>(result.Item3);
                newBoooking.Room = SimpleMapper.Map<RoomModel>(BookingoContext.DataBase().Rooms.Where(x => x.Id == booking.IdRoom).FirstOrDefault());
                return newBoooking;
            }
            return null;
            
            (bool, Booking, List<Guest>) CreateBooking(Booking newBooking, List<Guest> guests)
            {
                bool created = false;
                using (BookingoContext context = BookingoContext.NewDataBase())
                {
                    Booking createdBooking = context.Bookings.Add(newBooking);
                    if (createdBooking != null)
                    {
                        List<Guest> createdGuests = new List<Guest>();
                        foreach (Guest guest in guests)
                        {
                            guest.IdBooking = createdBooking.Id;
                            createdGuests.Add(context.Guests.Add(guest));
                        }
                        context.SaveChanges();
                        created = true;
                        return (created, createdBooking, createdGuests);
                    }
                    return (created, null, null);
                }                
            }
        }

        public List<RoomModel> GetFreeHotelRooms(DateTime startDate, DateTime endDate, short guests, long hotelId, int take, int skip)
        {
            var freeRooms = BookingoContext.DataBase().GetFreeHotelRooms(guests, hotelId, startDate, endDate).OrderBy(x => x.Id).Take(take).Skip(skip).ToList();
            return SimpleMapper.MapCollection<RoomModel>(freeRooms);
        }

        public List<HotelModel> GetFreeHotels(DateTime startDate, DateTime endDate, short guests, int cityId, int take, int skip)
        {
            var freeHotels = BookingoContext.DataBase().GetFreeHotels(guests, cityId, startDate, endDate).OrderBy(x => x.Id).Take(take).Skip(skip).ToList();
            return SimpleMapper.MapCollection<HotelModel>(freeHotels);
        }

        public List<BookingModel> GetMyBooking(string email, DateTime currentDate)
        {
            var result = BookingoContext.DataBase().Bookings.Where(x => x.Email == email && x.EndDate >= currentDate).ToList();
            var myBookings = SimpleMapper.MapCollection<BookingModel>(result);
            foreach (BookingModel booking in myBookings)
            {
                booking.Guests = SimpleMapper.MapCollection<GuestModel>(result.Where(x => x.Id == booking.Id).FirstOrDefault().Guests.ToList());
                booking.Hotel = SimpleMapper.Map<HotelModel>(result.Where(x => x.Id == booking.Id).Select(x => x.Hotel).FirstOrDefault());
            }
            return myBookings;
        }

        public List<string> GetIdentifications()
        {
            List<string> identificationTypes = new List<string>();
            identificationTypes.Add("Cédula");
            identificationTypes.Add("Pasaporte");
            identificationTypes.Add("Registro Civil");
            identificationTypes.Add("Tarjeta de Identidad");
            identificationTypes.Add("Cédula de Extranjería");
            return identificationTypes;
        }

        public List<string> GetGenres()
        {
            List<string> genres = new List<string>();
            genres.Add("Femenino");
            genres.Add("Masculino");     
            return genres;
        }

        public RoomModel GetRoom(long hotelId, long roomId)
        {
            Room room = BookingoContext.DataBase().Rooms.Where(x => x.Id == roomId && x.IdHotel == hotelId && x.Enabled == true && x.Deleted == false).FirstOrDefault();
            return SimpleMapper.Map<RoomModel>(room);
        }

        public HotelModel GetHotel(long hotelId)
        {
            Hotel hotel = BookingoContext.DataBase().Hotels.Where(x => x.Id == hotelId && x.Enabled == true && x.Deleted == false).FirstOrDefault();
            return SimpleMapper.Map<HotelModel>(hotel);
        }

        public (bool, BookingModel) IsRoomAvailable(long roomId, DateTime startDate, DateTime endDate)
        {
            //Booking existsBooking = BookingoContext.DataBase().Bookings.Where(x => x.IdRoom == roomId && x.StartDate >= endDate && x.EndDate <= startDate).FirstOrDefault();
            Booking existsBooking = BookingoContext.DataBase().Bookings.Where(x => x.IdRoom == roomId && x.StartDate >= startDate && x.EndDate <= endDate).FirstOrDefault();
            return (existsBooking == null) ? (true, null) : (false, SimpleMapper.Map<BookingModel>(existsBooking));
        }

        public List<BookingModel> GetHotelBookings(long hotelId, DateTime startDate, DateTime endDate)
        {
            var result = BookingoContext.DataBase().Bookings.Where(x => x.IdHotel == hotelId && x.StartDate >= startDate && x.StartDate <= endDate).ToList();
            return SimpleMapper.MapCollection<BookingModel>(result);
        }

        public BookingModel GetHotelDetailBooking(long bookingId)
        {
            var result = BookingoContext.DataBase().Bookings.Where(x => x.Id == bookingId).FirstOrDefault();
            var booking = SimpleMapper.Map<BookingModel>(result);
            if (booking != null)
            {
                booking.Guests = SimpleMapper.MapCollection<GuestModel>(result.Guests);
                booking.Hotel = SimpleMapper.Map<HotelModel>(result.Hotel);
            }
            return booking;
        }

    }
}