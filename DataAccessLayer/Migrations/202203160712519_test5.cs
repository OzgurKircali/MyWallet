namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Expanses", "IsRepetitive", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Expanses", "IsRepetitive", c => c.Boolean(nullable: false));
        }
    }
}
