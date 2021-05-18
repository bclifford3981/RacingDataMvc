namespace Racing.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullables2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Lap", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lap", "ModifiedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
