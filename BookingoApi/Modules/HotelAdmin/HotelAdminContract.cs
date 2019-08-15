using BookingoApi.Modules.AppSettings;
using BoxAgileDev;
using Ninject;
using System.Collections.Generic;
using System.Linq;

namespace BookingoApi.Modules.HotelAdmin
{
    public class HotelAdminContract
    {
        private IHotelAdmin _hotelRepository;
        private IHotelAdmin HotelRepository
        {
            get
            {
                _hotelRepository = _hotelRepository ?? ModuleManager.Kernel.Get<IHotelAdmin>();
                return _hotelRepository;
            }
        }

        private bool IsValidHotel(HotelModel hotel, Result result)
        {
            if (TypeValidator.Validate(hotel) == FlowOptions.Failed)
            {
                result.AddMessageToList(HotelResource.NotValid);
            }
            else
            {
                if (TypeValidator.Validate(hotel.Name) == FlowOptions.Failed)
                {
                    result.AddMessageToList(HotelResource.NameRequired);
                }
                if (TypeValidator.Validate(hotel.IdCity) == FlowOptions.Failed)
                {
                    result.AddMessageToList(HotelResource.CityRequired);
                }
                if (TypeValidator.Validate(hotel.Address) == FlowOptions.Failed)
                {
                    result.AddMessageToList(HotelResource.AddressRequired);
                }
                if (TypeValidator.Validate(hotel.Stars) == FlowOptions.Failed)
                {
                    result.AddMessageToList(HotelResource.StarsRequired);
                }
                if (TypeValidator.Validate(hotel.Tax) == FlowOptions.Failed)
                {
                    result.AddMessageToList(HotelResource.TaxRequired);
                }
            }
            return (result.Messages.Count() == 0) ? true : false;
        }

        public Result GetCities()
        {
           
            Result result = new Result();
            List<CityModel> cities = HotelRepository.GetCities();
            if (cities != null && cities.Count > 0)
            {
                result.Data = cities;
                result.FlowControl = FlowOptions.Success;
            }
            else
            {
                result.AddMessageToList(HotelResource.NotCities);
                result.FlowControl = FlowOptions.Nothing;
            }            
            return result;
           
        }

        public Result GetHotels()
        {
            Result result = new Result();
            List<HotelModel> hotels = HotelRepository.GetHotels();
            if (hotels != null && hotels.Count > 0)
            {
                result.Data = hotels;
                result.FlowControl = FlowOptions.Success;
            }
            else
            {
                result.Message = HotelResource.NoHotels;
                result.FlowControl = FlowOptions.Success;
            }
            return result;
        }

        public Result GetHotel(long hotelId)
        {
            Result result = new Result();
            HotelModel hotel = HotelRepository.GetHotel(hotelId);
            if (hotel != null)
            {
                result.Data = hotel;
                result.FlowControl = FlowOptions.Success;
            }
            else
            {
                result.Message = HotelResource.NotFound;
                result.FlowControl = FlowOptions.Nothing;
            }
            return result;
        }

        public Result CreateHotel(HotelModel hotel)
        {
            Result result = new Result();
            if (!IsValidHotel(hotel, result))
            {
                result.FlowControl = FlowOptions.Failed;
                result.Message = result.GetMessages(" - ");
                result.Data = hotel;
                return result;
            }
            HotelModel existsHotel = HotelRepository.ExistsHotel(hotel.Name, hotel.IdCity);
            if (existsHotel != null)
            {
                result.Data = existsHotel;
                result.FlowControl = FlowOptions.Nothing;
                result.Message = HotelResource.ExistsHotel;
                return result;
            }
            HotelModel newHotel = HotelRepository.CreateHotel(hotel);
            if (newHotel != null)
            {
                result.Data = newHotel;
                result.FlowControl = FlowOptions.Success;
            }
            return result;
        }

        public Result UpdateHotel(HotelModel hotel)
        {
            Result result = new Result();
            if (!IsValidHotel(hotel, result))
            {
                result.FlowControl = FlowOptions.Failed;
                result.Message = result.GetMessages(" - ");
                result.Data = hotel;
                return result;
            }
            HotelModel existsHotel = HotelRepository.ExistsHotel(hotel.Name, hotel.IdCity);
            if (existsHotel != null && existsHotel.Id != hotel.Id)
            {
                result.Data = existsHotel;
                result.FlowControl = FlowOptions.Nothing;
                result.Message = HotelResource.ExistsHotel;
                return result;
            }
            HotelModel updatedHotel = HotelRepository.UpdateHotel(hotel);
            if (updatedHotel != null)
            {
                result.Data = updatedHotel;
                result.FlowControl = FlowOptions.Success;
            }
            return result;
        }

        public Result DeleteHotel(long hotelId)
        {
            Result result = new Result();
            HotelModel currentHotel = HotelRepository.GetHotel(hotelId);
            if (currentHotel != null)
            {
                HotelRepository.DeleteHotel(currentHotel);
                result.Message = HotelResource.Deleted;
                result.FlowControl = FlowOptions.Success;
            }
            else
            {
                result.Message = HotelResource.NotFound;
                result.FlowControl = FlowOptions.Nothing;
            }
            return result;
        }
    }
}