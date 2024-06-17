using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicWebAPI.Models
{
    [Table("user")]
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Họ Và Tên Đệm Không Để Trống")]
        [StringLength(maximumLength: 255, MinimumLength = 10, ErrorMessage = "Độ Dài Của Họ Và Tên Đệm Tối Thiểu Là 10 Ký Tự Và Tối Đa 255 Ký Tự")]

        public string FirstName { get; set; }
        [Required(ErrorMessage = "Tên Không Để Trống")]
        [StringLength(maximumLength: 255, MinimumLength = 10, ErrorMessage = "Độ Dài Của Tên Tối Thiểu Là 10 Ký Tự Và Tối Đa 255 Ký Tự")]
        public string LastName { get; set; }
        public string Avatar { get; set; }
        [Required(ErrorMessage = "Địa Chỉ Không Để Trống")]
        public string Address { get; set; }
        public bool IsActive { get; set; }


        // One To Many
        ICollection<Doctor> Doctors { get; set; }
        ICollection<Schedule> Schedules { get; set; }
        ICollection<Appointment> AppointmentNurses {  get; set; }
        ICollection<Appointment> AppointmentPatients { get; set; }
        ICollection<MedicalRecord> MedicalRecordsDoctors { get; set; }
        ICollection<MedicalRecord> MedicalRecordPatients { get; set; }
        ICollection<Invoice> Invoices { get; set; }


        [NotMapped]
        public static readonly Dictionary<string, string> UserRole = new Dictionary<string, string>
        {
            { "ADMIN", "ADMIN" },
            { "DOCTOR", "DOCTOR" },
            { "NURSE", "NURSE" },
            { "PATIENT", "PATIENT" }
        };

        public User() 
        { 
            this.IsActive = true;
        }
    }
}
