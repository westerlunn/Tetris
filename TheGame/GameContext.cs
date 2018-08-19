using Microsoft.EntityFrameworkCore;

namespace TheGame
{
    public class GameContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = (localdb)\\mssqllocaldb; Database = EfGame; Trusted_Connection = True; ");
        }
    }
}
