using System.ComponentModel.DataAnnotations;

namespace ClinicWebAPI.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Username Không Để Trống")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password Không Để Trống")]
        public string Password { get; set; }
    }
}
