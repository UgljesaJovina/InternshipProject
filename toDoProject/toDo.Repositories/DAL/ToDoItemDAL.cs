using Microsoft.EntityFrameworkCore;
using toDoProject.ToDo.Repositories.Models;

namespace toDoProject.ToDo.Repositories.DAL;

public class ToDoContext : DbContext {
    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options){
    }

    public DbSet<ToDoItem> ToDo { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString: "DefaultConnection");
    }
}
