namespace TheGame.EFRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameStates",
                c => new
                    {
                        GameStateId = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Score = c.Long(nullable: false),
                        ActiveShape_ShapeId = c.Int(),
                        Player_Id = c.Int(),
                    })
                .PrimaryKey(t => t.GameStateId)
                .ForeignKey("dbo.Shapes", t => t.ActiveShape_ShapeId)
                .ForeignKey("dbo.Players", t => t.Player_Id)
                .Index(t => t.ActiveShape_ShapeId)
                .Index(t => t.Player_Id);
            
            CreateTable(
                "dbo.Shapes",
                c => new
                    {
                        ShapeId = c.Int(nullable: false, identity: true),
                        XPosition = c.Int(nullable: false),
                        YPosition = c.Int(nullable: false),
                        Rotation = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ShapeId);
            
            CreateTable(
                "dbo.Blocks",
                c => new
                    {
                        BlockId = c.Int(nullable: false, identity: true),
                        XPosition = c.Int(nullable: false),
                        YPosition = c.Int(nullable: false),
                        Color = c.Int(nullable: false),
                        IsFilled = c.Boolean(nullable: false),
                        GameState_GameStateId = c.Int(),
                    })
                .PrimaryKey(t => t.BlockId)
                .ForeignKey("dbo.GameStates", t => t.GameState_GameStateId)
                .Index(t => t.GameState_GameStateId);
            
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
            DropForeignKey("dbo.GameStates", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.Blocks", "GameState_GameStateId", "dbo.GameStates");
            DropForeignKey("dbo.GameStates", "ActiveShape_ShapeId", "dbo.Shapes");
            DropIndex("dbo.Blocks", new[] { "GameState_GameStateId" });
            DropIndex("dbo.GameStates", new[] { "Player_Id" });
            DropIndex("dbo.GameStates", new[] { "ActiveShape_ShapeId" });
            DropTable("dbo.Players");
            DropTable("dbo.Blocks");
            DropTable("dbo.Shapes");
            DropTable("dbo.GameStates");
        }
    }
}
