using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System.IO;

namespace meal_Planning_Console
{
    public class MealPlanningContext : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<GroceryList> GroceryLists { get; set;}

        public string DbPath { get; }

        public MealPlanningContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "meal_planning.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>().ToTable("Ingredient");
            modelBuilder.Entity<Recipe>().ToTable("Recipe");
            modelBuilder.Entity<GroceryList>().ToTable("GroceryList");
        }
    }
}