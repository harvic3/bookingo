using BookingoApi.Modules.AppSettings;
using BookingoApi.Modules.BookingClient;
using BoxAgileDev;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingoApi.Modules.BookingAdmin
{
    public class BookingAdminContract
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

        public Result GetHotelBooking(long hotelId, DateTime startDate, DateTime endDate)
        {
            Result result = new Result();
            if (startDate > endDate)
            {
                result.Message = BookingAdminResource.NotValidDates;
                result.FlowControl = FlowOptions.Failed;
                return result;
            }
            List<BookingModel> bookings = BookingRepository.GetHotelBookings(hotelId, startDate, endDate);
            if (bookings != null && bookings.Count > 0)
            {
                result.Data = bookings;
                result.FlowControl = FlowOptions.Success;
            }
            else
            {
                result.FlowControl = FlowOptions.Nothing;
                result.Message = BookingAdminResource.NotFound;
            }
            return result;
        }

        public Result GetDetailBooking(long bookingId)
        {
            Result result = new Result();
            BookingModel booking = BookingRepository.GetHotelDetailBooking(bookingId);
            if (booking != null)
            {
                result.Data = booking;
                result.FlowControl = FlowOptions.Success;
            }
            else
            {
                result.FlowControl = FlowOptions.Nothing;
                result.Message = BookingAdminResource.NotFoundOne;
            }
            return result;
        }
    }
}