using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto
{
    public class Room : Auditable
    {
        public string Category { get; set; } = string.Empty;
        public string RoomNumber { get; set; } = string.Empty;
        public int NumberOfBed { get; set; }
        public string Facilities { get; set; } = string.Empty;
        public string Descriptions { get; set; } = string.Empty;
        public int Price { get; set; }
        public string BedCharge { get; set; } = string.Empty;
        public string PersonCharge { get; set; } = string.Empty;
        public string Capacity { get; set; } = string.Empty;
        public bool ExtraCapacity { get; set; } 
        public bool IsActive { get; set; } 
        public string ImageName {  get; set; } = string.Empty;
        [NotMapped]
        public byte[] ImageFile { get; set; }
    }
}
