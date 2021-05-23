namespace Racing.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sessionLaps : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lap", "SessionId", "dbo.Session");
            AddColumn("dbo.Lap", "Session_SessionId", c => c.Int());
            AddColumn("dbo.Lap", "Session_SessionId1", c => c.Int());
            CreateIndex("dbo.Lap", "Session_SessionId");
            CreateIndex("dbo.Lap", "Session_SessionId1");
            AddForeignKey("dbo.Lap", "Session_SessionId1", "dbo.Session", "SessionId");
            AddForeignKey("dbo.Lap", "Session_SessionId", "dbo.Session", "SessionId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lap", "Session_SessionId", "dbo.Session");
            DropForeignKey("dbo.Lap", "Session_SessionId1", "dbo.Session");
            DropIndex("dbo.Lap", new[] { "Session_SessionId1" });
            DropIndex("dbo.Lap", new[] { "Session_SessionId" });
            DropColumn("dbo.Lap", "Session_SessionId1");
            DropColumn("dbo.Lap", "Session_SessionId");
            AddForeignKey("dbo.Lap", "SessionId", "dbo.Session", "SessionId", cascadeDelete: true);
        }
    }
}
