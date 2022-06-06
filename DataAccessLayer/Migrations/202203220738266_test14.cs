namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test14 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MonthlyBalances", "WhichMonth", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MonthlyBalances", "WhichMonth", c => c.String(maxLength: 20));
        }
    }
}
