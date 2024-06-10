using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RMS.Dto
{
    public class RoomCleaning : BaseEntity
    {
       
        public string EmpId { get; set; } = string.Empty;

       
        public string Name { get; set; } = string.Empty;

        [Required]
        public int RoomNo { get; set; }

        [Required]
        public string AssignTo { get; set; } = string.Empty;

        [Required]
        public DateTime DateStart { get; set; }

        [Required]
        public DateTime DateEnd { get; set; }

        public string Status { get; set; } = string.Empty;

        //public string CheckList { get; set; } = string.Empty;

        //public List<string> CheckListItems
        //{
        //    get
        //    {
        //        return string.IsNullOrEmpty(CheckList) ? new List<string>() : new List<string>(CheckList.Split(','));
        //    }
        //    set
        //    {
        //        CheckList = string.Join(",", value);
        //    }
        //}

    }
}