using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto
{
    public class LeaveType : BaseEntity
    {
        public string TypeName { get; set; }
        public int LeaveDays { get; set; }
    }
}
