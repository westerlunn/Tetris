namespace TheGame.EFRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seventh : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Blocks", name: "GameState_GameStateId", newName: "GameStateId");
            RenameIndex(table: "dbo.Blocks", name: "IX_GameState_GameStateId", newName: "IX_GameStateId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Blocks", name: "IX_GameStateId", newName: "IX_GameState_GameStateId");
            RenameColumn(table: "dbo.Blocks", name: "GameStateId", newName: "GameState_GameStateId");
        }
    }
}
