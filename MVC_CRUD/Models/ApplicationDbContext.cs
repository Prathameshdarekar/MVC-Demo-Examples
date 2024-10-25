// Data/ApplicationDbContext.cs
using MVC_CRUD.Models;
using System.Data.Entity;

namespace MVC_CRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") // Specify the connection string name
        {
        }

        public DbSet<Products> Products { get; set; } // DbSet for Product model
    }
}
