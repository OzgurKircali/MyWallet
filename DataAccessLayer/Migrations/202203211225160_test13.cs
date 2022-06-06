namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test13 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Incomes", "IsRepetitive", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Incomes", "IsRepetitive", c => c.Boolean(nullable: false));
        }
    }
}
