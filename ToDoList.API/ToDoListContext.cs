using Microsoft.EntityFrameworkCore;
using ToDoList.Model;

namespace ToDoList.API
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
        {
        }

        public DbSet<ToDoItems> ToDoItems { get; set; }
    }
}