using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Dto
{
    public class RoomFacilities : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
