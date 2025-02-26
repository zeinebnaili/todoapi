using System.Text.Json.Serialization;

namespace TodoApi.Models
{
    public class TodoItem
    {
        public int Id { get; set; } // Utilisation de int pour l'ID (EF Core gère l'auto-incrémentation)
        
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Deadline { get; set; }
        public TodoStatus Status { get; set; }

        // Relation One-to-Many avec SubTodo
        [JsonIgnore]
        public List<SubTodo> SubTodos { get; set; } = new();

        // Relation Many-to-Many avec Tag
        [JsonIgnore]
        public List<TodoTag> TodoTags { get; set; } = new();
    }

    public enum TodoStatus
    {
        Pending = 0,
        InProgress = 1,
        Done = 2
    }
}