﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace RMS.Dto
{
    public class RoomFacilities : Auditable
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
