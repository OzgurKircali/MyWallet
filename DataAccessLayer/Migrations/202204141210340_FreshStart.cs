namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FreshStart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AutomaticOrManuels",
                c => new
                    {
                        AutomaticOrManuelID = c.Int(nullable: false, identity: true),
                        AutomaticOrManuelName = c.String(),
                    })
                .PrimaryKey(t => t.AutomaticOrManuelID);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        TransactionAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransactionDate = c.DateTime(nullable: false),
                        TransactionDescription = c.String(maxLength: 30),
                        Id = c.String(maxLength: 128),
                        TypeID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        AutomaticOrManuelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.TransactionCategories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.TransactionTypes", t => t.TypeID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.AutomaticOrManuels", t => t.AutomaticOrManuelID, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.TypeID)
                .Index(t => t.CategoryID)
                .Index(t => t.AutomaticOrManuelID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Investments",
                c => new
                    {
                        InvestmentID = c.Int(nullable: false, identity: true),
                        InvestmentAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyID = c.Int(nullable: false),
                        Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.InvestmentID)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.CurrencyID, cascadeDelete: true)
                .Index(t => t.CurrencyID)
                .Index(t => t.Id);
            
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
                "dbo.Loans",
                c => new
                    {
                        LoanID = c.Int(nullable: false, identity: true),
                        LoanAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LoanDebt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LoanDate = c.DateTime(nullable: false),
                        Instalment = c.Int(nullable: false),
                        PaymentDay = c.Int(nullable: false),
                        LoanDescription = c.String(maxLength: 30),
                        Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.LoanID)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.RepetitiveTransactions",
                c => new
                    {
                        RepetitiveTransactionID = c.Int(nullable: false, identity: true),
                        RepetitiveTransactionAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RepetitiveTransactionDate = c.DateTime(nullable: false),
                        RepetitiveTransactionDescription = c.String(maxLength: 30),
                        PeriodAmount = c.Int(nullable: false),
                        PeriodTypeID = c.Int(nullable: false),
                        Id = c.String(maxLength: 128),
                        TypeID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RepetitiveTransactionID)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.PeriodTypes", t => t.PeriodTypeID, cascadeDelete: true)
                .ForeignKey("dbo.TransactionCategories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.TransactionTypes", t => t.TypeID, cascadeDelete: true)
                .Index(t => t.PeriodTypeID)
                .Index(t => t.Id)
                .Index(t => t.TypeID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.PeriodTypes",
                c => new
                    {
                        PeriodTypeID = c.Int(nullable: false, identity: true),
                        PeriodTypeName = c.String(),
                    })
                .PrimaryKey(t => t.PeriodTypeID);
            
            CreateTable(
                "dbo.TransactionCategories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.TransactionTypes",
                c => new
                    {
                        TypeID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.TypeID);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Transactions", "AutomaticOrManuelID", "dbo.AutomaticOrManuels");
            DropForeignKey("dbo.Transactions", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Transactions", "TypeID", "dbo.TransactionTypes");
            DropForeignKey("dbo.RepetitiveTransactions", "TypeID", "dbo.TransactionTypes");
            DropForeignKey("dbo.Transactions", "CategoryID", "dbo.TransactionCategories");
            DropForeignKey("dbo.RepetitiveTransactions", "CategoryID", "dbo.TransactionCategories");
            DropForeignKey("dbo.RepetitiveTransactions", "PeriodTypeID", "dbo.PeriodTypes");
            DropForeignKey("dbo.RepetitiveTransactions", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Loans", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Investments", "CurrencyID", "dbo.Currencies");
            DropForeignKey("dbo.Investments", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.RepetitiveTransactions", new[] { "CategoryID" });
            DropIndex("dbo.RepetitiveTransactions", new[] { "TypeID" });
            DropIndex("dbo.RepetitiveTransactions", new[] { "Id" });
            DropIndex("dbo.RepetitiveTransactions", new[] { "PeriodTypeID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Loans", new[] { "Id" });
            DropIndex("dbo.Investments", new[] { "Id" });
            DropIndex("dbo.Investments", new[] { "CurrencyID" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Transactions", new[] { "AutomaticOrManuelID" });
            DropIndex("dbo.Transactions", new[] { "CategoryID" });
            DropIndex("dbo.Transactions", new[] { "TypeID" });
            DropIndex("dbo.Transactions", new[] { "Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.TransactionTypes");
            DropTable("dbo.TransactionCategories");
            DropTable("dbo.PeriodTypes");
            DropTable("dbo.RepetitiveTransactions");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Loans");
            DropTable("dbo.Currencies");
            DropTable("dbo.Investments");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Transactions");
            DropTable("dbo.AutomaticOrManuels");
        }
    }
}
