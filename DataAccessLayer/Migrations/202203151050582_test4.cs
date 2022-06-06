namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Incomes", "RepetitiveTimePeriods", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Incomes", "RepetitiveTimePeriods", c => c.Int(nullable: false));
        }
    }
}
