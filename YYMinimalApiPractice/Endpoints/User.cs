using System.ComponentModel.DataAnnotations;

namespace YYMinimalApiPractice.Endpoints
{
    public record User
    {

        public required string Id { get; set; }
        public required string Name { get; set; }
    }
}