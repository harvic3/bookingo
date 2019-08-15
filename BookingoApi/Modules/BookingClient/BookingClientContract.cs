using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookingoApi.Modules.AppSettings;
using BookingoApi.Modules.HotelAdmin;
using BookingoApi.Modules.RoomAdmin;
using BoxAgileDev;
using Ninject;

namespace BookingoApi.Modules.BookingClient
{
    public class BookingClientContract
    {
        private IBookingClient _bookingRepository;
        private IBookingClient BookingRepository
        {
            get
            {
                _bookingRepository = _bookingRepository ?? ModuleManager.Kernel.Get<IBookingClient>();
                return _bookingRepository;
            }
        }

        private bool IsValidBooking(BookingModel booking, Result result)
        {
            if (TypeValidator.Validate(booking) == FlowOptions.Failed)
            {
                result.AddMessageToList(BookingResource.NotValidBooking);
            }
            else
            {
                if (booking.StartDate >= booking.EndDate)
                {
                    result.AddMessageToList(BookingResource.DatesNotValid);
                }
                if (TypeValidator.Validate(booking.IdHotel) == FlowOptions.Failed)
                {
                    result.AddMessageToList(BookingResource.HotelRequired);
                }
                if (TypeValidator.Validate(booking.IdRoom) == FlowOptions.Failed)
                {
                    result.AddMessageToList(BookingResource.RoomRequired);
                }
                if (TypeValidator.Validate(booking.ApplicantName) == FlowOptions.Failed)
                {
                    result.AddMessageToList(BookingResource.ApplicantRequired);
                }
                if (TypeValidator.Validate(booking.Email) == FlowOptions.Failed)
                {
                    result.AddMessageToList(BookingResource.EmailRequired);
                }
                if (TypeValidator.Validate(booking.ContactName) == FlowOptions.Failed)
                {
                    result.AddMessageToList(BookingResource.ContactNameRequired);
                }
                if (TypeValidator.Validate(booking.ContactPhone) == FlowOptions.Failed)
                {
                    result.AddMessageToList(BookingResource.ContactPhoneRequired);
                }

                foreach(GuestModel guest in booking.Guests)
                {
                    if (TypeValidator.Validate(guest) == FlowOptions.Failed)
                    {
                        result.AddMessageToList(BookingResource.NotValidGuest);
                    }
                    else
                    {
                        if (TypeValidator.Validate(guest.Name) == FlowOptions.Failed)
                        {
                            result.AddMessageToList(BookingResource.GuestNameRequired);
                        }
                        if (TypeValidator.Validate(guest.LastName) == FlowOptions.Failed)
                        {
                            result.AddMessageToList(BookingResource.GuestLastNRequired);
                        }
                        if (TypeValidator.Validate(guest.BirtDate) == FlowOptions.Failed)
                        {
                            result.AddMessageToList(BookingResource.GuestBirtRequired);
                        }
                        if (TypeValidator.Validate(guest.Name) == FlowOptions.Failed)
                        {
                            result.AddMessageToList(BookingResource.GuestNameRequired);
                        }
                        if (TypeValidator.Validate(guest.LastName) == FlowOptions.Failed)
                        {
                            result.AddMessageToList(BookingResource.GuestLastNRequired);
                        }
                        if (TypeValidator.Validate(guest.BirtDate) == FlowOptions.Failed)
                        {
                            result.AddMessageToList(BookingResource.GuestBirtRequired);
                        }
                        if (TypeValidator.Validate(guest.Genre) == FlowOptions.Failed)
                        {
                            result.AddMessageToList(BookingResource.GuestGenreRequired);
                        }
                        if (TypeValidator.Validate(guest.Identification) == FlowOptions.Failed)
                        {
                            result.AddMessageToList(BookingResource.GuestIdRequired);
                        }
                        if (TypeValidator.Validate(guest.IdentificationType) == FlowOptions.Failed)
                        {
                            result.AddMessageToList(BookingResource.GuestIdTypeRequired);
                        }
                        if (TypeValidator.Validate(guest.Email) == FlowOptions.Failed)
                        {
                            result.AddMessageToList(BookingResource.GuesEmailRequired);
                        }
                        if (TypeValidator.Validate(guest.PhoneNumber) == FlowOptions.Failed)
                        {
                            result.AddMessageToList(BookingResource.GuestPhoneRequired);
                        }
                    }
                }

            }
            return (result.Messages.Count == 0) ? true : false;
        }

        private bool IsValidDates(DateTime startDate, DateTime endDate, Result result)
        {
            if (startDate >= endDate)
            {
                result.Message = BookingResource.DatesNotValid;
                result.FlowControl = FlowOptions.Failed;
                return false;
            }
            return true;
        }

        public Result GetFreeHotels(DateTime startDate, DateTime endDate, short guests, int cityId, int take, int skip)
        {
            Result result = new Result();
            if (!IsValidDates(startDate, endDate, result))
            { 
                return result;
            }
            List<HotelModel> freeHotels = BookingRepository.GetFreeHotels(startDate, endDate, guests, cityId, take, skip);
            if (freeHotels != null && freeHotels.Count > 0)
            {
                result.Data = freeHotels;
                result.FlowControl = FlowOptions.Success;
            }
            else
            {
                result.FlowControl = FlowOptions.Nothing;
                result.Message = BookingResource.HotelsNotFound;
            }
            return result;
        }

        public Result GetFreeHotelRooms(DateTime startDate, DateTime endDate, short guests, long hotelId, int take, int skip)
        {
            Result result = new Result();
            if (!IsValidDates(startDate, endDate, result))
            {
                return result;
            }
            List<RoomModel> freeRoom = BookingRepository.GetFreeHotelRooms(startDate, endDate, guests, hotelId, take, skip);
            if (freeRoom != null && freeRoom.Count > 0)
            {
                result.Data = freeRoom;
                result.FlowControl = FlowOptions.Success;
            }
            else
            {
                result.FlowControl = FlowOptions.Nothing;
                result.Message = BookingResource.RoomsNotFound;
            }
            return result;
        }

        public Result CreateBooking(BookingModel booking)
        {
            Result result = new Result();
            if (!IsValidBooking(booking, result))
            {
                result.Message = result.GetMessages(" - ");
                result.Data = booking;
                result.FlowControl = FlowOptions.Failed;
                return result;
            }
            RoomModel room = BookingRepository.GetRoom(booking.IdHotel, booking.IdRoom);
            HotelModel hotel = BookingRepository.GetHotel(booking.IdHotel);
            if (room != null && hotel != null)
            {
                booking.Price = room.Price;
                booking.Tax = hotel.Tax;
                booking.SubTotal = room.Price * (booking.EndDate - booking.StartDate).Days;
                booking.Total = booking.SubTotal * 1 + (booking.SubTotal * 100/ booking.Tax);
                booking.EmailSended = false;
                if (IsRoomAvailable(booking.IdRoom, booking.StartDate, booking.EndDate))
                {
                    BookingModel newBooking = BookingRepository.CreateBooking(booking);
                    if (newBooking != null)
                    {
                        result.Data = newBooking;
                        result.FlowControl = FlowOptions.Success;
                        // TODO: send email here
                    }                   
                }
                else
                {
                    result.Message = result.GetMessages(" - ");
                    result.Data = booking;
                    result.FlowControl = FlowOptions.Failed;
                }
            }
            else
            {
                if (room == null)
                {
                    result.AddMessageToList(BookingResource.RoomNotFound);
                }
                if (hotel == null)
                {
                    result.AddMessageToList(BookingResource.HotelNotFound);
                }
                result.Message = result.GetMessages(" - ");
                result.Data = booking;
                result.FlowControl = FlowOptions.Failed;
            }  
            return result;

            bool IsRoomAvailable(long roomId, DateTime startDate, DateTime endDate)
            {
                var available = BookingRepository.IsRoomAvailable(roomId, startDate, endDate);
                if (available.Item2 != null)
                {
                    result.AddMessageToList(String.Format(BookingResource.RoomNoAvailableIntro, BookingResource.RoomNotAvailable, available.Item2.StartDate, available.Item2.EndDate));
                }
                return available.Item1;
            }
        }

        public Result GetMyBookings(string email)
        {
            Result result = new Result();
            DateTime currentDate = DateTime.Now;
            var myBookings = BookingRepository.GetMyBooking(email, currentDate);
            if (myBookings != null && myBookings.Count > 0)
            {
                result.Data = myBookings;
                result.FlowControl = FlowOptions.Success;
            }
            else
            {
                result.FlowControl = FlowOptions.Nothing;
                result.Message = BookingResource.NoBookingsFound;
            }
            return result;
        }

        public Result GetBookingSupplies()
        {
            Result result = new Result();
            result.AddData("IdentificationTypes", BookingRepository.GetIdentifications());
            result.AddData("Genres", BookingRepository.GetGenres());
            result.FlowControl = FlowOptions.Success;
            return result;
        }

    }
}