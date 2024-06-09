using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto
{
    public class Leave : Auditable
    {
        public string EmployeeName { get; set; }
        public string LeaveType { get; set; }

        public DateTime ApplicationStartDate { get; set; }
        public DateTime ApplicationEndDate { get; set; }
        public int ApplyDaysCount { get; set; }
        public string ApplicationHardCopy { get; set; }
        public byte[] ApplicationHardCopyByteData { get; set; }

        public DateTime ApproveStartDate { get; set; }
        public DateTime ApproveEndDate { get; set; }

        public int ApproveDaysCount { get; set; }

        public string ApprovedBy { get; set; }
        public string Reason { get; set; }

    }
}
