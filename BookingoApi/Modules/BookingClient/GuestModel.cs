using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingoApi.Modules.BookingClient
{
    public class GuestModel
    {
        public long Id { get; set; }
        public long IdBooking { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirtDate { get; set; }
        public string Genre { get; set; }
        public string Identification { get; set; }
        public string IdentificationType { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}