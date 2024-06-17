using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicWebAPI.Models
{
    [Table("appointment")]
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Ngày Khám Không Để Trống")]
        public DateTime AppointmentDate { get; set; }

        [DataType(DataType.Text)]
        public string? Description { get; set; }

        [DefaultValue("WAITTING")]
        [AllowedValues(values: ["WAITTING", "COMPLETED", "CANCLED"], ErrorMessage = "Trạng Thái Lịch Hẹn Không Hợp Lệ")]
        public string AppointmentStatus { get; set; }


        [NotMapped]
        public static readonly Dictionary<string, string> Status = new Dictionary<string, string>
        {
            { "WAITTING", "WAITTING" },
            { "COMPLETED", "COMPLETED" },
            { "CANCLED", "CANCLED" }

        };

        // Many To One
        [ForeignKey("User")]
        public string? NurseId { get; set; }
        public User? Nurse { get; set; }

        [ForeignKey("User")]
        [Required(ErrorMessage = "Bệnh Nhân Không Để Trống")]
        public string PatientId { get; set; }
        public User Patient { get; set; }

        [ForeignKey("Specialization")]
        public string SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
    }
}
