using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicWebAPI.Models
{
    [Table("room")]
    public class Room
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "Tên Phòng Không Để Trống")]
        [StringLength(10, MinimumLength = 255, ErrorMessage = "Tên Phòng Phải Chứa Tối Thiểu 10 Ký Tự Và Tối Đa 255 Ký Tự")]
        public string Name { get; set; }

        public bool IsActive { get; set; }

        // One To Many
        ICollection<Schedule> Schedules { get; set; }

        public Room()
        {
            this.IsActive = true;
            this.Id = Guid.NewGuid().ToString();
        }

    }
}
