using System.ComponentModel.DataAnnotations;

namespace RMS.Dto.Auth
{
    public class ForgetPasswordRequest
    {
        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
    }
}
