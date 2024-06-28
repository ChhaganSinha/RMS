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
        public DateTime PurchaseDate { get; set; } = DateTime.Now;

        //[Required]
        public DateTime ExpiryDate { get; set; } = DateTime.Now.AddDays(30);

        public string Details { get; set; } = string.Empty;

        public List<ItemDto> Items { get; set; } = new List<ItemDto>();

        private decimal grandTotal;
        public decimal GrandTotal
        {
            get => grandTotal;
            set => grandTotal = Math.Round(value, 2);
        }

        public bool IsPaid { get; set; } = false;
    }

    public class ItemDto : BaseEntity
    {
        //[Required]
        public int PurchaseItemId { get; set; }

        //[Required]
        public string ItemName { get; set; } = string.Empty;

        private decimal stock;
        [Range(0, double.MaxValue, ErrorMessage = "Stock must be a non-negative number")]
        public decimal Stock
        {
            get => stock;
            set => stock = Math.Round(value, 2);
        }

        private decimal quantity;
        [Range(0, double.MaxValue, ErrorMessage = "Quantity must be a non-negative number")]
        public decimal Quantity
        {
            get => quantity;
            set => quantity = Math.Round(value, 2);
        }

        private decimal rate;
        [Range(0, double.MaxValue, ErrorMessage = "Rate must be a non-negative number")]
        public decimal Rate
        {
            get => rate;
            set => rate = Math.Round(value, 2);
        }

        public decimal Total => Math.Round(Quantity * Rate, 2);

        public void UpdateTotal()
        {
            // Optional: Implement logic to update total if needed
        }
    }
}
