using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto
{
    public class EmployeeAttendance :BaseEntity
    {
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly CheckIn { get; set; }
        public TimeOnly CheckOut { get; set; }
        public TimeSpan StayTime { get; set; }
    }
}
