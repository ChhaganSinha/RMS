using RMS.Dto.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.Dto
{
    public class TableCon : BaseEntity
    {
        [Required]
        //[GreaterThanZero]
        public string TableNumber { get; set; } = string.Empty;

        [Required]
        [GreaterThanZero]
        public int TableCapacity { get; set; }

        public TableStatus Status { get; set; }
    }


    public class GreaterThanZeroAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int intValue && intValue > 0)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("The field must be greater than zero.");
        }
    }
}
