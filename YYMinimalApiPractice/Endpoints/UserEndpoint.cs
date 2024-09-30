using YYMinimalApiPractice.Dtos;
using YYMinimalApiPractice.Models;

namespace YYMinimalApiPractice.Endpoints
{
    public static class UserEndpoint
    {
        private static readonly List<UserModel> _usersSample =
         [
             new UserModel{Id ="0",Name="Yuval" },
             new UserModel{Id ="1",Name="Yoav" },
             new UserModel{Id ="2",Name="Yehuda" },
        ];
        public static void MapUserEndpoints(this WebApplication app)
        {
            var userGroup = app.MapGroup("users/");
            userGroup.MapGet("/", GetAllUsers);
            userGroup.MapGet("/{id}", GetUserById);
            userGroup.MapPost("/", CreateUser);
            userGroup.MapPut("/{id}", UpdateUser);
            userGroup.MapDelete("/{id}", DeleteUser);
        }
        private static IResult GetAllUsers()
        {
            var userDtos = _usersSample.Select(userModel => new User(userModel)).ToList();
            return Results.Ok(userDtos);
        }
        private static IResult GetUserById(string id)
        {
            var user = _usersSample.Find(element => id == element.Id);
            if (user != null)
                return Results.Ok(new User(user));
            return Results.NotFound();

        }
        private static IResult CreateUser(UserCreateUpdate user)
        {
            var newUser = new UserModel { Id = Guid.NewGuid().ToString(), Name = user.Name };
            _usersSample.Add(newUser);
            var userDto = new User (newUser);

            return Results.Created($"/users/{newUser.Id}", userDto);
        }
        private static IResult UpdateUser(UserCreateUpdate user, string id)
        {
            var indexToUpdate = _usersSample.FindIndex(element => element.Id == id);
            if (indexToUpdate == -1) return Results.NotFound();

            var updatedUser = new UserModel { Id = id, Name = user.Name };
            _usersSample[indexToUpdate] = updatedUser;

            return Results.Ok(new User(updatedUser));  

        }
        private static IResult DeleteUser(string id)
        {
            if (id == null) return Results.BadRequest("Invalid user ID.");

            var userToDelete = _usersSample.FirstOrDefault(element => id == element.Id);
            if (userToDelete == null) return Results.NotFound();

            _usersSample.Remove(userToDelete);

            return Results.NoContent();

        }
    }
}
