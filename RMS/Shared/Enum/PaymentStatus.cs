using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto.Enum
{
    public enum PaymentStatus
    {
        Unknown = 0,
        Pending = 1,
        Success = 2,
        Failed = 3,
        Refunded = 4,
        PartiallyRefunded = 5
    }
}
