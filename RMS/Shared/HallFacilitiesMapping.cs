using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto
{
    public class HallFacilitiesMapping : BaseEntity
    {
        public int HallId { get; set; }
        public int FacilityId { get; set; }
    }
}
