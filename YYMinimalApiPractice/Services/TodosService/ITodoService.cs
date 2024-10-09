using YYMinimalApiPractice.Dtos;

namespace YYMinimalApiPractice.Services.TodosService
{
    public interface ITodoService
    {
        Task<IResult> GetAllTodos();
        Task<IResult> GetTodoById(int id);
        Task<IResult> CreateTodo(TodoCreateUpdate todo);
        Task<IResult> UpdateTodo(int id, TodoCreateUpdate updatedTodo);
        Task<IResult> DeleteTodo(int id);
    }
}