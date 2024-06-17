using System;
using System.ComponentModel.DataAnnotations;

namespace RMS.Dto
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DateRangeValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var leave = (Leave)validationContext.ObjectInstance;

            if (leave.ApplicationStartDate > leave.ApplicationEndDate)
            {
                return new ValidationResult("Application Start Date cannot be greater than Application End Date", new[] { nameof(leave.ApplicationStartDate), nameof(leave.ApplicationEndDate) });
            }

            if (leave.ApproveStartDate > leave.ApproveEndDate)
            {
                return new ValidationResult("Approve Start Date cannot be greater than Approve End Date", new[] { nameof(leave.ApproveStartDate), nameof(leave.ApproveEndDate) });
            }

            return ValidationResult.Success;
        }
    }

    [DateRangeValidation]
    public class Leave : Auditable
    {
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;

       // [Required(ErrorMessage = "Leave Type is required")]
        public int? LeaveTypeId { get; set; }
        public string LeaveType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Application Start Date is required")]
        public DateTime ApplicationStartDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Application End Date is required")]
        public DateTime ApplicationEndDate { get; set; } = DateTime.Now.AddDays(2);

        public int ApplyDaysCount { get; set; }
        public string ApplicationHardCopy { get; set; } = string.Empty;
        public byte[]? ApplicationHardCopyByteData { get; set; }

        [Required(ErrorMessage = "Approve Start Date is required")]
        public DateTime ApproveStartDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Approve End Date is required")]
        public DateTime ApproveEndDate { get; set; } = DateTime.Now.AddDays(2);

        public int ApproveDaysCount { get; set; }

        public string ApprovedBy { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
    }
}
