using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RMS.Dto
{
    public class CleaningReport : BaseEntity
    {
        [Required]
        public string EmpName { get; set; } = string.Empty;
        public string EmpId { get; set; }
        public string Complete { get; set; } = string.Empty;
       
        public string Pending { get; set; } = string.Empty;
        public string Underprocess { get; set; } = string.Empty;
        
    }
}


