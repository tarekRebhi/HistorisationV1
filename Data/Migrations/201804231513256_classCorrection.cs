namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class classCorrection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Histo",
                c => new
                    {
                        HistoID = c.Int(nullable: false, identity: true),
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
                .PrimaryKey(t => t.HistoID)
                .ForeignKey("dbo.Employe", t => t.Employe_EmployeID)
                .Index(t => t.Employe_EmployeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Histo", "Employe_EmployeID", "dbo.Employe");
            DropIndex("dbo.Histo", new[] { "Employe_EmployeID" });
            DropTable("dbo.Histo");
        }
    }
}
