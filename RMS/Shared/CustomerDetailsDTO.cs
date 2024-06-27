using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Dto
{

    public class CustomerDetailsDTO : Auditable
    {
        // Guest Details
        public string CountryCode { get; set; } = string.Empty;

        //[Phone]
        public string MobileNo { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        [Required]
        public string FirstName { get; set; }= string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FatherName { get; set; }= string.Empty;

        public string Gender { get; set; } = string.Empty;

        public string Occupation { get; set; }=string.Empty;

        public DateTime? DateOfBirth { get; set; }

        public DateTime? Anniversary { get; set; }

        public string Nationality { get; set; } = string.Empty;

        public bool IsVIP { get; set; }

        // Contact Details
        public string ContactType { get; set; } = string.Empty;

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
        public string IDNumber { get; set; } = string.Empty;

        public byte[] FrontIdentityImage { get; set; } = new byte[0];

        public byte[] BackIdentityImage { get; set; } = new byte[0];

        public string Comments { get; set; } = string.Empty;

        // Guest Image
        public byte[] GuestImage { get; set; } = new byte[0];
    }

}
