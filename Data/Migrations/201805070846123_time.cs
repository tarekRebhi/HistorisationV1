namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class time : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pause",
                c => new
                    {
                        PauseID = c.Int(nullable: false, identity: true),
                        type = c.String(),
                        debut = c.DateTime(precision: 7, storeType: "datetime2"),
                        fin = c.DateTime(precision: 7, storeType: "datetime2"),
                        duree = c.String(),
                        EmployeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PauseID)
                .ForeignKey("dbo.Employe", t => t.EmployeID, cascadeDelete: true)
                .Index(t => t.EmployeID);
            
            AlterColumn("dbo.Employe", "logEntree", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Employe", "logSortie", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Histo", "h_debut", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Histo", "h_fin", c => c.DateTime(precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Employe", "Nom");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employe", "Nom", c => c.String());
            DropForeignKey("dbo.Pause", "EmployeID", "dbo.Employe");
            DropIndex("dbo.Pause", new[] { "EmployeID" });
            AlterColumn("dbo.Histo", "h_fin", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Histo", "h_debut", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employe", "logSortie", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Employe", "logEntree", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropTable("dbo.Pause");
        }
    }
}
