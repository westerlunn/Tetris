namespace TheGame.EFRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameStateId = c.Int(nullable: false),
                        XPosition = c.Int(nullable: false),
                        YPosition = c.Int(nullable: false),
                        Color = c.Int(nullable: false),
                        IsFilled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameStates", t => t.GameStateId, cascadeDelete: true)
                .Index(t => t.GameStateId);
            
            CreateTable(
                "dbo.GameStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Score = c.Long(nullable: false),
                        Player_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.Player_Id)
                .Index(t => t.Player_Id);
            
            CreateTable(
                "dbo.Shapes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        XPosition = c.Int(nullable: false),
                        YPosition = c.Int(nullable: false),
                        Rotation = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameStates", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Highscore = c.Long(nullable: false),
                        Score = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blocks", "GameStateId", "dbo.GameStates");
            DropForeignKey("dbo.GameStates", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.Shapes", "Id", "dbo.GameStates");
            DropIndex("dbo.Shapes", new[] { "Id" });
            DropIndex("dbo.GameStates", new[] { "Player_Id" });
            DropIndex("dbo.Blocks", new[] { "GameStateId" });
            DropTable("dbo.Players");
            DropTable("dbo.Shapes");
            DropTable("dbo.GameStates");
            DropTable("dbo.Blocks");
        }
    }
}
