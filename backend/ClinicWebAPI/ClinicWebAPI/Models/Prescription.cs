using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicWebAPI.Models
{
    [Table("prescription")]
    public class Prescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Liều Lượng Không Để Trống")]
        public string Dosage { get; set; }


        [Required(ErrorMessage = "Tần Suất Dùng Thuốc Không Để Trống")]
        public string Frequency { get; set; }


        [Required(ErrorMessage = "Thời Gian Dùng Thuốc không Để Trống")]
        public string Duration { get; set; }


        [Required(ErrorMessage = "Số Lượng Không Để Trống")]
        [Range(minimum: 1, maximum: long.MaxValue, ErrorMessage = "Số Lượng Thuốc Phải Tối Thiểu là 1 đơn vị")]
        public int TotalUnit { get; set; }

        [Required(ErrorMessage = "Giá Thuốc Không Để Trống")]
        [Range(minimum: 10000, maximum: long.MaxValue, ErrorMessage = "Giá Thuốc Phải Tối Thiểu là 10.000")]
        public Decimal MedicinePrice { get; set; }


        // Many To One
        [ForeignKey("Medicine")]
        [Required(ErrorMessage = "Thuốc Không Để Trống")]
        public string MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        [ForeignKey("MedicalRecord")]
        [Required()]
        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
    }
}
