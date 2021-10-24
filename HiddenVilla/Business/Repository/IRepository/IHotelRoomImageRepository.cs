using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Business.Repository.IRepository
{
    public interface IHotelRoomImageRepository
    {
        public Task<int> CreateHotelRoomImage(HotelRoomImageDto image);
        public Task<int> DeleteHotelRoomImage(int imageId);
        public Task<int> DeleteHotelRoomImageByRoomId(int roomId);
        public Task<IEnumerable<HotelRoomImageDto>> GetHotelRoomImages(int roomId);
    }
}
