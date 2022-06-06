namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class transactionadd3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyWalletUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Email = c.String(),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                    MyWalletUser_Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MyWalletUsers", t => t.MyWalletUser_Id)
                .Index(t => t.MyWalletUser_Id);

            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    LoginProvider = c.String(),
                    ProviderKey = c.String(),
                    MyWalletUser_Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.MyWalletUsers", t => t.MyWalletUser_Id)
                .Index(t => t.MyWalletUser_Id);

            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                {
                    RoleId = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                    MyWalletUser_Id = c.String(maxLength: 128),
                    IdentityRole_Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.MyWalletUsers", t => t.MyWalletUser_Id)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .Index(t => t.MyWalletUser_Id)
                .Index(t => t.IdentityRole_Id);

            CreateTable(
                "dbo.IdentityRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Transactions", "Username", c => c.String());
            AddColumn("dbo.Transactions", "MyWalletUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Transactions", "MyWalletUser_Id");
            AddForeignKey("dbo.Transactions", "MyWalletUser_Id", "dbo.MyWalletUsers", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.Transactions", "MyWalletUser_Id", "dbo.MyWalletUsers");
            DropForeignKey("dbo.IdentityUserRoles", "MyWalletUser_Id", "dbo.MyWalletUsers");
            DropForeignKey("dbo.IdentityUserLogins", "MyWalletUser_Id", "dbo.MyWalletUsers");
            DropForeignKey("dbo.IdentityUserClaims", "MyWalletUser_Id", "dbo.MyWalletUsers");
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "MyWalletUser_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "MyWalletUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "MyWalletUser_Id" });
            DropIndex("dbo.Transactions", new[] { "MyWalletUser_Id" });
            DropColumn("dbo.Transactions", "MyWalletUser_Id");
            DropColumn("dbo.Transactions", "Username");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.MyWalletUsers");
        }
    }
}
