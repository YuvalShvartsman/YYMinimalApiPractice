using YYMinimalApiPractice.Dtos;

namespace YYMinimalApiPractice.Services.UsersService
{
    public interface IUserService
    {
        Task<IResult> GetAllUsers();
        Task<IResult> GetUserById(int id);
        Task<IResult> CreateUser(UserCreateOrUpdate user);
        Task<IResult> UpdateUser(int id, UserCreateOrUpdate updatedUser);
        Task<IResult> DeleteUser(int id);
    }
}