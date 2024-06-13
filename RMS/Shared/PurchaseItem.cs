using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RMS.Dto
{
    public class PurchaseItem : Auditable
    {
       
        public string SupplierName { get; set; } = string.Empty;
        public int? SupplierNameId { get; set; }

        //[Required]
        public string InvoiceNo { get; set; } = string.Empty;

        //[Required]
        public DateTime PurchaseDate { get; set; }

        //[Required]
        public DateTime ExpiryDate { get; set; }

        public string Details { get; set; } = string.Empty;

        public List<ItemDto> Items { get; set; } = new List<ItemDto>();

        public decimal GrandTotal { get; set; }

        public bool IsPaid { get; set; } = false;
    }

    public class ItemDto : BaseEntity
    {
        //[Required]
        public int PurchaseItemId { get; set; }

        //[Required]
        public string ItemName { get; set; } = string.Empty;

        //[Required]
        [Range(0, double.MaxValue, ErrorMessage = "Stock must be a non-negative number")]
        public decimal Stock { get; set; }

        //[Required]
        [Range(0, double.MaxValue, ErrorMessage = "Quantity must be a non-negative number")]
        public decimal Quantity { get; set; }

        //[Required]
        [Range(0, double.MaxValue, ErrorMessage = "Rate must be a non-negative number")]
        public decimal Rate { get; set; }

        public decimal Total => Quantity * Rate;

        public void UpdateTotal()
        {
           
        }
    }
}
