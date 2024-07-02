using RMS.Dto.Enum;
using System;
using System.Collections.Generic;

namespace RMS.Dto
{
    public class ReservationDetailsDto : Auditable
    {
        public DateTime CheckIn { get; set; } = DateTime.Now;
        public DateTime CheckOut { get; set; } = DateTime.Now;
        public string ArrivalFrom { get; set; } = string.Empty;
        public BookingReferenceType BookingType { get; set; }
        public string BookingReferenceNo { get; set; } = string.Empty;
        public string PurposeOfVisit { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public List<RoomBookingDto> RoomBookings { get; set; } = new List<RoomBookingDto>();
        public List<CustomerInfoDto> CustomerInfo { get; set; } = new List<CustomerInfoDto>();
        public PaymentDetailsDto PaymentDetails { get; set; } = new PaymentDetailsDto();
        public BillingDetailsDto BillingDetails { get; set; } = new BillingDetailsDto();
    }

    public class RoomBookingDto : BaseEntity
    {
        public RoomType RoomType { get; set; }
        public int ? roomId { get; set; }
        public string RoomNo { get; set; } = string.Empty;
        public int Adults { get; set; }
        public int Children { get; set; }
    }

    public class CustomerInfoDto : BaseEntity
    {
        public int SL { get; set; }
        public string Name { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public class PaymentDetailsDto : BaseEntity
    {
        public string DiscountReason { get; set; } = string.Empty;

        private decimal discountRate;
        public decimal DiscountRate
        {
            get => discountRate;
            set => discountRate = Math.Round(value, 2);
        }

        private decimal discountAmount;
        public decimal DiscountAmount
        {
            get => discountAmount;
            set => discountAmount = Math.Round(value, 2);
        }

        private decimal commissionRate;
        public decimal CommissionRate
        {
            get => commissionRate;
            set => commissionRate = Math.Round(value, 2);
        }

        private decimal commissionAmount;
        public decimal CommissionAmount
        {
            get => commissionAmount;
            set => commissionAmount = Math.Round(value, 2);
        }
    }

    public class BillingDetailsDto : BaseEntity
    {
        private decimal bookingCharge;
        public decimal BookingCharge
        {
            get => bookingCharge;
            set => bookingCharge = Math.Round(value, 2);
        }

        private decimal tax;
        public decimal Tax
        {
            get => tax;
            set => tax = Math.Round(value, 2);
        }

        private decimal serviceCharge;
        public decimal ServiceCharge
        {
            get => serviceCharge;
            set => serviceCharge = Math.Round(value, 2);
        }

        private decimal totalCharge;
        public decimal TotalCharge
        {
            get => totalCharge;
            set => totalCharge = Math.Round(value, 2);
        }
    }
}
