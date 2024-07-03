using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicWebAPI.Models
{
    [Table("shift")]
    public class Shift
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "Tên Ca Trực Không Để Trống")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Thời Gian Bắt Đầu Không Để Trống")]
        [DataType(DataType.Time)]
        public TimeSpan TimeStart { get; set; }

        [Required(ErrorMessage = "Thời Gian Kế Thúc Không Để Trống")]
        [DataType(DataType.Time)]
        public TimeSpan TimeEnd { get; set; }

        // One To Many
        ICollection<Schedule> Schedules { get; set; }

        public Shift()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
