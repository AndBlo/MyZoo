namespace MyZoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeWeightToIntegerAndNamedToKilo : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Animals", name: "Weight", newName: "Vikt(kg)");
            AlterColumn("dbo.Animals", "Vikt(kg)", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Animals", "Vikt(kg)", c => c.String());
            RenameColumn(table: "dbo.Animals", name: "Vikt(kg)", newName: "Weight");
        }
    }
}
