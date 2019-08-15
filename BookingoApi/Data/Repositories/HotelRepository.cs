using BookingoApi.Data.DBContext;
using BookingoApi.Modules.HotelAdmin;
using BookingoApi.Modules.RoomAdmin;
using BoxAgileDev;
using Ninject.Modules;
using System.Collections.Generic;
using System.Linq;

namespace BookingoApi.Data.Repositories
{
    public class HotelRepository : NinjectModule, IHotelAdmin
    {
        public override void Load()
        {
            this.Bind<IHotelAdmin>().To<HotelRepository>();
        }

        //private BookingoEntities _dbBookingo;
        //private BookingoEntities DbBookingo
        //{
        //    get
        //    {
        //        _dbBookingo = _dbBookingo ?? new BookingoEntities();
        //        return _dbBookingo;
        //    }
        //}

        //public HotelModel CreateHotel(HotelModel hotel)
        //{
        //    Hotel newhotel = SimpleMapper.Map<Hotel>(hotel);
        //    DbBookingo.Hotels.Add(newhotel);
        //    DbBookingo.SaveChanges();
        //    return SimpleMapper.Map<HotelModel>(newhotel);
        //}

        private BookingoContext _bookingoContext;
        private BookingoContext BookingoContext
        {
            get
            {
                _bookingoContext = _bookingoContext ?? new BookingoContext();
                return _bookingoContext;
            }
        }

        public HotelModel CreateHotel(HotelModel hotel)
        {
            Hotel newHotel = SimpleMapper.Map<Hotel>(hotel);
            BookingoContext.DataBase().Hotels.Add(newHotel);
            BookingoContext.DataBase().SaveChanges();
            return SimpleMapper.Map<HotelModel>(newHotel);
        }

        public HotelModel GetHotel(long hotelId)
        {
            Hotel hotel = BookingoContext.DataBase().Hotels.Where(x => x.Id == hotelId).FirstOrDefault();
            List<Room> rooms = BookingoContext.DataBase().Rooms.Where(x => x.IdHotel == hotelId).ToList();
            var recHotel = SimpleMapper.Map<HotelModel>(hotel) ?? null;
            if (rooms != null && rooms.Count > 0)
            {
                recHotel.Rooms = SimpleMapper.MapCollection<RoomModel>(rooms);
            }
            return recHotel;
        }

        public List<HotelModel> GetHotels()
        {
            List<Hotel> hotels = BookingoContext.DataBase().Hotels.Where(x => x.Deleted == false).ToList();
            return SimpleMapper.MapCollection<HotelModel>(hotels);
        }

        public HotelModel UpdateHotel(HotelModel hotel)
        {
            Hotel updatedHotel = SimpleMapper.Map<Hotel>(hotel);
            Hotel currentHotel = BookingoContext.DataBase().Hotels.Where(x => x.Id == hotel.Id).FirstOrDefault();
            BookingoContext.DataBase().Entry(currentHotel).CurrentValues.SetValues(updatedHotel);
            BookingoContext.DataBase().SaveChanges();
            return SimpleMapper.Map<HotelModel>(currentHotel);
        }

        public void DeleteHotel(HotelModel hotel)
        {
            hotel.Deleted = true;
            Hotel deletedHotel = SimpleMapper.Map<Hotel>(hotel);
            Hotel currentHotel = BookingoContext.DataBase().Hotels.Where(x => x.Id == hotel.Id).FirstOrDefault();
            BookingoContext.DataBase().Entry(currentHotel).CurrentValues.SetValues(deletedHotel);
            BookingoContext.DataBase().SaveChanges();
        }

        public List<CityModel> GetCities()
        {
            List<City> cities = BookingoContext.DataBase().Cities.Where(x => x.Deleted == false).ToList();
            return SimpleMapper.MapCollection<CityModel>(cities);
        }

        public HotelModel ExistsHotel(string name, int cityId)
        {
            Hotel hotel = BookingoContext.DataBase().Hotels.Where(x => x.Name == name && x.IdCity == cityId).FirstOrDefault();
            return SimpleMapper.Map<HotelModel>(hotel);
        }
        
    }
}