using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Business.Repository
{
    public class HotelRoomImageRepository : IHotelRoomImageRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public HotelRoomImageRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> CreateHotelRoomImage(HotelRoomImageDto imageDto)
        {
            HotelRoomImage image = _mapper.Map<HotelRoomImageDto, HotelRoomImage>(imageDto);
            await _db.HotelRoomImages.AddAsync(image);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteHotelRoomImage(int imageId)
        {
            HotelRoomImage image = await _db.HotelRoomImages.FindAsync(imageId);
            _db.HotelRoomImages.Remove(image);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteHotelRoomImageByRoomId(int roomId)
        {
            List<HotelRoomImage> imageList = await _db.HotelRoomImages.Where(x => x.RoomId == roomId).ToListAsync();
            _db.HotelRoomImages.RemoveRange(imageList);
            return await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<HotelRoomImageDto>> GetHotelRoomImages(int roomId)
        {
            return _mapper.Map<IEnumerable<HotelRoomImage>, IEnumerable<HotelRoomImageDto>>(
                await _db.HotelRoomImages.Where(x => x.RoomId == roomId).ToListAsync());
        }
    }
}
