using Microsoft.EntityFrameworkCore;

namespace meal_Planning_Console
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<GroceryList> GroceryList { get; set;}
    }
}