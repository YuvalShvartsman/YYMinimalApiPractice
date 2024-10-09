using Microsoft.EntityFrameworkCore;
using YYMinimalApiPractice.Data;
using YYMinimalApiPractice.Dtos;
using YYMinimalApiPractice.Models;

namespace YYMinimalApiPractice.Services.TodosService
{
    public class TodoService : ITodoService
    {
        private readonly AppDbContext _context;

        public TodoService(AppDbContext context) => _context = context;

        public async Task<IResult> GetAllTodos()
        {
            try
            {
                var todos = await _context.Todo.ToListAsync();
                var todosDtos = todos.Select((todo) => new Todo(todo));
                return Results.Ok(todosDtos);
            }
            catch (Exception ex)
            {
                return Results.Problem($"Error retrieving todos: {ex.Message}");
            }
        }

        public async Task<IResult> GetTodoById(int id)
        {
            try
            {
                var todo = await _context.Todo.FindAsync(id);
                if (todo != null)
                    return Results.Ok(new Todo(todo));

                return Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem($"Error retrieving todo by ID: {ex.Message}");
            }
        }

        public async Task<IResult> CreateTodo(TodoCreateUpdate todo)
        {
            try
            {
                var newTodo = new TodoModel { Title = todo.Title,IsCompleted=todo.IsCompleted };
                await _context.Todo.AddAsync(newTodo);
                await _context.SaveChangesAsync();
                var todoDto = new Todo(newTodo);

                return Results.Created($"/todos/{newTodo.Id}", todoDto);
            }
            catch (Exception ex)
            {
                return Results.Problem($"Error creating todo: {ex.Message}");
            }
        }


        public async Task<IResult> UpdateTodo(int id, TodoCreateUpdate updatedTodo)
        {
            try
            {
                var existingTodo = await _context.Todo.FindAsync(id);
                if (existingTodo == null)
                    return Results.NotFound();

                existingTodo.Title = updatedTodo.Title;
                existingTodo.IsCompleted = updatedTodo.IsCompleted;

                await _context.SaveChangesAsync();

                return Results.Ok(new Todo(existingTodo));
            }
            catch (Exception ex)
            {
                return Results.Problem($"Error updating todo: {ex.Message}");
            }
        }

        public async Task<IResult> DeleteTodo(int id)
        {
            try
            {
                var todoToDelete = await _context.Todo.FindAsync(id);
                if (todoToDelete == null)
                    return Results.NotFound();

                _context.Todo.Remove(todoToDelete);
                await _context.SaveChangesAsync();

                return Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.Problem($"Error deleting todo: {ex.Message}");
            }
        }
    }
}
