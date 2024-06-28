using System;

namespace RMS.Dto
{
    public class SupplierList : Auditable
    {
        public string SupplierName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        private decimal totalAmount;
        public decimal TotalAmount
        {
            get => totalAmount;
            set => totalAmount = Math.Round(value, 2);
        }

        private decimal amount;
        public decimal Amount
        {
            get => amount;
            set => amount = Math.Round(value, 2);
        }

        private decimal dueAmount;
        public decimal DueAmount
        {
            get => dueAmount;
            set => dueAmount = Math.Round(value, 2);
        }

        private decimal paidAmount;
        public decimal PaidAmount
        {
            get => paidAmount;
            set => paidAmount = Math.Round(value, 2);
        }
    }
}
