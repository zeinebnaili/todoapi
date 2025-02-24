using System;
using System.Collections.Generic;

namespace TodoApi.Models
{
    public class SubTodo
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Deadline { get; set; }
        public TodoStatus Status { get; set; }

        // Relation Many-to-One avec TodoItem (Parent)
        public int ParentTodoId { get; set; }
        public TodoItem? ParentTodo { get; set; }
    }
}