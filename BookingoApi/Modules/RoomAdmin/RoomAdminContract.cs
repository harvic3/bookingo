using BookingoApi.Modules.AppSettings;
using BoxAgileDev;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingoApi.Modules.RoomAdmin
{
    public class RoomAdminContract
    {
        private IRoomAdmin _roomRepository;
        private IRoomAdmin RoomRepository
        {
            get
            {
                _roomRepository = _roomRepository ?? ModuleManager.Kernel.Get<IRoomAdmin>();
                return _roomRepository;
            }
        }

        private bool IsValidRoom(RoomModel room, Result result)
        {
            if (TypeValidator.Validate(room) == FlowOptions.Failed)
            {
                result.AddMessageToList(RoomResources.NotValid);
            }
            else
            {
                if (TypeValidator.Validate(room.IdHotel) == FlowOptions.Failed)
                {
                    result.AddMessageToList(RoomResources.HotelRequired);
                }
                if (TypeValidator.Validate(room.Code) == FlowOptions.Failed)
                {
                    result.AddMessageToList(RoomResources.CodeRequired);
                }
                if (TypeValidator.Validate(room.Guests) == FlowOptions.Failed)
                {
                    result.AddMessageToList(RoomResources.GuestsRequired);
                }
                if (TypeValidator.Validate(room.Price) == FlowOptions.Failed)
                {
                    result.AddMessageToList(RoomResources.PriceRequired);
                }
                if (TypeValidator.Validate(room.Tax) == FlowOptions.Failed)
                {
                    result.AddMessageToList(RoomResources.TaxRequired);
                }
            }
            return (result.Messages.Count() == 0) ? true : false;
        }

        public Result GetRoom(long roomId)
        {
            Result result = new Result();
            RoomModel recRoom = RoomRepository.GetRoom(roomId);
            if (recRoom != null)
            {
                result.Data = recRoom;
            }
            else
            {
                result.Message = RoomResources.NotFound;
                result.FlowControl = FlowOptions.Nothing;
            }
            return result;
        }

        public Result CreateRoom(RoomModel room)
        {
            Result result = new Result();
            if (!IsValidRoom(room, result))
            {
                result.FlowControl = FlowOptions.Failed;
                result.Message = result.GetMessages(" - ");
                result.Data = room;
                return result;
            }
            RoomModel existsRoom = RoomRepository.ExistsRoom(room.IdHotel, room.Code);
            if (existsRoom != null)
            {
                result.Data = existsRoom;
                result.FlowControl = FlowOptions.Nothing;
                result.Message = RoomResources.RoomExists;
                return result;
            }
            RoomModel createdRoom = RoomRepository.CreateRoom(room);
            if (createdRoom != null)
            {
                result.Data = createdRoom;
                result.Message = RoomResources.Created;
            }
            return result;
        }

        public Result UpdateRoom(RoomModel room)
        {
            Result result = new Result();
            if (!IsValidRoom(room, result))
            {
                result.FlowControl = FlowOptions.Failed;
                result.Message = result.GetMessages(" - ");
                result.Data = room;
                return result;
            }
            RoomModel existsRoom = RoomRepository.ExistsRoom(room.IdHotel, room.Code);
            if (existsRoom != null && existsRoom.Id != room.Id)
            {
                result.Data = existsRoom;
                result.FlowControl = FlowOptions.Nothing;
                result.Message = RoomResources.RoomExists;
                return result;
            }
            RoomModel updatedRoom = RoomRepository.UpdateRoom(room);
            if (updatedRoom != null)
            {
                result.Data = updatedRoom;
                result.Message = RoomResources.Updated;
            }
            return result;
        }

        public Result DeleteRoom(long roomId)
        {
            Result result = new Result();
            RoomModel currentRoom = RoomRepository.GetRoom(roomId);
            if (currentRoom != null)
            {
                RoomRepository.DeleteRoom(currentRoom);
                result.Message = RoomResources.Deleted;
                result.FlowControl = FlowOptions.Success;
            }
            else
            {
                result.Message = RoomResources.NotFound;
                result.FlowControl = FlowOptions.Nothing;
            }
            return result;
        }
    }
}