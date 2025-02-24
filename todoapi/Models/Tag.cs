namespace TodoApi.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;

        // Relation Many-to-Many avec TodoItem
        public List<TodoTag> TodoTags { get; set; } = new();
        //bonjour
    }
}