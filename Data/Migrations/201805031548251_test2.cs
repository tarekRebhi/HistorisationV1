namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employe", "logEntree", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Employe", "logSortie", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employe", "logSortie", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employe", "logEntree", c => c.DateTime(nullable: false));
        }
    }
}
