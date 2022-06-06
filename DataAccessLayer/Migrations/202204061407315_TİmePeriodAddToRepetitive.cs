namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TİmePeriodAddToRepetitive : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TimePeriods", "PeriodType_PeriodTypeID", "dbo.PeriodTypes");
            DropForeignKey("dbo.RepetitiveTransactions", "TimePeriodID", "dbo.TimePeriods");
            DropIndex("dbo.RepetitiveTransactions", new[] { "TimePeriodID" });
            DropIndex("dbo.TimePeriods", new[] { "PeriodType_PeriodTypeID" });
            AddColumn("dbo.RepetitiveTransactions", "PeriodAmount", c => c.Int(nullable: false));
            AddColumn("dbo.RepetitiveTransactions", "PeriodTypeID", c => c.String());
            AddColumn("dbo.RepetitiveTransactions", "PeriodType_PeriodTypeID", c => c.Int());
            CreateIndex("dbo.RepetitiveTransactions", "PeriodType_PeriodTypeID");
            AddForeignKey("dbo.RepetitiveTransactions", "PeriodType_PeriodTypeID", "dbo.PeriodTypes", "PeriodTypeID");
            DropColumn("dbo.RepetitiveTransactions", "TimePeriodID");
            DropTable("dbo.TimePeriods");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TimePeriods",
                c => new
                    {
                        TimePeriodID = c.Int(nullable: false, identity: true),
                        PeriodAmount = c.Int(nullable: false),
                        PeriodTypeID = c.String(),
                        PeriodType_PeriodTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.TimePeriodID);
            
            AddColumn("dbo.RepetitiveTransactions", "TimePeriodID", c => c.Int(nullable: false));
            DropForeignKey("dbo.RepetitiveTransactions", "PeriodType_PeriodTypeID", "dbo.PeriodTypes");
            DropIndex("dbo.RepetitiveTransactions", new[] { "PeriodType_PeriodTypeID" });
            DropColumn("dbo.RepetitiveTransactions", "PeriodType_PeriodTypeID");
            DropColumn("dbo.RepetitiveTransactions", "PeriodTypeID");
            DropColumn("dbo.RepetitiveTransactions", "PeriodAmount");
            CreateIndex("dbo.TimePeriods", "PeriodType_PeriodTypeID");
            CreateIndex("dbo.RepetitiveTransactions", "TimePeriodID");
            AddForeignKey("dbo.RepetitiveTransactions", "TimePeriodID", "dbo.TimePeriods", "TimePeriodID", cascadeDelete: true);
            AddForeignKey("dbo.TimePeriods", "PeriodType_PeriodTypeID", "dbo.PeriodTypes", "PeriodTypeID");
        }
    }
}
