using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RealGames.Models;

namespace RealGames.Contexts
{
    public class Context : DbContext
    {
        public DbSet<Bundle> Bundles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GameCategory> GameCategories { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameBundle> GameBundles { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public static bool isMigration = true;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (isMigration)
                optionsBuilder.UseSqlServer(@"Server=.\;Database=DBRealGames1;Trusted_Connection=True");
        }
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}
