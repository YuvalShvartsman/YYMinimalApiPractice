using YYMinimalApiPractice.Dtos;
using YYMinimalApiPractice.Services.UsersService;

namespace YYMinimalApiPractice.Endpoints
{
    public static class UserEndpoint
    {

        public static void MapUserEndpoints(this WebApplication app)
        {
            var userGroup = app.MapGroup("users/");

            userGroup.MapGet("/", GetAllUsers);
            userGroup.MapGet("/{id}", GetUserById);
            userGroup.MapPost("/", CreateUser);
            userGroup.MapPut("/{id}", UpdateUser);
            userGroup.MapDelete("/{id}", DeleteUser);
        }

        private static async Task<IResult> GetAllUsers(IUserService userService) =>
            await userService.GetAllUsers();

        private static async Task<IResult> GetUserById(IUserService userService, int id) =>
            await userService.GetUserById(id);

        private static async Task<IResult> CreateUser(IUserService userService, UserCreateOrUpdate user) =>
            await userService.CreateUser(user);

        private static async Task<IResult> UpdateUser(IUserService userService, int id, UserCreateOrUpdate updatedUser) =>
            await userService.UpdateUser(id, updatedUser);

        private static async Task<IResult> DeleteUser(IUserService userService, int id) =>
            await userService.DeleteUser(id);
    }
}
