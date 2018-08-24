using Microsoft.EntityFrameworkCore;
using TheGame.Infrastructure.DataModel;

namespace TheGame.EFRepository
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
            modelBuilder.Entity<GameState>()
                .HasMany(g => g.DeadBlocks)
                .WithOne(d => d.GameState);

            modelBuilder.Entity<Shape>()
                .ToTable("Shapes")
                .HasDiscriminator<int>("ShapeType")
                .HasValue<ShapeO>(1);

            modelBuilder.Entity<RotatableShape>()
                .ToTable("Shapes")
                .HasDiscriminator<int>("ShapeType")
                .HasValue<ShapeI>(2)
                .HasValue<ShapeJ>(3);
        }
    }
}
