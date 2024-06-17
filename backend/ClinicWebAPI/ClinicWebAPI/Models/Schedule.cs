using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicWebAPI.Models
{
    [Table("schedule")]
    public class Schedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngày Trực Không Để Trống")]
        public DateTime DateShift { get; set; }


        // Many To One
        [ForeignKey("User")]
        [Required(ErrorMessage = "Người Trực Không Để Trống")]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Shift")]
        [Required(ErrorMessage = "Ca Trực Không Để Trống")]
        public string ShiftId { get; set; }
        public Shift Shift { get; set; }

        [ForeignKey("Room")]
        [Required(ErrorMessage = "Phòng Trực Không Để Trống")]
        public string RoomId { get; set; }
        public Room Room { get; set; }
    }
}
