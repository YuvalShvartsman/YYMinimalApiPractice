using Microsoft.AspNetCore.Mvc;
using YYMinimalApiPractice.Dtos;

namespace YYMinimalApiPractice.Services
{
    public interface IUserService
    {
        Task<IResult> GetAllUsers();
        Task<IResult> GetUserById(int id);
        Task<IResult> CreateUser(UserCreateUpdate user);
        Task<IResult> UpdateUser(int id, UserCreateUpdate updatedUser);
        Task<IResult> DeleteUser(int id);
    }
}