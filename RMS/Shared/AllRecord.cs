using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RMS.Dto
{
    public class AllRecord : BaseEntity
    {
        [Required]
        public string EmpName { get; set; } = string.Empty;
        public int RoomNo { get; set; }
        public string RoomType { get; set; } = string.Empty;
        public DateTime StartTime { get; set; } 
        public DateTime EndTime { get; set; } 
        public string CheckList { get; set; } = string.Empty;
        public string ProductList { get; set; } = string.Empty;
        public string Quality { get; set; } = string.Empty;
        public string AssignBy { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}


