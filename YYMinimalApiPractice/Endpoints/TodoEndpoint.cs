using YYMinimalApiPractice.Dtos;
using YYMinimalApiPractice.Models;

namespace YYMinimalApiPractice.Endpoints
{
    public static class TodoEndpoint
    {
        private static readonly List<TodoModel> _todosSample =
         [
             new TodoModel{Id =0,Title="Brush my teetch" , IsCompleted=false },
             new TodoModel{Id =1,Title="Drink coffee" , IsCompleted=false },
             new TodoModel{Id =2,Title="Eat protein yogurt" , IsCompleted=false },
             new TodoModel{Id =3,Title="Drink coffee again" , IsCompleted=false },
             new TodoModel{Id =4,Title="Write code" , IsCompleted=false },
        ];
        public static void MapTodoEndpoints(this WebApplication app)
        {
            var todoGroup = app.MapGroup("todo/");
            todoGroup.MapGet("/", GetAllTodos);
            todoGroup.MapGet("/{id}", GetTodoById);
            todoGroup.MapPost("/", CreateTodo);
            todoGroup.MapPut("/{id}", UpdateTodo);
            todoGroup.MapDelete("/{id}", DeleteTodo);
        }
        private static IResult GetAllTodos()
        {
            var todoDtos = _todosSample.Select(todoModel => new Todo(todoModel)).ToList();
            return Results.Ok(todoDtos);
        }
        private static IResult GetTodoById(int id)
        {
            var todo = _todosSample.Find(element => id == element.Id);
            if (todo != null)
                return Results.Ok(new Todo(todo));
            return Results.NotFound();

        }
        private static IResult CreateTodo(TodoCreateUpdate todo)
        {
            var newTodo = new TodoModel { Id = 1, Title = todo.Title ,IsCompleted= todo.IsCompleted  };
            _todosSample.Add(newTodo);
            var todoDto = new Todo(newTodo);

            return Results.Created($"/todos/{newTodo.Id}", todoDto);
        }

        private static IResult UpdateTodo(TodoCreateUpdate todo, int id)
        {
            var indexToUpdate = _todosSample.FindIndex(element => element.Id == id);
            if (indexToUpdate == -1) return Results.NotFound();

            var updatedTodo = new TodoModel { Id = id, Title = todo.Title, IsCompleted=todo.IsCompleted };
            _todosSample[indexToUpdate] = updatedTodo;

            return Results.Ok(new Todo(updatedTodo));

        }

        private static IResult DeleteTodo(int id)
        {
            if (id == null) return Results.BadRequest("Invalid todo ID.");

            var todoToDelete = _todosSample.FirstOrDefault(element => id == element.Id);
            if (todoToDelete == null) return Results.NotFound();

            _todosSample.Remove(todoToDelete);

            return Results.NoContent();

        }
    }
}
