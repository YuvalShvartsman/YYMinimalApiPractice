using YYMinimalApiPractice.Dtos;
using YYMinimalApiPractice.Services.TodosService;

namespace YYMinimalApiPractice.Endpoints
{
    public static class TodoEndpoint
    {

        public static void MapTodoEndpoints(this WebApplication app)
        {
            var todoGroup = app.MapGroup("todo/");
            todoGroup.MapGet("/", GetAllTodos);
            todoGroup.MapGet("/{id}", GetTodoById);
            todoGroup.MapPost("/", CreateTodo);
            todoGroup.MapPut("/{id}", UpdateTodo);
            todoGroup.MapDelete("/{id}", DeleteTodo);
        }
        private static async Task<IResult> GetAllTodos(ITodoService todoService) =>
            await todoService.GetAllTodos();

        private static async Task<IResult> GetTodoById(ITodoService todoService, int id) =>
            await todoService.GetTodoById(id);

        private static async Task<IResult> CreateTodo(ITodoService todoService, TodoCreateUpdate todo) =>
            await todoService.CreateTodo(todo);

        private static async Task<IResult> UpdateTodo(ITodoService todoService, int id, TodoCreateUpdate updatedTodo) =>
            await todoService.UpdateTodo(id, updatedTodo);

        private static async Task<IResult> DeleteTodo(ITodoService todoService, int id) =>
            await todoService.DeleteTodo(id);
    }
}

