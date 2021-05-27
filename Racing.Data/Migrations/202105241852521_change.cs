namespace Racing.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Session", "LapId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Session", "LapId", c => c.Int(nullable: false));
        }
    }
}
