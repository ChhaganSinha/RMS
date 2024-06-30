using System;
using System.Collections.Generic;
using System.Linq;

namespace RMS.Dto
{
    public class PosDTO : Auditable
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerType { get; set; }
        public int EmployeeId { get; set; }
        public string Employee { get; set; }
        public int TableId { get; set; }
        public int Table { get; set; }
        public DateTime CookingTime { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();

        // New properties added for calculations
        public decimal VatPercentage { get; set; }  // VAT percentage
        public decimal VatTax { get; set; }         // Calculated VAT tax
        public decimal ServiceCharge { get; set; }  // Service charge percentage
        public decimal GrandTotal { get; set; }     // Calculated grand total
        public decimal OriginalTotal
        {
            get
            {
                return OrderItems.Sum(item => item.Total);
            }
        }
        public decimal InvoiceDiscount { get; set; } // Assuming this is a discount amount

        public void UpdateGrandTotal()
        {
            VatTax = OriginalTotal * (VatPercentage / 100);
            var serviceChargeAmount = OriginalTotal * (ServiceCharge / 100);
            GrandTotal = OriginalTotal + VatTax + serviceChargeAmount;
        }
    }

    public class OrderItemDTO : BaseEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string VariantName { get; set; }
        public decimal Price { get; set; }
        public decimal VAT { get; set; }
        public int Quantity { get; set; }
        public decimal Total
        {
            get
            {
                return Price * Quantity;
            }
        }
    }
}
