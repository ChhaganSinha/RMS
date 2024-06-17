using RMS.Dto.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace RMS.Dto
{
    public class CustomerDetails : Auditable
    {
        // Guest Details
        [Required]
        public string CountryCode { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string MobileNo { get; set; } = string.Empty;

        [Required]
        public CustomerTitle Title { get; set; } = CustomerTitle.Mr;

        [Required]
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FatherName { get; set; } = string.Empty;

        [Required]
        public string Gender { get; set; } = "Male"; // Assume default as "Male"

        public string Occupation { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Anniversary { get; set; }

        public string Nationality { get; set; } = string.Empty;

        public bool IsVIP { get; set; } = false;

        // Contact Details
        public string ContactType { get; set; } = "Email"; // Assume default as "Email"

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Zipcode { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        // Identity Details
        public string IdentityType { get; set; } = string.Empty;

        [Required]
        public string IdentityNumber { get; set; } = string.Empty;

        public byte[]? IdentityFront { get; set; }

        public byte[]? IdentityBack { get; set; }

        // Additional Details
        public string Comments { get; set; } = string.Empty;

        public byte[]? GuestImage { get; set; }
    }
}
