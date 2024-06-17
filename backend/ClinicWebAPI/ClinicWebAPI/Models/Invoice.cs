using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicWebAPI.Models
{
    [Table("invoice")]
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        [DefaultValue("PENDING")]
        public string InvoiceStatus { get; set; }

        [NotMapped]
        public static readonly Dictionary<string, string> Status = new Dictionary<string, string>
        {
            { "PENDING", "PENDING" },
            { "ACCEPTED", "ACCEPTED" }
        };

        // Many To One
        [ForeignKey("MedicalRecord")]
        [Required]
        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }

        [ForeignKey("User")]
        public string? NurseId { get; set; }
        public User? Nurse { get; set; }
    }
}
