using System;
using System.Data.Entity;
using Infrastructure.DataModel;
using TheGame.EFRepository.Migrations;

namespace TheGame.EFRepository
{
    public class GameContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<GameState> GameStates { get; set; }
        public DbSet<Shape> Shapes { get; set; }
        public DbSet<Block> Blocks { get; set; }

        public GameContext() : base("Server = (localdb)\\mssqllocaldb; Database = EfGame; Trusted_Connection = True; ") //"name=myconnectionstring"
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(
        //            "Server = (localdb)\\mssqllocaldb; Database = EfGame; Trusted_Connection = True; ");
        //    }

        //    optionsBuilder.EnableSensitiveDataLogging();
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

        //    modelBuilder.Entity<GameState>()
        //        .HasMany(g => g.DeadBlocks)
        //        .WithRequired(d => d.GameState);

        //    //.HasForeignKey(g => g.GameState.Id);



        //    //    //.HasMany(g => g.DeadBlocks)
        //    //    //.WithOne(d => d.GameState);

        //    //modelBuilder.Entity<Shape>()
        //    //    .ToTable("Shapes")
        //    //    .h

        //    //modelBuilder.Entity<Shape>();
        //    //    .ToTable("Shapes")
        //    //.HasDiscriminator<int>("ShapeType")
        //    //.HasValue<ShapeO>(1);

        //    //modelBuilder.Entity<RotatableShape>()
        //    //    .ToTable("Shapes")
        //    //    .HasDiscriminator<int>("ShapeType")
        //    //    .HasValue<ShapeI>(2)
        //    //    .HasValue<ShapeJ>(3);
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

            modelBuilder.Entity<GameState>()
                .HasOptional(g => g.ActiveShape)
                .WithRequired();

            modelBuilder.Entity<Shape>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<Block>()
                .HasKey(k => k.Id)
                .HasRequired(b => b.GameState)
                .WithMany(g => g.DeadBlocks);
        }
    }
}
