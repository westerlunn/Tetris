namespace TheGame.EFRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eighth : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Blocks", name: "GameStateId", newName: "GameState_GameStateId");
            RenameIndex(table: "dbo.Blocks", name: "IX_GameStateId", newName: "IX_GameState_GameStateId");
            DropColumn("dbo.GameStates", "ActiveShapeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GameStates", "ActiveShapeId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Blocks", name: "IX_GameState_GameStateId", newName: "IX_GameStateId");
            RenameColumn(table: "dbo.Blocks", name: "GameState_GameStateId", newName: "GameStateId");
        }
    }
}
