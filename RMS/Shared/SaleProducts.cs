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
        public int? ProductNameId { get; set; }
        public string ProductCategory { get; set; } = string.Empty;
        public int? ProductCategoryId { get; set; }
        public int Quantity { get; set; }

        private decimal price;
        public decimal Price { get => price; set => price = Math.Round(value, 2); }

        public string Comments { get; set; } = string.Empty;

    }
}
