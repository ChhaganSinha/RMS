using RMS.Dto.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Dto
{
    public class TableCon : BaseEntity
    {
        [Required]
        public int TableNumber { get; set; }
        public int TableCapacity { get; set; }
        public TableStatus Status   { get; set; }

    }
}
