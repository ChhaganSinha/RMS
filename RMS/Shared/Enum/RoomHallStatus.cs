﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto.Enum
{
    public enum RoomHallStatus
    {
        Available,
        Ready,
        Booked,
        AssignedToClean,
        BookedAndAssignedToClean,
        UnderMaintenance,
        Dirty,
        Blocked,
        DoNotReserve,
        UnderProcess
    }
}
