using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;

namespace Business.Repository
{
    public class HotelRoomRepository : IHotelRoomRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public HotelRoomRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<HotelRoomDto> CreateHotelRoom(HotelRoomDto hotelRoomDto)
        {
            HotelRoom hotelRoom = _mapper.Map<HotelRoomDto, HotelRoom>(hotelRoomDto);
            hotelRoom.CreatedDateTime = DateTime.Now;
            hotelRoom.CreatedBy = "";
            EntityEntry<HotelRoom> addedHotelRoom = await _db.HotelRooms.AddAsync(hotelRoom);
            await _db.SaveChangesAsync();
            return _mapper.Map<HotelRoom, HotelRoomDto>(addedHotelRoom.Entity);
        }

        public async Task<HotelRoomDto> ReadHotelRoom(int roomId)
        {
            try
            {
                HotelRoomDto hotelRoom = _mapper.Map<HotelRoom, HotelRoomDto>(
                    await _db.HotelRooms.FirstOrDefaultAsync(x => x.Id == roomId));
                return hotelRoom;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<HotelRoomDto>> ReadHotelRooms()
        {
            try
            {
                IEnumerable<HotelRoomDto> hotelRoomDtos =
                    _mapper.Map<IEnumerable<HotelRoom>, IEnumerable<HotelRoomDto>>(_db.HotelRooms);
                return hotelRoomDtos;
            }
            catch
            {
                return null;
            }
        }

        public async Task<HotelRoomDto> UpdateHotelRoom(int roomId, HotelRoomDto hotelRoomDto)
        {
            try
            {
                if (roomId == hotelRoomDto.Id)
                {
                    HotelRoom roomDetails = await _db.HotelRooms.FindAsync(roomId);
                    HotelRoom room = _mapper.Map(hotelRoomDto, roomDetails);
                    room.UpdatedBy = "";
                    room.UpdatedDate = DateTime.UtcNow;
                    EntityEntry<HotelRoom> updatedRoom = _db.HotelRooms.Update(room);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<HotelRoom, HotelRoomDto>(updatedRoom.Entity);
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<int> DeleteHotelRoom(int roomId)
        {
            HotelRoom roomDetails = await _db.HotelRooms.FindAsync(roomId);
            if (roomDetails != null)
            {
                _db.HotelRooms.Remove(roomDetails);
                return await _db.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<HotelRoomDto> IsRoomUnique(string name)
        {
            try
            {
                HotelRoomDto hotelRoom = _mapper.Map<HotelRoom, HotelRoomDto>(
                    await _db.HotelRooms.FirstOrDefaultAsync(x => x.Name == name.ToLower()));
                return hotelRoom;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
