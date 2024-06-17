using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicWebAPI.Models
{
    [Table("medical_record")]
    public class MedicalRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Triệu Chứng Bệnh Không Để Trống")]
        [StringLength(255, ErrorMessage = "Triệu Chứng Bệnh Chứa Tối Đa 255 Ký Tự")]
        public string Symptom { get; set; }

        [Required(ErrorMessage = "Kết Luận Không Để Trống")]
        [StringLength(255, ErrorMessage = "Kết Luận Chứa Tối Đa 255 Ký Tự")]
        public string Conclusion { get; set; }

        public string? Advice { get; set; }

        [DataType(DataType.Text)]
        public string? Note { get; set; }

        [Required(ErrorMessage = "Tiền Khám Bệnh Không Để Trống")]
        [Range(minimum: 10000, maximum: Int64.MaxValue, ErrorMessage = "Tiền Khám Bệnh Không Được Thấp Hơn 10.000")]
        public Decimal ExaminationFee { get; set; }

        public DateTime CreatedDate { get; set; }


        // Many To One
        [ForeignKey("User")]
        [Required(ErrorMessage = "Bác Sỹ Không Để Trống")]
        public string DoctorId { get; set; }
        public User Doctor { get; set; }


        [ForeignKey("User")]
        [Required(ErrorMessage = "Bệnh Nhân Không Để Trống")]
        public string PatientId { get; set; }
        public User Patient { get; set; }


        // One To Many
        ICollection<Invoice> Invoices { get; set; }
    }
}
