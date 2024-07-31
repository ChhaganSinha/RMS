using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RMS.Dto
{
    public class RoomCleaningAssignmentModel : Auditable
    {
       public int HouseKeeperId { get; set; }
        public string HouseKeeper { get; set; } = string.Empty;
        public string RoomType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime ? StartDate { get; set; }
        public DateTime ? EndDate { get; set; }
        public List<RoomModel> SelectedRooms { get; set; } = new List<RoomModel>();
        public string RoomNo { get; set; } = string.Empty;
        public bool IsSelected { get; set; } = false;
    }

    public class RoomModel : BaseEntity
    {
        public int RoomId { get; set; }
        public string RoomNo { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public DateTime ? StartDate { get; set; }
        public DateTime ? EndDate { get; set; }
        public bool IsSelected { get; set; } = false;
    }
}


