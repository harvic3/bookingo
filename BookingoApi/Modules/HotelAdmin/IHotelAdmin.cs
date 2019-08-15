using System.Collections.Generic;

namespace BookingoApi.Modules.HotelAdmin
{
    public interface IHotelAdmin
    {
        HotelModel CreateHotel(HotelModel hotel);
        HotelModel UpdateHotel(HotelModel hotel);
        List<HotelModel> GetHotels();
        HotelModel GetHotel(long hotelId);
        HotelModel ExistsHotel(string name, int cityId);
        void DeleteHotel(HotelModel hotel);
        List<CityModel> GetCities();
    }
}
