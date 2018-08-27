namespace TheGame.EFRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameStates", "ActiveShapeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameStates", "ActiveShapeId");
        }
    }
}
