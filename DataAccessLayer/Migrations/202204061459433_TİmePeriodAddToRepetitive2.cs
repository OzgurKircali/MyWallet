namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TİmePeriodAddToRepetitive2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RepetitiveTransactions", "PeriodType_PeriodTypeID", "dbo.PeriodTypes");
            DropIndex("dbo.RepetitiveTransactions", new[] { "PeriodType_PeriodTypeID" });
            DropColumn("dbo.RepetitiveTransactions", "PeriodTypeID");
            RenameColumn(table: "dbo.RepetitiveTransactions", name: "PeriodType_PeriodTypeID", newName: "PeriodTypeID");
            AlterColumn("dbo.RepetitiveTransactions", "PeriodTypeID", c => c.Int(nullable: false));
            AlterColumn("dbo.RepetitiveTransactions", "PeriodTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.RepetitiveTransactions", "PeriodTypeID");
            AddForeignKey("dbo.RepetitiveTransactions", "PeriodTypeID", "dbo.PeriodTypes", "PeriodTypeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RepetitiveTransactions", "PeriodTypeID", "dbo.PeriodTypes");
            DropIndex("dbo.RepetitiveTransactions", new[] { "PeriodTypeID" });
            AlterColumn("dbo.RepetitiveTransactions", "PeriodTypeID", c => c.Int());
            AlterColumn("dbo.RepetitiveTransactions", "PeriodTypeID", c => c.String());
            RenameColumn(table: "dbo.RepetitiveTransactions", name: "PeriodTypeID", newName: "PeriodType_PeriodTypeID");
            AddColumn("dbo.RepetitiveTransactions", "PeriodTypeID", c => c.String());
            CreateIndex("dbo.RepetitiveTransactions", "PeriodType_PeriodTypeID");
            AddForeignKey("dbo.RepetitiveTransactions", "PeriodType_PeriodTypeID", "dbo.PeriodTypes", "PeriodTypeID");
        }
    }
}
