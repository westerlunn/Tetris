namespace TheGame.EFRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blocks", "GameState_GameStateId", "dbo.GameStates");
            DropIndex("dbo.Blocks", new[] { "GameState_GameStateId" });
            AlterColumn("dbo.Blocks", "GameState_GameStateId", c => c.Int());
            CreateIndex("dbo.Blocks", "GameState_GameStateId");
            AddForeignKey("dbo.Blocks", "GameState_GameStateId", "dbo.GameStates", "GameStateId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blocks", "GameState_GameStateId", "dbo.GameStates");
            DropIndex("dbo.Blocks", new[] { "GameState_GameStateId" });
            AlterColumn("dbo.Blocks", "GameState_GameStateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Blocks", "GameState_GameStateId");
            AddForeignKey("dbo.Blocks", "GameState_GameStateId", "dbo.GameStates", "GameStateId", cascadeDelete: true);
        }
    }
}
