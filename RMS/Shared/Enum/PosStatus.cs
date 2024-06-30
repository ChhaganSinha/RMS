using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto.Enum
{
    public enum BookingStatus
    {
        Unknown = 0,
        Pending = 1,
        Booked = 2,
        Cancelled = 3,
        CheckedIn = 4,
        CheckedOut = 5
    }
}
