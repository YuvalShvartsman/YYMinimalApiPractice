﻿using System.ComponentModel.DataAnnotations;

namespace YYMinimalApiPractice.Models
{
    public class TodoModel
    {
        [Key]
        public required int Id { get; set; }

        [Required]
        public required string Title { get; set; }
        [Required]
        public required bool IsCompleted { get; set; }
    }
}
