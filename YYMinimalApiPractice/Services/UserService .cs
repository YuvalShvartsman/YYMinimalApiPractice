using Microsoft.EntityFrameworkCore;
using YYMinimalApiPractice.Data;
using YYMinimalApiPractice.Dtos;
using YYMinimalApiPractice.Models;

namespace YYMinimalApiPractice.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context) => _context = context;

        public async Task<IResult> GetAllUsers()
        {
            try
            {
                var users = await _context.User.ToListAsync();
                var userDtos = users.Select((user) => new User(user));
                return Results.Ok(userDtos);
            }
            catch (Exception ex)
            {
                return Results.Problem($"Error retrieving users: {ex.Message}");
            }
        }

        public async Task<IResult> GetUserById(int id)
        {
            try
            {
                var user = await _context.User.FindAsync(id);
                if (user != null)
                    return Results.Ok(new User(user));

                return Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem($"Error retrieving user by ID: {ex.Message}");
            }
        }

        public async Task<IResult> CreateUser(UserCreateUpdate user)
        {
            try
            {
                var newUser = new UserModel { Name = user.Name }; 
                await _context.User.AddAsync(newUser);
                await _context.SaveChangesAsync();
                var userDto = new User(newUser);

                return Results.Created($"/users/{newUser.Id}", userDto); 
            }
            catch (Exception ex)
            {
                return Results.Problem($"Error creating user: {ex.Message}");
            }
        }


        public async Task<IResult> UpdateUser(int id, UserCreateUpdate updatedUser)
        {
            try
            {
                var existingUser = await _context.User.FindAsync(id);
                if (existingUser == null)
                    return Results.NotFound();

                existingUser.Name = updatedUser.Name;
                await _context.SaveChangesAsync();

                return Results.Ok(new User(existingUser));
            }
            catch (Exception ex)
            {
                return Results.Problem($"Error updating user: {ex.Message}");
            }
        }

        public async Task<IResult> DeleteUser(int id)
        {
            try
            {
                var userToDelete = await _context.User.FindAsync(id);
                if (userToDelete == null)
                    return Results.NotFound();

                _context.User.Remove(userToDelete);
                await _context.SaveChangesAsync();

                return Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.Problem($"Error deleting user: {ex.Message}");
            }
        }
    }
}
