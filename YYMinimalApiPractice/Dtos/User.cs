namespace YYMinimalApiPractice.Dtos
{
    public record User
    {
        public required string Id { get; init; }
        public required string Name { get; init; }
    }
    public record UserCreateUpdate
    {
        public required string Name { get; init; }
    }


}
