using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto
{
    public class AdvanceSalary : BaseEntity
    {
        public int ? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        [Required]
        public decimal AdvanceAmount { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; }
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime ModifiedDate { get; set; }
    }
}
