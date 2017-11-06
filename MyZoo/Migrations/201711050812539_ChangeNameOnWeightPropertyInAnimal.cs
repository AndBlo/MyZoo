namespace MyZoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNameOnWeightPropertyInAnimal : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Animals", name: "Vikt(kg)", newName: "Weight(kg)");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Animals", name: "Weight(kg)", newName: "Vikt(kg)");
        }
    }
}
