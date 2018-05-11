namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employe",
                c => new
                    {
                        EmployeID = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Nom = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.EmployeID);
            
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
                .PrimaryKey(t => t.HistorisationID)
                .ForeignKey("dbo.Employe", t => t.Employe_EmployeID)
                .Index(t => t.Employe_EmployeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Historisation", "Employe_EmployeID", "dbo.Employe");
            DropIndex("dbo.Historisation", new[] { "Employe_EmployeID" });
            DropTable("dbo.Historisation");
            DropTable("dbo.Employe");
        }
    }
}
