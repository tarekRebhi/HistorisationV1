namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class time3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employe", "logEntree", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Employe", "logSortie", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Histo", "h_debut", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Histo", "h_fin", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Pause", "debut", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Pause", "fin", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pause", "fin", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Pause", "debut", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Histo", "h_fin", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Histo", "h_debut", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Employe", "logSortie", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Employe", "logEntree", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
