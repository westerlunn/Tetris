namespace TheGame.EFRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GameStates", "ActiveShapeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GameStates", "ActiveShapeId", c => c.Int(nullable: false));
        }
    }
}
