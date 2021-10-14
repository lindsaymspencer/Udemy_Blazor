using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Business.Repository.IRepository
{
    public interface IHotelRoomRepository
    {
        public Task<HotelRoomDto> CreateHotelRoom(HotelRoomDto hotelRoomDto);
        public Task<HotelRoomDto> ReadHotelRoom(int roomId);
        public Task<IEnumerable<HotelRoomDto>> ReadHotelRooms();
        public Task<HotelRoomDto> UpdateHotelRoom(int roomId, HotelRoomDto hotelRoomDto);
        public Task<int> DeleteHotelRoom(int roomId);
        public Task<HotelRoomDto> IsRoomUnique(string name);
    }
}
