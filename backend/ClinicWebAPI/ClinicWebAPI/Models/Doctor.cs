using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicWebAPI.Models
{
    [Table("doctor")]
    public class Doctor
    {
        [Key]
        public string Id { get; set; }

        // Many To One
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Specialization")]
        public string SpecializationId { get; set; }
        public Specialization Specialization { get; set; }

        public Doctor()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
