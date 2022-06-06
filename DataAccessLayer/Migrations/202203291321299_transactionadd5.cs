namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactionadd5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Investments", "Username", c => c.String());
            AddColumn("dbo.Investments", "MyWalletUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Loans", "Username", c => c.String());
            AddColumn("dbo.Loans", "MyWalletUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Investments", "MyWalletUser_Id");
            CreateIndex("dbo.Loans", "MyWalletUser_Id");
            AddForeignKey("dbo.Investments", "MyWalletUser_Id", "dbo.MyWalletUsers", "Id");
            AddForeignKey("dbo.Loans", "MyWalletUser_Id", "dbo.MyWalletUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "MyWalletUser_Id", "dbo.MyWalletUsers");
            DropForeignKey("dbo.Investments", "MyWalletUser_Id", "dbo.MyWalletUsers");
            DropIndex("dbo.Loans", new[] { "MyWalletUser_Id" });
            DropIndex("dbo.Investments", new[] { "MyWalletUser_Id" });
            DropColumn("dbo.Loans", "MyWalletUser_Id");
            DropColumn("dbo.Loans", "Username");
            DropColumn("dbo.Investments", "MyWalletUser_Id");
            DropColumn("dbo.Investments", "Username");
        }
    }
}
