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
            => Results.Ok(_usersSample);

        private static IResult GetUserById(string id)
        {
            var user = _usersSample.Find(element => id == element.Id);
            if (user != null)
            {
                var userDto = new User({ Id = user.Id, Name = user.Name });
                return Results.Ok(userDto);
            }
            return Results.NotFound();

        }
        private static IResult CreateUser(UserModel user)
        {
            _usersSample.Add(user);
            return Results.Ok(user);

        }
        private static IResult UpdateUser(UserModel user)
        {
            var indexToUpdate = _usersSample.FindIndex(element => element.Id == user.Id);
            _usersSample[indexToUpdate] = user;
            return Results.Ok(user);

        }
        private static IResult DeleteUser(string id)
        {
            if (id == null) return Results.NotFound();
            var userToDelete = _usersSample.FirstOrDefault(element => id == element.Id);
            if (userToDelete != null)
                _usersSample.Remove(userToDelete);
            return Results.Ok();

        }
    }
}
