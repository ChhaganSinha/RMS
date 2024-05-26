using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto
{
    public class Room : Auditable
    {
        public RoomCategories Category { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public int NumberOfBed { get; set; }
        public RoomFacilities Facilities { get; set; }
        public string Descriptions { get; set; } = string.Empty;
        public int Price { get; set; }
        public string BedCharge { get; set; } = string.Empty;
        public string PersonCharge { get; set; } = string.Empty;
        public string Capacity { get; set; } = string.Empty;
        public bool ExtraCapacity { get; set; } 
        public string ImageName {  get; set; } = string.Empty;
    }
}
