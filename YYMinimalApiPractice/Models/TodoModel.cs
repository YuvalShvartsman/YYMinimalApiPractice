using System.ComponentModel.DataAnnotations;

namespace YYMinimalApiPractice.Models
{
    public class TodoModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }

        public required bool IsCompleted { get; set; }

        public int UserId { get; set; }

        [Required]
        public required UserModel User { get; set; }
    }
}
