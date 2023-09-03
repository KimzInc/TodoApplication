using System.ComponentModel.DataAnnotations;

namespace TodoApplication.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Name { get; set; }

        [Required]
        public bool IsComplete { get; set; }
    }
}
