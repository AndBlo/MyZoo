namespace MyZoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptionalForeignKeysToAnimal : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Animals", name: "CountryOfOrigin_CountryOfOriginId", newName: "CountryOfOriginId");
            RenameColumn(table: "dbo.Animals", name: "ParentCouple_ParentCoupleId", newName: "ParentCoupleId");
            RenameColumn(table: "dbo.Animals", name: "Species_SpeciesId", newName: "SpeciesId");
            RenameIndex(table: "dbo.Animals", name: "IX_Species_SpeciesId", newName: "IX_SpeciesId");
            RenameIndex(table: "dbo.Animals", name: "IX_ParentCouple_ParentCoupleId", newName: "IX_ParentCoupleId");
            RenameIndex(table: "dbo.Animals", name: "IX_CountryOfOrigin_CountryOfOriginId", newName: "IX_CountryOfOriginId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Animals", name: "IX_CountryOfOriginId", newName: "IX_CountryOfOrigin_CountryOfOriginId");
            RenameIndex(table: "dbo.Animals", name: "IX_ParentCoupleId", newName: "IX_ParentCouple_ParentCoupleId");
            RenameIndex(table: "dbo.Animals", name: "IX_SpeciesId", newName: "IX_Species_SpeciesId");
            RenameColumn(table: "dbo.Animals", name: "SpeciesId", newName: "Species_SpeciesId");
            RenameColumn(table: "dbo.Animals", name: "ParentCoupleId", newName: "ParentCouple_ParentCoupleId");
            RenameColumn(table: "dbo.Animals", name: "CountryOfOriginId", newName: "CountryOfOrigin_CountryOfOriginId");
        }
    }
}
