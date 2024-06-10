using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto
{
    public class SupplierList : Auditable
    {
        public string SupplierName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public double TotalAmount { get; set; }
        public double Amount { get; set; }
        public double DueAmount { get; set; }
        public double PaidAmount { get; set; }
       
    }
}
