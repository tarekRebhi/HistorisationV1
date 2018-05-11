namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Histo", "Employe_EmployeID", "dbo.Employe");
            DropIndex("dbo.Histo", new[] { "Employe_EmployeID" });
            RenameColumn(table: "dbo.Histo", name: "Employe_EmployeID", newName: "EmployeID");
            AddColumn("dbo.Employe", "logDuree", c => c.String());
            AlterColumn("dbo.Histo", "EmployeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Histo", "EmployeID");
            AddForeignKey("dbo.Histo", "EmployeID", "dbo.Employe", "EmployeID", cascadeDelete: true);
            DropColumn("dbo.Employe", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employe", "Role", c => c.String());
            DropForeignKey("dbo.Histo", "EmployeID", "dbo.Employe");
            DropIndex("dbo.Histo", new[] { "EmployeID" });
            AlterColumn("dbo.Histo", "EmployeID", c => c.Int());
            DropColumn("dbo.Employe", "logDuree");
            RenameColumn(table: "dbo.Histo", name: "EmployeID", newName: "Employe_EmployeID");
            CreateIndex("dbo.Histo", "Employe_EmployeID");
            AddForeignKey("dbo.Histo", "Employe_EmployeID", "dbo.Employe", "EmployeID");
        }
    }
}
