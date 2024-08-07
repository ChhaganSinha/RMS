﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RMS.Dto
{
    public class Food : Auditable
    {
        public string FoodName { get; set; } = string.Empty;
        public string MenuType { get; set; } = string.Empty;
        public int? MenuTypeId { get; set; }
        public string FoodCategory { get; set; } = string.Empty;
        public int? FoodCategoryId { get; set; }
        public string Variant { get; set; } = string.Empty;
        public int? VariantId { get; set; }

        private decimal price;
        public decimal Price
        {
            get => price;
            set => price = Math.Round(value, 2);
        }

        private decimal taxPercentage;
        public decimal TaxPercentage
        {
            get => taxPercentage;
            set => taxPercentage = Math.Round(value, 2);
        }

        public string CookingTime { get; set; }
        public string ImageName { get; set; } = string.Empty;
        public byte[]? ImageFile { get; set; }
    }
}