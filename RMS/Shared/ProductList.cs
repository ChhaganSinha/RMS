using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto
{
    public class ProductList : Auditable
    {
        public string ProductName { get; set; } = string.Empty;

       public string ProductCategory{ get; set; } = string.Empty;
        public string UnitNames { get; set; } = string.Empty;
        public int Available { get; set; } 
        public int? ProductCategoryId { get; set; } 
        public int? UnitNamesId { get; set; } 
        public int Used { get; set; } 
        public int Destroyed { get; set; }
        public string Laundry { get; set; } = "No";

    }
}
