using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RMS.Dto
{
    public class RoomCleaningAssignmentModel : Auditable
    {
       
        public string HouseKeeper { get; set; } = string.Empty;
        public string RoomType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public List<RoomModel> SelectedRooms { get; set; } = new List<RoomModel>();
    }

    public class RoomModel : BaseEntity
    {
        public string RoomNo { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public DateTime DateTime { get; set; }
        public bool IsSelected { get; set; } = false;
    }
}


