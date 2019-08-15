namespace BookingoApi.Modules.RoomAdmin
{
    public partial class RoomModel
    {
        public long Id { get; set; }
        public long IdHotel { get; set; }
        public string Name { get; set; }
        public short Code { get; set; }
        public short Guests { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public bool Deleted { get; set; }
        public decimal Price { get; set; }
        public short Tax { get; set; }
    }
}