namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test16 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expanses", "UserID", "dbo.Users");
            DropIndex("dbo.Expanses", new[] { "UserID" });
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ExpenseID = c.Int(nullable: false, identity: true),
                        DateOfExpense = c.DateTime(nullable: false),
                        AmountOfExpense = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsRepetitive = c.Boolean(),
                        RepetetiveTimePeriod = c.Int(),
                        Description = c.String(nullable: false, maxLength: 30),
                        ExpenseCategory = c.String(nullable: false, maxLength: 30),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExpenseID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.ExpenseCategories",
                c => new
                    {
                        ExpenseCategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.ExpenseCategoryID);
            
            AddColumn("dbo.AnnualyBalances", "AnnualyExpense", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DailyBalances", "DailyExpense", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.MonthlyBalances", "MonthlyExpense", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.AnnualyBalances", "AnnualyExpanse");
            DropColumn("dbo.Investments", "InvestmentAsOtherType");
            DropColumn("dbo.DailyBalances", "DailyExpanse");
            DropColumn("dbo.MonthlyBalances", "MonthlyExpanse");
            DropTable("dbo.Expanses");
            DropTable("dbo.ExpanseCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ExpanseCategories",
                c => new
                    {
                        ExpanseCategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.ExpanseCategoryID);
            
            CreateTable(
                "dbo.Expanses",
                c => new
                    {
                        ExpanseID = c.Int(nullable: false, identity: true),
                        DateOfExpanse = c.DateTime(nullable: false),
                        AmountOfExpanse = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsRepetitive = c.Boolean(),
                        RepetetiveTimePeriod = c.Int(),
                        Description = c.String(nullable: false, maxLength: 30),
                        ExpanseCategory = c.String(nullable: false, maxLength: 30),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExpanseID);
            
            AddColumn("dbo.MonthlyBalances", "MonthlyExpanse", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DailyBalances", "DailyExpanse", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Investments", "InvestmentAsOtherType", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.AnnualyBalances", "AnnualyExpanse", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.Expenses", "UserID", "dbo.Users");
            DropIndex("dbo.Expenses", new[] { "UserID" });
            DropColumn("dbo.MonthlyBalances", "MonthlyExpense");
            DropColumn("dbo.DailyBalances", "DailyExpense");
            DropColumn("dbo.AnnualyBalances", "AnnualyExpense");
            DropTable("dbo.ExpenseCategories");
            DropTable("dbo.Expenses");
            CreateIndex("dbo.Expanses", "UserID");
            AddForeignKey("dbo.Expanses", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
    }
}
