﻿using System;

namespace RMS.Dto
{
    public class Auditable : BaseEntity
    {
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime ModifiedOn { get; set; }
    }
}
