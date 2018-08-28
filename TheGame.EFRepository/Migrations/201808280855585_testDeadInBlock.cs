namespace TheGame.EFRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testDeadInBlock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blocks", "Block_BlockId", c => c.Int());
            CreateIndex("dbo.Blocks", "Block_BlockId");
            AddForeignKey("dbo.Blocks", "Block_BlockId", "dbo.Blocks", "BlockId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blocks", "Block_BlockId", "dbo.Blocks");
            DropIndex("dbo.Blocks", new[] { "Block_BlockId" });
            DropColumn("dbo.Blocks", "Block_BlockId");
        }
    }
}
