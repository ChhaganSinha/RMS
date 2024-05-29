using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Dto
{
    public class HallFacilities : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
