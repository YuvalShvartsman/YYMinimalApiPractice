using System.ComponentModel.DataAnnotations;

namespace YYMinimalApiPractice.Models
{
    public record UserModel
    {
        [Key]
        public int Id { get; set; }  

        [Required]
        public required string Name { get; set; }

        [Required]
        public required List<TodoModel> Tasks { get; set; }
    }
}
