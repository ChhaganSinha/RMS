using RMS.Dto.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RMS.Dto
{
    public class PosDTO : Auditable
    {
        public int ? CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerType { get; set; } = string.Empty;
        public int ? EmployeeId { get; set; }
        public string Employee { get; set; } = string.Empty;
        public int ? TableId { get; set; }
        public string Table { get; set; }
        public PosStatus Status { get; set; }
        public string CookingTime { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();

        private decimal vatPercentage;
        public decimal VatPercentage
        {
            get => vatPercentage;
            set
            {
                if (vatPercentage != value)
                {
                    vatPercentage = Math.Round(value, 2);
                    UpdateGrandTotal();
                }
            }
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
            set
            {
                if (serviceCharge != value)
                {
                    serviceCharge = Math.Round(value, 2);
                    UpdateGrandTotal();
                }
            }
        }

        private decimal grandTotal;
        public decimal GrandTotal
        {
            get => grandTotal;
            set => grandTotal = Math.Round(value, 2);
        }

        private decimal invoiceDiscount;
        public decimal InvoiceDiscount
        {
            get => invoiceDiscount;
            set
            {
                if (invoiceDiscount != value)
                {
                    invoiceDiscount = Math.Round(value, 2);
                    UpdateGrandTotal();
                }
            }
        }

        public decimal OriginalTotal
        {
            get
            {
                return OrderItems.Sum(item => item.Price * item.Quantity);
            }
        }

        private void UpdateGrandTotal()
        {
            var originalTotal = OrderItems.Sum(item => item.Price * item.Quantity);
            var totalVAT = OrderItems.Sum(item => (item.Price * (item.VAT / 100)) * item.Quantity);

            VatTax = totalVAT;
            var serviceChargeAmount = originalTotal * (ServiceCharge / 100);

            GrandTotal = originalTotal + VatTax + serviceChargeAmount;
        }

    }

    public class OrderItemDTO : BaseEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string VariantName { get; set; } = string.Empty;

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
                return (Price + (Price * (VAT / 100))) * Quantity;
            }
        }
    }
}
