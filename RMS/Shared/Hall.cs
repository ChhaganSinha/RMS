using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto
{
    public class Hall :Auditable
    {
        public string Category { get; set; } = string.Empty;
        public string HallNumber { get; set; } = string.Empty;
        public string HallSize { get; set; } = string.Empty;
        public string Facilities { get; set; } = string.Empty;
        public string Descriptions { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Capacity { get; set; } = string.Empty;
        public bool ExtraCapacity { get; set; }
        public string ImageName { get; set; } = string.Empty;
    }
}
