using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RMS.Dto
{
    public class AddFood : Auditable
    {
        public string FoodName { get; set; } = string.Empty;
        [Required]
        public string MenuType { get; set; } = string.Empty;
        public int? MenuTypeId { get; set; }
        public string FoodCategory { get; set; } = string.Empty;

        public int? FoodCategoryId { get; set; }
        public string Variant { get; set; } = string.Empty;
        public int? VariantId { get; set; }
        public decimal Price { get; set; } 
        public decimal TaxPercentage { get; set; } 
        public string CookingTime { get; set; }
        public string ImageName { get; set; } = string.Empty;

        public byte[]? ImageFile { get; set; }
    }
}
