using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<SubTodo> SubTodos { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TodoTag> TodoTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration de la relation Many-to-Many entre TodoItem et Tag
            modelBuilder.Entity<TodoTag>()
                .HasKey(tt => new { tt.TodoId, tt.TagId });

            modelBuilder.Entity<TodoTag>()
                .HasOne(tt => tt.Todo)
                .WithMany(t => t.TodoTags)
                .HasForeignKey(tt => tt.TodoId);

            modelBuilder.Entity<TodoTag>()
                .HasOne(tt => tt.Tag)
                .WithMany(t => t.TodoTags)
                .HasForeignKey(tt => tt.TagId);
            // Seed des données fixes (dates statiques pour EF Core)
            var date1 = new DateTime(2025, 2, 20);
            var date2 = new DateTime(2025, 2, 25);
            // Ajouter des Todos
            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem { Id = 1, Name = "vuejs", Description = "Aller au ", Deadline = date1, Status =TodoStatus.Pending },
                new TodoItem { Id = 2, Name = "Réviser .NET", Description = "Étudier l'API Web", Deadline = date2, Status = TodoStatus.InProgress }
            );
            // Seed Data pour SubTodos
            modelBuilder.Entity<SubTodo>().HasData(
                new SubTodo { Id = 1, Name = "Faire une maquette", Description = "Créer le wireframe", Deadline = date2, Status = TodoStatus.Pending, ParentTodoId = 2 },
                new SubTodo { Id = 2, Name = "Créer composants Vue", Description = "Développer les composants de base", Deadline = date1, Status = TodoStatus.InProgress, ParentTodoId = 2 }
            );
            // ✅ Ajout de données initiales (Seeding)
            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = 1, Name = "Travail", Color = "Blue" },
                new Tag { Id = 2, Name = "Personnel", Color = "Green" },
                new Tag { Id = 3, Name = "Urgent", Color = "Red" }
            );
            // Ajouter des relations entre Todo et Tag
            modelBuilder.Entity<TodoTag>().HasData(
                new TodoTag { TodoId = 1, TagId = 1 },
                new TodoTag { TodoId = 2, TagId = 2 }
            );
        }
    }
}
