using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicWebAPI.Models
{
    [Table("medicine")]
    public class Medicine
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "Tên Thuốc Không Để Trống")]
        [StringLength(maximumLength: 255, MinimumLength = 10, ErrorMessage = "Tên Thuốc Phải Chứa Ít Nhất 10 Ký Tự Và Tối Đa 255 Ký Tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Giá Thuốc Không Để Trống")]
        [Range(minimum: 10000, maximum: Int64.MaxValue, ErrorMessage = "Giá Thuốc Không Được Thấp Hơn 10.000")]
        [DefaultValue(10000)]
        public Decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Số Lượng Thuốc Không Để Trống")]
        [Range(minimum: 0, maximum: Int64.MaxValue, ErrorMessage = "Số Lượng Thuốc Không Hợp Lệ")]
        [DefaultValue(1)]
        public int UnitInStock { get; set; }

        [Required(ErrorMessage = "Đơn Vị Thuốc Không Để Trống")]
        [StringLength(maximumLength: 255, MinimumLength = 1, ErrorMessage = "Đơn Vị Thuốc Phải Chứa Ít Nhất 1 Ký Tự Và Tối Đa 255 Ký Tự")]
        [DefaultValue("Viên")]
        public string UnitMedicine { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool IsActive { get; set; }

        [NotMapped]
        public static List<string> UnitMedicineList = new List<string>
        {
            "Viên", "Gói", "Chai"
        };


        // Many To One
        [ForeignKey("Category")]
        [Required(ErrorMessage = "Loại Thuốc Không Để Trống")]
        public string CategoryId { get; set; }
        public Category Category { get; set; }


        // One To Many
        ICollection<Prescription> Prescriptions { get; set; }

        public Medicine() 
        { 
            this.IsActive = true;
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
