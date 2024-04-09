using Microsoft.EntityFrameworkCore;
using RecipeBook;
using System.Collections.Generic;

namespace DatasetAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }


    }
}
