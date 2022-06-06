namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactionadd4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        CurrencyID = c.Int(nullable: false, identity: true),
                        CurrencName = c.String(),
                        CurrencyValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CurrencyID);
            
            CreateTable(
                "dbo.RepetitiveTransactions",
                c => new
                    {
                        RepetitiveTransactionID = c.Int(nullable: false, identity: true),
                        RepetitiveTransactionAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RepetitiveTransactionDate = c.DateTime(nullable: false),
                        RepetitiveTransactionDescription = c.String(maxLength: 30),
                        Username = c.String(),
                        TypeID = c.Int(nullable: false),
                        TimePeriodID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        MyWalletUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RepetitiveTransactionID)
                .ForeignKey("dbo.MyWalletUsers", t => t.MyWalletUser_Id)
                .ForeignKey("dbo.TransactionTypes", t => t.TypeID, cascadeDelete: true)
                .ForeignKey("dbo.TimePeriods", t => t.TimePeriodID, cascadeDelete: true)
                .ForeignKey("dbo.TransactionCategories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.TypeID)
                .Index(t => t.TimePeriodID)
                .Index(t => t.CategoryID)
                .Index(t => t.MyWalletUser_Id);
            
            CreateTable(
                "dbo.AutomaticOrManuels",
                c => new
                    {
                        AutomaticOrManuelID = c.Int(nullable: false, identity: true),
                        AutomaticOrManuelName = c.String(),
                    })
                .PrimaryKey(t => t.AutomaticOrManuelID);
            
            CreateTable(
                "dbo.TimePeriods",
                c => new
                    {
                        TimePeriodID = c.Int(nullable: false, identity: true),
                        PeriodAmount = c.Int(nullable: false),
                        PeriodTypeID = c.String(),
                        PeriodType_PeriodTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.TimePeriodID)
                .ForeignKey("dbo.PeriodTypes", t => t.PeriodType_PeriodTypeID)
                .Index(t => t.PeriodType_PeriodTypeID);
            
            CreateTable(
                "dbo.PeriodTypes",
                c => new
                    {
                        PeriodTypeID = c.Int(nullable: false, identity: true),
                        PeriodTypeName = c.String(),
                    })
                .PrimaryKey(t => t.PeriodTypeID);
            
            AddColumn("dbo.Investments", "InvestmentAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Investments", "CurrencyID", c => c.Int(nullable: false));
            AddColumn("dbo.Loans", "LoanAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Loans", "LoanDebt", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Loans", "LoanDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Loans", "LoanDescription", c => c.String(maxLength: 30));
            AddColumn("dbo.Transactions", "AutomaticOrManuelID", c => c.Int(nullable: false));
            CreateIndex("dbo.Investments", "CurrencyID");
            CreateIndex("dbo.Transactions", "AutomaticOrManuelID");
            AddForeignKey("dbo.Investments", "CurrencyID", "dbo.Currencies", "CurrencyID", cascadeDelete: true);
            AddForeignKey("dbo.Transactions", "AutomaticOrManuelID", "dbo.AutomaticOrManuels", "AutomaticOrManuelID", cascadeDelete: true);
            DropColumn("dbo.Investments", "InvestmentAsTL");
            DropColumn("dbo.Loans", "TotalDebt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Loans", "TotalDebt", c => c.Single(nullable: false));
            AddColumn("dbo.Investments", "InvestmentAsTL", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.RepetitiveTransactions", "CategoryID", "dbo.TransactionCategories");
            DropForeignKey("dbo.RepetitiveTransactions", "TimePeriodID", "dbo.TimePeriods");
            DropForeignKey("dbo.TimePeriods", "PeriodType_PeriodTypeID", "dbo.PeriodTypes");
            DropForeignKey("dbo.RepetitiveTransactions", "TypeID", "dbo.TransactionTypes");
            DropForeignKey("dbo.Transactions", "AutomaticOrManuelID", "dbo.AutomaticOrManuels");
            DropForeignKey("dbo.RepetitiveTransactions", "MyWalletUser_Id", "dbo.MyWalletUsers");
            DropForeignKey("dbo.Investments", "CurrencyID", "dbo.Currencies");
            DropIndex("dbo.TimePeriods", new[] { "PeriodType_PeriodTypeID" });
            DropIndex("dbo.Transactions", new[] { "AutomaticOrManuelID" });
            DropIndex("dbo.RepetitiveTransactions", new[] { "MyWalletUser_Id" });
            DropIndex("dbo.RepetitiveTransactions", new[] { "CategoryID" });
            DropIndex("dbo.RepetitiveTransactions", new[] { "TimePeriodID" });
            DropIndex("dbo.RepetitiveTransactions", new[] { "TypeID" });
            DropIndex("dbo.Investments", new[] { "CurrencyID" });
            DropColumn("dbo.Transactions", "AutomaticOrManuelID");
            DropColumn("dbo.Loans", "LoanDescription");
            DropColumn("dbo.Loans", "LoanDate");
            DropColumn("dbo.Loans", "LoanDebt");
            DropColumn("dbo.Loans", "LoanAmount");
            DropColumn("dbo.Investments", "CurrencyID");
            DropColumn("dbo.Investments", "InvestmentAmount");
            DropTable("dbo.PeriodTypes");
            DropTable("dbo.TimePeriods");
            DropTable("dbo.AutomaticOrManuels");
            DropTable("dbo.RepetitiveTransactions");
            DropTable("dbo.Currencies");
        }
    }
}
