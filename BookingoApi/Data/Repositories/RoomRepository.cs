using BookingoApi.Data.DBContext;
using BookingoApi.Modules.RoomAdmin;
using BoxAgileDev;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingoApi.Data.Repositories
{
    public class RoomRepository : NinjectModule, IRoomAdmin
    {
        public override void Load()
        {
            this.Bind<IRoomAdmin>().To<RoomRepository>();
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

        public RoomModel CreateRoom(RoomModel room)
        {
            Room newRoom = SimpleMapper.Map<Room>(room);
            BookingoContext.DataBase().Rooms.Add(newRoom);
            BookingoContext.DataBase().SaveChanges();
            return SimpleMapper.Map<RoomModel>(newRoom);
        }

        public void DeleteRoom(RoomModel room)
        {
            room.Deleted = true;
            Room deletedRoom = SimpleMapper.Map<Room>(room);
            Room currentRoom = BookingoContext.DataBase().Rooms.Where(x => x.Id == room.Id).FirstOrDefault();
            BookingoContext.DataBase().Entry(currentRoom).CurrentValues.SetValues(deletedRoom);
            BookingoContext.DataBase().SaveChanges();
        }

        public RoomModel GetRoom(long roomId)
        {
            Room recRoom = BookingoContext.DataBase().Rooms.Where(x => x.Id == roomId && x.Deleted == false).FirstOrDefault();
            return SimpleMapper.Map<RoomModel>(recRoom);
        }

        public RoomModel UpdateRoom(RoomModel room)
        {
            Room updatedRoom = SimpleMapper.Map<Room>(room);
            Room currentRoom = BookingoContext.DataBase().Rooms.Where(x => x.Id == room.Id).FirstOrDefault();
            BookingoContext.DataBase().Entry(currentRoom).CurrentValues.SetValues(updatedRoom);
            BookingoContext.DataBase().SaveChanges();
            return SimpleMapper.Map<RoomModel>(currentRoom);
        }

        public RoomModel ExistsRoom(long idHotel, short code)
        {
            Room recRoom = BookingoContext.DataBase().Rooms.Where(x => x.IdHotel == idHotel && x.Code == code && x.Deleted == false).FirstOrDefault();
            return SimpleMapper.Map<RoomModel>(recRoom);
        }
    }
}