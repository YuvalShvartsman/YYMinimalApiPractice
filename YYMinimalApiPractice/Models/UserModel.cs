using System.ComponentModel.DataAnnotations;

namespace YYMinimalApiPractice.Models
{
    public record UserModel
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
    }
}