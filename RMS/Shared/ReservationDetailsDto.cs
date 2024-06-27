using RMS.Dto.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto
{
    public class ReservationDetailsDto : Auditable
    {

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string ArrivalFrom { get; set; } = string.Empty;
        public BookingReferenceType BookingType { get; set; }
        public string BookingReferenceNo { get; set; } = string.Empty;
        public string PurposeOfVisit { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public List<RoomBookingDto> RoomBookings { get; set; }
        public List<CustomerInfoDto> CustomerInfo { get; set; }
        public PaymentDetailsDto PaymentDetails { get; set; }
        public BillingDetailsDto BillingDetails { get; set; }
    }

    public class RoomBookingDto : BaseEntity
    {
        public RoomType RoomType { get; set; }
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
        public decimal DiscountRate { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal CommissionRate { get; set; }
        public decimal CommissionAmount { get; set; }
    }

    public class BillingDetailsDto :BaseEntity
    {
        public decimal BookingCharge { get; set; }
        public decimal Tax { get; set; }
        public decimal ServiceCharge { get; set; }
        public decimal TotalCharge { get; set; }
    }



}
