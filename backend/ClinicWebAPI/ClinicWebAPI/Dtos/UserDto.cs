using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ClinicWebAPI.Dtos
{
    public class UserDto
    {
        [AllowNull]
        public string? Id { get; set; }
        [Required(ErrorMessage = "Username Đệm Không Để Trống")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mật Khẩu Đệm Không Để Trống")]
        [RegularExpression(pattern: "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "Mật Khẩu Ít Nhất 8 Ký Tự Và Phải Chứa Ít Nhất 1 Ký Tự Chữ Thường, 1 Ký Tự Chữ Hoa, 1 Ký Tự Chữ Số và 1 Ký Tự Đặc Biệt")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Họ Và Tên Đệm Không Để Trống")]
        [StringLength(maximumLength: 255, MinimumLength = 3, ErrorMessage = "Độ Dài Của Họ Và Tên Đệm Tối Thiểu Là 10 Ký Tự Và Tối Đa 255 Ký Tự")]

        public string FirstName { get; set; }
        [Required(ErrorMessage = "Tên Không Để Trống")]
        [StringLength(maximumLength: 255, MinimumLength = 3, ErrorMessage = "Độ Dài Của Tên Tối Thiểu Là 10 Ký Tự Và Tối Đa 255 Ký Tự")]
        public string LastName { get; set; }
        [AllowNull]
        public string? Avatar { get; set; }
        [Required(ErrorMessage = "Địa Chỉ Không Để Trống")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Số Điện Thoại Không Để Trống")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email Không Để Trống")]
        [EmailAddress(ErrorMessage = "Email Không Hợp Lệ")]
        public string Email { get; set; }
        public IFormFile Image { get; set; }


        public UserDto()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
