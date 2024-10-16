﻿using YYMinimalApiPractice.Models;

namespace YYMinimalApiPractice.Dtos
{
    public record Todo
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public bool IsCompleted { get; init; }
        public int UserId { get; init; } 


        public Todo(TodoModel todo)
        {
            Id = todo.Id;
            Title = todo.Title;
            IsCompleted = todo.IsCompleted;
            UserId = todo.UserId;  

        }
    }
    public record TodoCreateUpdate
    {
        public required string Title { get; init; }
        public required bool IsCompleted { get; init; }
        public required int UserId { get; init; }  


    }


}
