using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RMS.Dto
{
    public class HallFacilities : Auditable
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
