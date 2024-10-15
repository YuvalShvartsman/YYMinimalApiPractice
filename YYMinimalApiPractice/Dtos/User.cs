using YYMinimalApiPractice.Models;

namespace YYMinimalApiPractice.Dtos
{
    public record User
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public List<Todo> Tasks { get; init; }  

        public User(UserModel userModel)
        {
            Id = userModel.Id;
            Name = userModel.Name;
            Tasks = userModel.Todos.Select(todo => new Todo(todo)).ToList(); 
        }
    }

    public record UserCreateOrUpdate
    {
        public required string Name { get; init; }
    }
}
