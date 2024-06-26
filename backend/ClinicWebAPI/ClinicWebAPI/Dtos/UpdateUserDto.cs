using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ClinicWebAPI.Dtos
{
    public class UpdateUserDto
    {
        public string? Id { get; set; }

        public string FirstName { get; set; }
        [Required(ErrorMessage = "Tên Không Để Trống")]
        [StringLength(maximumLength: 255, MinimumLength = 3, ErrorMessage = "Độ Dài Của Tên Tối Thiểu Là 10 Ký Tự Và Tối Đa 255 Ký Tự")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Địa Chỉ Không Để Trống")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Số Điện Thoại Không Để Trống")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email Không Để Trống")]
        [EmailAddress(ErrorMessage = "Email Không Hợp Lệ")]
        public string Email { get; set; }

    }
}
