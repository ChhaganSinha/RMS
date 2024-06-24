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
        public string CountryCode { get; set; }

        //[Phone]
        public string MobileNo { get; set; }

        public string Title { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }

        public string Gender { get; set; }

        public string Occupation { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? Anniversary { get; set; }

        public string Nationality { get; set; }

        public bool IsVIP { get; set; }

        // Contact Details
        public string ContactType { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Zipcode { get; set; }

        public string Address { get; set; }

        // Identity Details
        public string IdentityType { get; set; }

        [Required]
        public string IDNumber { get; set; }

        public byte[] FrontIdentityImage { get; set; } = new byte[0];

        public byte[] BackIdentityImage { get; set; } = new byte[0];

        public string Comments { get; set; }

        // Guest Image
        public byte[] GuestImage { get; set; } = new byte[0];
    }

}
