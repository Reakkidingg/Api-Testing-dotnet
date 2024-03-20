using System.ComponentModel.DataAnnotations;

namespace UnitTestAPI.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string? CategoryName { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
    }
}
