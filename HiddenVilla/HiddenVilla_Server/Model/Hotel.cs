using System.Collections.Generic;

namespace HiddenVilla_Server.Model
{
    public class Hotel
    {
        public List<BlazorRoom> Rooms { get; set; }
        public List<BlazorAmenity> Amenities { get; set; }
    }
}
