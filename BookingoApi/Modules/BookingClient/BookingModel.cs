using BookingoApi.Modules.HotelAdmin;
using BookingoApi.Modules.RoomAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingoApi.Modules.BookingClient
{
    public partial class BookingModel
    {
        public long Id { get; set; }
        public long IdHotel { get; set; }
        public long IdRoom { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Days { get; set; }
        public decimal Price { get; set; }
        public short Tax { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
        public string ApplicantName { get; set; }
        public string Email { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public bool EmailSended { get; set; }
        
        public virtual RoomModel Room { get; set; }
        public virtual HotelModel Hotel { get; set; }
        public virtual List<GuestModel> Guests { get; set; }
    }
}