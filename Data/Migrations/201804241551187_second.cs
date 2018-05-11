namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Histo", "Employe_EmployeID", "dbo.Employe");
            DropIndex("dbo.Historisation", new[] { "Employe_EmployeID" });
            AddColumn("dbo.Employe", "logEntree", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employe", "logSortie", c => c.DateTime(nullable: false));
            DropTable("dbo.Historisation");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Historisation",
                c => new
                    {
                        HistorisationID = c.Int(nullable: false, identity: true),
                        poles = c.String(),
                        mission = c.String(),
                        tache = c.String(),
                        site = c.String(),
                        nbDossiersTr = c.Int(nullable: false),
                        h_debut = c.DateTime(nullable: false),
                        h_fin = c.DateTime(nullable: false),
                        duree = c.String(),
                        departement = c.String(),
                        Employe_EmployeID = c.Int(),
                    })
                .PrimaryKey(t => t.HistorisationID);
            
            DropColumn("dbo.Employe", "logSortie");
            DropColumn("dbo.Employe", "logEntree");
            CreateIndex("dbo.Historisation", "Employe_EmployeID");
            AddForeignKey("dbo.Histo", "Employe_EmployeID", "dbo.Employe", "EmployeID");
        }
    }
}
