namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usernameToId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Transactions", name: "MyWalletUser_Id", newName: "Id");
            RenameColumn(table: "dbo.Investments", name: "MyWalletUser_Id", newName: "Id");
            RenameColumn(table: "dbo.Loans", name: "MyWalletUser_Id", newName: "Id");
            RenameColumn(table: "dbo.RepetitiveTransactions", name: "MyWalletUser_Id", newName: "Id");
            RenameIndex(table: "dbo.Transactions", name: "IX_MyWalletUser_Id", newName: "IX_Id");
            RenameIndex(table: "dbo.Investments", name: "IX_MyWalletUser_Id", newName: "IX_Id");
            RenameIndex(table: "dbo.Loans", name: "IX_MyWalletUser_Id", newName: "IX_Id");
            RenameIndex(table: "dbo.RepetitiveTransactions", name: "IX_MyWalletUser_Id", newName: "IX_Id");
            DropColumn("dbo.Transactions", "Username");
            DropColumn("dbo.Investments", "Username");
            DropColumn("dbo.Loans", "Username");
            DropColumn("dbo.RepetitiveTransactions", "Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RepetitiveTransactions", "Username", c => c.String());
            AddColumn("dbo.Loans", "Username", c => c.String());
            AddColumn("dbo.Investments", "Username", c => c.String());
            AddColumn("dbo.Transactions", "Username", c => c.String());
            RenameIndex(table: "dbo.RepetitiveTransactions", name: "IX_Id", newName: "IX_MyWalletUser_Id");
            RenameIndex(table: "dbo.Loans", name: "IX_Id", newName: "IX_MyWalletUser_Id");
            RenameIndex(table: "dbo.Investments", name: "IX_Id", newName: "IX_MyWalletUser_Id");
            RenameIndex(table: "dbo.Transactions", name: "IX_Id", newName: "IX_MyWalletUser_Id");
            RenameColumn(table: "dbo.RepetitiveTransactions", name: "Id", newName: "MyWalletUser_Id");
            RenameColumn(table: "dbo.Loans", name: "Id", newName: "MyWalletUser_Id");
            RenameColumn(table: "dbo.Investments", name: "Id", newName: "MyWalletUser_Id");
            RenameColumn(table: "dbo.Transactions", name: "Id", newName: "MyWalletUser_Id");
        }
    }
}
