using RMS.Dto.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto
{
    public class BookingList : Auditable
    {
        public string BookingNumber { get; set; }
        public int ? RoomTypeId { get; set; }
        public string RoomType { get; set; }
        public string RoomNumber { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

    }
}
