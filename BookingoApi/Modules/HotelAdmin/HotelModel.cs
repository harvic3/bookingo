using BookingoApi.Modules.RoomAdmin;
using System.Collections.Generic;

namespace BookingoApi.Modules.HotelAdmin
{
    public partial class HotelModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int IdCity { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public short Stars { get; set; }
        public string Location { get; set; }
        public short Tax { get; set; }
        public bool Enabled { get; set; }
        public bool Deleted { get; set; }
        public string CityName { get; set; }

        public virtual List<RoomModel> Rooms { get; set; }
    }
}