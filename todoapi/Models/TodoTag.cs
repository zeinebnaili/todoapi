
namespace TodoApi.Models
{
    public class TodoTag
    {
        public int TodoId { get; set; }
        public TodoItem Todo { get; set; } = null!;

        public int TagId { get; set; }
        public Tag Tag { get; set; } = null!;
    }
}
