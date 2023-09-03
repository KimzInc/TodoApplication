using System.ComponentModel.DataAnnotations;

namespace TodoApplication.Dtos
{
    public class TodoUpdateDto
    {
        [Required]
        [MaxLength(10)]
        public string? Name { get; set; }

        [Required]
        public bool IsComplete { get; set; }
    }
}
