namespace MyZoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        AnimalId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Weight = c.Int(nullable: false),
                        Sex = c.String(),
                        CountryOfOrigin_CountryOfOriginId = c.Int(),
                        ParentCouple_ParentCoupleId = c.Int(),
                        Species_SpeciesId = c.Int(),
                    })
                .PrimaryKey(t => t.AnimalId)
                .ForeignKey("dbo.CountryOfOrigins", t => t.CountryOfOrigin_CountryOfOriginId)
                .ForeignKey("dbo.ParentCouples", t => t.ParentCouple_ParentCoupleId)
                .ForeignKey("dbo.Species", t => t.Species_SpeciesId)
                .Index(t => t.CountryOfOrigin_CountryOfOriginId)
                .Index(t => t.ParentCouple_ParentCoupleId)
                .Index(t => t.Species_SpeciesId);
            
            CreateTable(
                "dbo.CountryOfOrigins",
                c => new
                    {
                        CountryOfOriginId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CountryOfOriginId);
            
            CreateTable(
                "dbo.ParentCouples",
                c => new
                    {
                        ParentCoupleId = c.Int(nullable: false, identity: true),
                        MotherId = c.Int(),
                        FatherId = c.Int(),
                    })
                .PrimaryKey(t => t.ParentCoupleId)
                .ForeignKey("dbo.Fathers", t => t.FatherId)
                .ForeignKey("dbo.Mothers", t => t.MotherId)
                .Index(t => t.MotherId)
                .Index(t => t.FatherId);
            
            CreateTable(
                "dbo.Fathers",
                c => new
                    {
                        FatherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FatherId)
                .ForeignKey("dbo.Animals", t => t.FatherId, cascadeDelete: true)
                .Index(t => t.FatherId);
            
            CreateTable(
                "dbo.Mothers",
                c => new
                    {
                        MotherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MotherId)
                .ForeignKey("dbo.Animals", t => t.MotherId, cascadeDelete: true)
                .Index(t => t.MotherId);
            
            CreateTable(
                "dbo.Species",
                c => new
                    {
                        SpeciesId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Environment_EnvironmentId = c.Int(),
                        Type_TypeId = c.Int(),
                    })
                .PrimaryKey(t => t.SpeciesId)
                .ForeignKey("dbo.Environments", t => t.Environment_EnvironmentId)
                .ForeignKey("dbo.Types", t => t.Type_TypeId)
                .Index(t => t.Environment_EnvironmentId)
                .Index(t => t.Type_TypeId);
            
            CreateTable(
                "dbo.Environments",
                c => new
                    {
                        EnvironmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.EnvironmentId);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        TypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "Species_SpeciesId", "dbo.Species");
            DropForeignKey("dbo.Species", "Type_TypeId", "dbo.Types");
            DropForeignKey("dbo.Species", "Environment_EnvironmentId", "dbo.Environments");
            DropForeignKey("dbo.Animals", "ParentCouple_ParentCoupleId", "dbo.ParentCouples");
            DropForeignKey("dbo.ParentCouples", "MotherId", "dbo.Mothers");
            DropForeignKey("dbo.Mothers", "MotherId", "dbo.Animals");
            DropForeignKey("dbo.ParentCouples", "FatherId", "dbo.Fathers");
            DropForeignKey("dbo.Fathers", "FatherId", "dbo.Animals");
            DropForeignKey("dbo.Animals", "CountryOfOrigin_CountryOfOriginId", "dbo.CountryOfOrigins");
            DropIndex("dbo.Species", new[] { "Type_TypeId" });
            DropIndex("dbo.Species", new[] { "Environment_EnvironmentId" });
            DropIndex("dbo.Mothers", new[] { "MotherId" });
            DropIndex("dbo.Fathers", new[] { "FatherId" });
            DropIndex("dbo.ParentCouples", new[] { "FatherId" });
            DropIndex("dbo.ParentCouples", new[] { "MotherId" });
            DropIndex("dbo.Animals", new[] { "Species_SpeciesId" });
            DropIndex("dbo.Animals", new[] { "ParentCouple_ParentCoupleId" });
            DropIndex("dbo.Animals", new[] { "CountryOfOrigin_CountryOfOriginId" });
            DropTable("dbo.Types");
            DropTable("dbo.Environments");
            DropTable("dbo.Species");
            DropTable("dbo.Mothers");
            DropTable("dbo.Fathers");
            DropTable("dbo.ParentCouples");
            DropTable("dbo.CountryOfOrigins");
            DropTable("dbo.Animals");
        }
    }
}
