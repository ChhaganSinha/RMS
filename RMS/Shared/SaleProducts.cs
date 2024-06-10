using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto
{
    public class SaleProducts : Auditable
    {
        public string ProductName { get; set; } = string.Empty;

        public string ProductCategory { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Comments { get; set; } = string.Empty;

    }
}
