using Microsoft.EntityFrameworkCore;

namespace TheGame
{
    public class GameContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<GameState> GameStates { get; set; }

        public GameContext()
        {

        }
        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server = (localdb)\\mssqllocaldb; Database = EfGame; Trusted_Connection = True; ");
            }

            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shape>()
                .ToTable("Shapes")
                .HasDiscriminator<int>("ShapeType")
                .HasValue<ShapeI>(1)
                .HasValue<ShapeJ>(2)
                .HasValue<ShapeO>(3);
        }
    }
}
