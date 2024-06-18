using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RMS.Dto
{
    public class RoomCleaning : BaseEntity
    {

        public int? EmployeeId { get; set; }
        public string EmpId { get; set; } = string.Empty;

       
        public string Name { get; set; } = string.Empty;

        [Required]
        public int RoomNo { get; set; }

 
        public string AssignTo { get; set; } = string.Empty;

        [Required]
        public DateTime DateStart { get; set; } = DateTime.Now;

        [Required]
        public DateTime DateEnd { get; set; } = DateTime.Now;

        public string Status { get; set; } = string.Empty;

       

    }
}