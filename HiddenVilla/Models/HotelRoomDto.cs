using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class HotelRoomDto
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "Please enter room name.")]
        public string Name { get; set; }

        [Required] public int Occupancy { get; set; }

        [Required]
        [Range(1, 3000, ErrorMessage = "Regular rate must be between 1 and 3000.")]
        public double RegularRate { get; set; }

        public string Details { get; set; }
        public string SqFt { get; set; }
        public ICollection<HotelRoomImageDto> HotelRoomImages { get; set; }
        public List<string> ImageUrls { get; set; }
    }
}
