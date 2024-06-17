using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicWebAPI.Models
{
    [Table("category")]
    public class Category
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        // One To Many
        ICollection<User> Users { get; set; }

        public Category()
        {
            this.IsActive = true;
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
