using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto
{
    public class RoomFacilitiesMapping : BaseEntity
    {
        public int RoomId { get; set; }
        public int FacilityId { get; set; }
    }
}
