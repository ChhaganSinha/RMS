using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto
{
    public class LeaveType : BaseEntity
    {
        [Required]
        public string TypeName { get; set; } = string.Empty;
        [Required]
        public int LeaveDays { get; set; }
    }
}
