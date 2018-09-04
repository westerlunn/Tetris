namespace TheGame.EFRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fourth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blocks", "GameStateId", "dbo.GameStates");
            DropIndex("dbo.Blocks", new[] { "GameStateId" });
            RenameColumn(table: "dbo.Blocks", name: "GameStateId", newName: "GameState_Id");
            AlterColumn("dbo.Blocks", "GameState_Id", c => c.Int());
            CreateIndex("dbo.Blocks", "GameState_Id");
            AddForeignKey("dbo.Blocks", "GameState_Id", "dbo.GameStates", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blocks", "GameState_Id", "dbo.GameStates");
            DropIndex("dbo.Blocks", new[] { "GameState_Id" });
            AlterColumn("dbo.Blocks", "GameState_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Blocks", name: "GameState_Id", newName: "GameStateId");
            CreateIndex("dbo.Blocks", "GameStateId");
            AddForeignKey("dbo.Blocks", "GameStateId", "dbo.GameStates", "Id", cascadeDelete: true);
        }
    }
}
