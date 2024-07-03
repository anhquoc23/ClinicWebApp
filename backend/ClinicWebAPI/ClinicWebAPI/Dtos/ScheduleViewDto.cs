using ClinicWebAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ClinicWebAPI.Dtos
{
    public class ScheduleViewDto
    {
        public DateTime DateShift { get; set; }
        [Required(ErrorMessage = "Người Trực Không Để Trống")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Ca Trực Không Để Trống")]
        public string ShiftId { get; set; }
        [Required(ErrorMessage = "Phòng Trực Không Để Trống")]
        public string RoomId { get; set; }

        public string? EmployeeName { get; set; }
        [AllowNull]
        public TimeSpan TimeStart { get; set; }
        [AllowNull]
        public TimeSpan TimeEnd { get; set; }
        public string? RoomName { get; set; }
    }
}
