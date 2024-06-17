using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicWebAPI.Models
{
    [Table("specialization")]
    public class Specialization
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "Tên Khoa Không Để Trống")]
        [StringLength(10, MinimumLength = 255, ErrorMessage = "Tên Khoa Phải Chứa Tối Thiểu 10 Ký Tự Và Tối Đa 255 Ký Tự")]
        public string Name { get; set; }

        public bool IsActive { get; set; }

        // One To Many
        ICollection<Doctor> Doctors { get; set; }
        ICollection<Appointment> Appointments { get; set; }

        public Specialization() 
        { 
            this.IsActive = true;
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
