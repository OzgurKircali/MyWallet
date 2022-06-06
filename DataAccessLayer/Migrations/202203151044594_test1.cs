namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Incomes", "Description", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.AnnualyBalances", "AnnualyIncome", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.AnnualyBalances", "AnnualyExpanse", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.AnnualyBalances", "ThatYearsBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "UserEmail", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "UserPassword", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Expanses", "AmountOfExpanse", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Expanses", "Description", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Expanses", "ExpanseCategory", c => c.String(nullable: false));
            AlterColumn("dbo.Incomes", "AmountOfIncome", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Investments", "InvestmentAsTL", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Investments", "InvestmentAsOtherType", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.CurrencyTypes", "CurrencyName", c => c.String(maxLength: 20));
            AlterColumn("dbo.DailyBalances", "DailyIncome", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.DailyBalances", "DailyExpanse", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.DailyBalances", "ThatDayBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.MonthlyBalances", "MonthlyIncome", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.MonthlyBalances", "MonthlyExpanse", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.MonthlyBalances", "ThatMonthsBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MonthlyBalances", "ThatMonthsBalance", c => c.Single(nullable: false));
            AlterColumn("dbo.MonthlyBalances", "MonthlyExpanse", c => c.Single(nullable: false));
            AlterColumn("dbo.MonthlyBalances", "MonthlyIncome", c => c.Single(nullable: false));
            AlterColumn("dbo.DailyBalances", "ThatDayBalance", c => c.Single(nullable: false));
            AlterColumn("dbo.DailyBalances", "DailyExpanse", c => c.Single(nullable: false));
            AlterColumn("dbo.DailyBalances", "DailyIncome", c => c.Single(nullable: false));
            AlterColumn("dbo.CurrencyTypes", "CurrencyName", c => c.String(maxLength: 10));
            AlterColumn("dbo.Investments", "InvestmentAsOtherType", c => c.Single(nullable: false));
            AlterColumn("dbo.Investments", "InvestmentAsTL", c => c.Single(nullable: false));
            AlterColumn("dbo.Incomes", "AmountOfIncome", c => c.Single(nullable: false));
            AlterColumn("dbo.Expanses", "ExpanseCategory", c => c.String());
            AlterColumn("dbo.Expanses", "Description", c => c.String());
            AlterColumn("dbo.Expanses", "AmountOfExpanse", c => c.Single(nullable: false));
            AlterColumn("dbo.Users", "UserPassword", c => c.String(maxLength: 20));
            AlterColumn("dbo.Users", "UserEmail", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "UserName", c => c.String(maxLength: 20));
            AlterColumn("dbo.AnnualyBalances", "ThatYearsBalance", c => c.Single(nullable: false));
            AlterColumn("dbo.AnnualyBalances", "AnnualyExpanse", c => c.Single(nullable: false));
            AlterColumn("dbo.AnnualyBalances", "AnnualyIncome", c => c.Single(nullable: false));
            DropColumn("dbo.Incomes", "Description");
        }
    }
}
