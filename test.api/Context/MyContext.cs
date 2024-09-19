using Microsoft.EntityFrameworkCore;
using test.api.Models;

namespace test.api.Context
{
    public class MyContext : DbContext
    {
        public DbSet<User> Users {  get; set; }
        public DbSet<Checklist> Checklist { get; set; }


        public MyContext(DbContextOptions<MyContext> options) : base(options)
        { 
        }
    }
}
