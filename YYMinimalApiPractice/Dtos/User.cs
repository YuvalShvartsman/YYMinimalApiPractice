using YYMinimalApiPractice.Models;

namespace YYMinimalApiPractice.Dtos
{
    public record User
    {
        public  int Id { get; init; }
        public  string Name { get; init; }

        public User(UserModel userModel)
        {
            Id = userModel.Id;
            Name = userModel.Name;
        }
    }
    public record UserCreateUpdate
    {
        public required string Name { get; init; }
    }


}
