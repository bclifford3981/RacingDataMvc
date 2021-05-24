namespace Racing.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lap",
                c => new
                    {
                        LapId = c.Int(nullable: false, identity: true),
                        SessionId = c.Int(nullable: false),
                        LapMinutes = c.Int(nullable: false),
                        LapSeconds = c.Int(nullable: false),
                        LapTenthSeconds = c.Int(nullable: false),
                        LapHundrethSeconds = c.Int(nullable: false),
                        LapMilliseconds = c.Int(nullable: false),
                        SectorOneMinutes = c.Int(nullable: false),
                        SectorOneSeconds = c.Int(nullable: false),
                        SectorOneTenthSeconds = c.Int(nullable: false),
                        SectorOneHundrethSeconds = c.Int(nullable: false),
                        SectorOneMilliseconds = c.Int(nullable: false),
                        SectorTwoMinutes = c.Int(nullable: false),
                        SectorTwoSeconds = c.Int(nullable: false),
                        SectorTwoTenthSeconds = c.Int(nullable: false),
                        SectorTwoHundrethSeconds = c.Int(nullable: false),
                        SectorTwoMilliseconds = c.Int(nullable: false),
                        SectorThreeMinutes = c.Int(nullable: false),
                        SectorThreeSeconds = c.Int(nullable: false),
                        SectorThreeTenthSeconds = c.Int(nullable: false),
                        SectorThreeHundrethSeconds = c.Int(nullable: false),
                        SectorThreeMilliseconds = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.LapId)
                .ForeignKey("dbo.Session", t => t.SessionId, cascadeDelete: true)
                .Index(t => t.SessionId);
            
            CreateTable(
                "dbo.Session",
                c => new
                    {
                        SessionId = c.Int(nullable: false, identity: true),
                        VehicleId = c.Int(nullable: false),
                        LapId = c.Int(nullable: false),
                        Track = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.SessionId)
                .ForeignKey("dbo.Vehicle", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Vehicle",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Class = c.String(nullable: false),
                        Series = c.String(nullable: false),
                        HP = c.Double(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Lap", "SessionId", "dbo.Session");
            DropForeignKey("dbo.Session", "VehicleId", "dbo.Vehicle");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Session", new[] { "VehicleId" });
            DropIndex("dbo.Lap", new[] { "SessionId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Vehicle");
            DropTable("dbo.Session");
            DropTable("dbo.Lap");
        }
    }
}
