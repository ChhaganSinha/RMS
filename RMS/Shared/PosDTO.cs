using RMS.Dto.Enum;
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
        public PosStatus Status { get; set; }
        public DateTime CookingTime { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();

        private decimal vatPercentage;
        public decimal VatPercentage
        {
            get => vatPercentage;
            set => vatPercentage = Math.Round(value, 2);
        }

        private decimal vatTax;
        public decimal VatTax
        {
            get => vatTax;
            set => vatTax = Math.Round(value, 2);
        }

        private decimal serviceCharge;
        public decimal ServiceCharge
        {
            get => serviceCharge;
            set => serviceCharge = Math.Round(value, 2);
        }

        private decimal grandTotal;
        public decimal GrandTotal
        {
            get => grandTotal;
            set => grandTotal = Math.Round(value, 2);
        }

        public decimal OriginalTotal
        {
            get
            {
                return OrderItems.Sum(item => item.Total);
            }
        }

        private decimal invoiceDiscount;
        public decimal InvoiceDiscount
        {
            get => invoiceDiscount;
            set => invoiceDiscount = Math.Round(value, 2);
        }

        public void UpdateGrandTotal()
        {
            VatTax = OriginalTotal * (VatPercentage / 100);
            var serviceChargeAmount = OriginalTotal * (ServiceCharge / 100);
            GrandTotal = OriginalTotal + VatTax + serviceChargeAmount - InvoiceDiscount;
            GrandTotal = Math.Round(GrandTotal, 2);  // Ensuring GrandTotal is rounded to 2 decimal places
        }
    }

    public class OrderItemDTO : BaseEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string VariantName { get; set; }

        private decimal price;
        public decimal Price
        {
            get => price;
            set => price = Math.Round(value, 2);
        }

        private decimal vat;
        public decimal VAT
        {
            get => vat;
            set => vat = Math.Round(value, 2);
        }

        public int Quantity { get; set; }

        public decimal Total
        {
            get
            {
                return Math.Round(Price * Quantity, 2);
            }
        }
    }
}
