namespace Racing.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lapRewrite : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lap", "LapMinutes", c => c.Int(nullable: false));
            AddColumn("dbo.Lap", "LapSeconds", c => c.Int(nullable: false));
            AddColumn("dbo.Lap", "LapTenthSeconds", c => c.Int(nullable: false));
            AddColumn("dbo.Lap", "LapHundrethSeconds", c => c.Int(nullable: false));
            AddColumn("dbo.Lap", "LapMilliseconds", c => c.Int(nullable: false));
            AddColumn("dbo.Lap", "SectorOneMinutes", c => c.Int(nullable: false));
            AddColumn("dbo.Lap", "SectorOneSeconds", c => c.Int(nullable: false));
            AddColumn("dbo.Lap", "SectorOneTenthSeconds", c => c.Int(nullable: false));
            AddColumn("dbo.Lap", "SectorOneHundrethSeconds", c => c.Int(nullable: false));
            AddColumn("dbo.Lap", "SectorOneMilliseconds", c => c.Int(nullable: false));
            AddColumn("dbo.Lap", "SectorTwoMinutes", c => c.Int(nullable: false));
            AddColumn("dbo.Lap", "SectorTwoSeconds", c => c.Int(nullable: false));
            AddColumn("dbo.Lap", "SectorTwoTenthSeconds", c => c.Int(nullable: false));
            AddColumn("dbo.Lap", "SectorTwoHundrethSeconds", c => c.Int(nullable: false));
            AddColumn("dbo.Lap", "SectorTwoMilliseconds", c => c.Int(nullable: false));
            AddColumn("dbo.Lap", "SectorThreeMinutes", c => c.Int(nullable: false));
            AddColumn("dbo.Lap", "SectorThreeSeconds", c => c.Int(nullable: false));
            AddColumn("dbo.Lap", "SectorThreeTenthSeconds", c => c.Int(nullable: false));
            AddColumn("dbo.Lap", "SectorThreeHundrethSeconds", c => c.Int(nullable: false));
            AddColumn("dbo.Lap", "SectorThreeMilliseconds", c => c.Int(nullable: false));
            DropColumn("dbo.Lap", "LapTime");
            DropColumn("dbo.Lap", "SectorOne");
            DropColumn("dbo.Lap", "SectorTwo");
            DropColumn("dbo.Lap", "SectorThree");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lap", "SectorThree", c => c.Int(nullable: false));
            AddColumn("dbo.Lap", "SectorTwo", c => c.Int(nullable: false));
            AddColumn("dbo.Lap", "SectorOne", c => c.Int(nullable: false));
            AddColumn("dbo.Lap", "LapTime", c => c.Int(nullable: false));
            DropColumn("dbo.Lap", "SectorThreeMilliseconds");
            DropColumn("dbo.Lap", "SectorThreeHundrethSeconds");
            DropColumn("dbo.Lap", "SectorThreeTenthSeconds");
            DropColumn("dbo.Lap", "SectorThreeSeconds");
            DropColumn("dbo.Lap", "SectorThreeMinutes");
            DropColumn("dbo.Lap", "SectorTwoMilliseconds");
            DropColumn("dbo.Lap", "SectorTwoHundrethSeconds");
            DropColumn("dbo.Lap", "SectorTwoTenthSeconds");
            DropColumn("dbo.Lap", "SectorTwoSeconds");
            DropColumn("dbo.Lap", "SectorTwoMinutes");
            DropColumn("dbo.Lap", "SectorOneMilliseconds");
            DropColumn("dbo.Lap", "SectorOneHundrethSeconds");
            DropColumn("dbo.Lap", "SectorOneTenthSeconds");
            DropColumn("dbo.Lap", "SectorOneSeconds");
            DropColumn("dbo.Lap", "SectorOneMinutes");
            DropColumn("dbo.Lap", "LapMilliseconds");
            DropColumn("dbo.Lap", "LapHundrethSeconds");
            DropColumn("dbo.Lap", "LapTenthSeconds");
            DropColumn("dbo.Lap", "LapSeconds");
            DropColumn("dbo.Lap", "LapMinutes");
        }
    }
}
