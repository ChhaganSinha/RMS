using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto
{
    public class Leave : Auditable
    {
        public int ? EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        [Required]
        public int ? LeaveTypeId { get; set; }
        public string LeaveType { get; set; } = string.Empty;

        public DateTime ApplicationStartDate { get; set; } = DateTime.Now;
        public DateTime ApplicationEndDate { get; set; } = DateTime.Now.AddDays(2);
        public int ApplyDaysCount { get; set; } = 2;
        public string ApplicationHardCopy { get; set; } = string.Empty;
        public byte[] ? ApplicationHardCopyByteData { get; set; }

        public DateTime ApproveStartDate { get; set; } = DateTime.Now;
        public DateTime ApproveEndDate { get; set; } = DateTime.Now.AddDays(2);

        public int ApproveDaysCount { get; set; } = 2;

        public string ApprovedBy { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;

    }
}
