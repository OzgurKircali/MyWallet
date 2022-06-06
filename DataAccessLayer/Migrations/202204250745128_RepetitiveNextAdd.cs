namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepetitiveNextAdd : DbMigration
    {
        public override void Up()
        {

            AddColumn("dbo.RepetitiveTransactions", "RepetitiveTransactionNextDate", c => c.DateTime(nullable: false));

        }
        public override void Down()
        {
            
            DropColumn("dbo.RepetitiveTransactions", "RepetitiveTransactionNextDate");
            
        }
    }
}
