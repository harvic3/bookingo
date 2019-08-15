namespace BookingoApi.Modules.RoomAdmin
{
    public interface IRoomAdmin
    {
        RoomModel CreateRoom(RoomModel room);
        RoomModel UpdateRoom(RoomModel room);
        RoomModel GetRoom(long roomId);
        RoomModel ExistsRoom(long idHotel, short code);
        void DeleteRoom(RoomModel room);
    }
}
