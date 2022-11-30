namespace United.NoteApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "ParentId", c => c.Int());
            CreateIndex("dbo.Notes", "ParentId");
            AddForeignKey("dbo.Notes", "ParentId", "dbo.Notes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "ParentId", "dbo.Notes");
            DropIndex("dbo.Notes", new[] { "ParentId" });
            DropColumn("dbo.Notes", "ParentId");
        }
    }
}
