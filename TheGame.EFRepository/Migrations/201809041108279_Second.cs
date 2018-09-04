namespace TheGame.EFRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blocks", "GameState_Id", "dbo.GameStates");
            DropIndex("dbo.Blocks", new[] { "GameState_Id" });
            RenameColumn(table: "dbo.Blocks", name: "GameState_Id", newName: "GameStateId");
            AlterColumn("dbo.Blocks", "GameStateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Blocks", "GameStateId");
            AddForeignKey("dbo.Blocks", "GameStateId", "dbo.GameStates", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blocks", "GameStateId", "dbo.GameStates");
            DropIndex("dbo.Blocks", new[] { "GameStateId" });
            AlterColumn("dbo.Blocks", "GameStateId", c => c.Int());
            RenameColumn(table: "dbo.Blocks", name: "GameStateId", newName: "GameState_Id");
            CreateIndex("dbo.Blocks", "GameState_Id");
            AddForeignKey("dbo.Blocks", "GameState_Id", "dbo.GameStates", "Id");
        }
    }
}
