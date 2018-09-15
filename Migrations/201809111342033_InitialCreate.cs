namespace MTT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        HireDate = c.DateTime(),
                        JoinDate = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleID = c.Int(nullable: false),
                        Champion = c.String(maxLength: 50),
                        KDA = c.Int(nullable: false),
                        RegionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoleID)
                .ForeignKey("dbo.Region", t => t.RegionID, cascadeDelete: true)
                .Index(t => t.RegionID);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        RegionID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Budget = c.Decimal(nullable: false, storeType: "money"),
                        StartDate = c.DateTime(nullable: false),
                        CoachID = c.Int(),
                    })
                .PrimaryKey(t => t.RegionID)
                .ForeignKey("dbo.Person", t => t.CoachID)
                .Index(t => t.CoachID);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        TeamID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(nullable: false),
                        PlayerID = c.Int(nullable: false),
                        Rank = c.Int(),
                    })
                .PrimaryKey(t => t.TeamID)
                .ForeignKey("dbo.Person", t => t.PlayerID, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID)
                .Index(t => t.PlayerID);
            
            CreateTable(
                "dbo.RoleCoach",
                c => new
                    {
                        RoleID = c.Int(nullable: false),
                        CoachID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleID, t.CoachID })
                .ForeignKey("dbo.Role", t => t.RoleID, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.CoachID, cascadeDelete: true)
                .Index(t => t.RoleID)
                .Index(t => t.CoachID);
            
            CreateStoredProcedure(
                "dbo.Region_Insert",
                p => new
                    {
                        Name = p.String(maxLength: 50),
                        Budget = p.Decimal(precision: 19, scale: 4, storeType: "money"),
                        StartDate = p.DateTime(),
                        CoachID = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Region]([Name], [Budget], [StartDate], [CoachID])
                      VALUES (@Name, @Budget, @StartDate, @CoachID)
                      
                      DECLARE @RegionID int
                      SELECT @RegionID = [RegionID]
                      FROM [dbo].[Region]
                      WHERE @@ROWCOUNT > 0 AND [RegionID] = scope_identity()
                      
                      SELECT t0.[RegionID]
                      FROM [dbo].[Region] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[RegionID] = @RegionID"
            );
            
            CreateStoredProcedure(
                "dbo.Region_Update",
                p => new
                    {
                        RegionID = p.Int(),
                        Name = p.String(maxLength: 50),
                        Budget = p.Decimal(precision: 19, scale: 4, storeType: "money"),
                        StartDate = p.DateTime(),
                        CoachID = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Region]
                      SET [Name] = @Name, [Budget] = @Budget, [StartDate] = @StartDate, [CoachID] = @CoachID
                      WHERE ([RegionID] = @RegionID)"
            );
            
            CreateStoredProcedure(
                "dbo.Region_Delete",
                p => new
                    {
                        RegionID = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Region]
                      WHERE ([RegionID] = @RegionID)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Region_Delete");
            DropStoredProcedure("dbo.Region_Update");
            DropStoredProcedure("dbo.Region_Insert");
            DropForeignKey("dbo.Team", "RoleID", "dbo.Role");
            DropForeignKey("dbo.Team", "PlayerID", "dbo.Person");
            DropForeignKey("dbo.Role", "RegionID", "dbo.Region");
            DropForeignKey("dbo.Region", "CoachID", "dbo.Person");
            DropForeignKey("dbo.RoleCoach", "CoachID", "dbo.Person");
            DropForeignKey("dbo.RoleCoach", "RoleID", "dbo.Role");
            DropIndex("dbo.RoleCoach", new[] { "CoachID" });
            DropIndex("dbo.RoleCoach", new[] { "RoleID" });
            DropIndex("dbo.Team", new[] { "PlayerID" });
            DropIndex("dbo.Team", new[] { "RoleID" });
            DropIndex("dbo.Region", new[] { "CoachID" });
            DropIndex("dbo.Role", new[] { "RegionID" });
            DropTable("dbo.RoleCoach");
            DropTable("dbo.Team");
            DropTable("dbo.Region");
            DropTable("dbo.Role");
            DropTable("dbo.Person");
        }
    }
}
