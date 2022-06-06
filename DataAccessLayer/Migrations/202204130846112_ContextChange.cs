namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContextChange : DbMigration
    {
        public override void Up()
        {


            //DropForeignKey("dbo.IdentityUserClaims", "MyWalletUser_Id", "dbo.MyWalletUsers");
            //DropForeignKey("dbo.IdentityUserLogins", "MyWalletUser_Id", "dbo.MyWalletUsers");
            //DropForeignKey("dbo.IdentityUserRoles", "MyWalletUser_Id", "dbo.MyWalletUsers");
            //DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            //RenameTable(name: "dbo.MyWalletUsers", newName: "AspNetUsers");
            //RenameTable(name: "dbo.IdentityUserClaims", newName: "AspNetUserClaims");
            //RenameTable(name: "dbo.IdentityUserLogins", newName: "AspNetUserLogins");
            //RenameTable(name: "dbo.IdentityUserRoles", newName: "AspNetUserRoles");
            //RenameTable(name: "dbo.IdentityRoles", newName: "AspNetRoles");
            //DropIndex("dbo.AspNetUserClaims", new[] { "MyWalletUser_Id" });
            //DropIndex("dbo.AspNetUserLogins", new[] { "MyWalletUser_Id" });
            //DropIndex("dbo.AspNetUserRoles", new[] { "MyWalletUser_Id" });
            //DropIndex("dbo.AspNetUserRoles", new[] { "IdentityRole_Id" });
            //DropColumn("dbo.AspNetUserClaims", "UserId");
            //DropColumn("dbo.AspNetUserLogins", "UserId");
            //DropColumn("dbo.AspNetUserRoles", "UserId");
            //DropColumn("dbo.AspNetUserRoles", "RoleId");
            //RenameColumn(table: "dbo.AspNetUserClaims", name: "MyWalletUser_Id", newName: "UserId");
            //RenameColumn(table: "dbo.AspNetUserLogins", name: "MyWalletUser_Id", newName: "UserId");
            //RenameColumn(table: "dbo.AspNetUserRoles", name: "MyWalletUser_Id", newName: "UserId");
            //RenameColumn(table: "dbo.AspNetUserRoles", name: "IdentityRole_Id", newName: "RoleId");
            //DropPrimaryKey("dbo.AspNetUserLogins");
            //DropPrimaryKey("dbo.AspNetUserRoles");
            //AlterColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            //AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false, maxLength: 256));
            //AlterColumn("dbo.AspNetUserClaims", "UserId", c => c.String(nullable: false, maxLength: 128));
            //AlterColumn("dbo.AspNetUserClaims", "UserId", c => c.String(nullable: false, maxLength: 128));
            //AlterColumn("dbo.AspNetUserLogins", "LoginProvider", c => c.String(nullable: false, maxLength: 128));
            //AlterColumn("dbo.AspNetUserLogins", "ProviderKey", c => c.String(nullable: false, maxLength: 128));
            //AlterColumn("dbo.AspNetUserLogins", "UserId", c => c.String(nullable: false, maxLength: 128));
            //AlterColumn("dbo.AspNetUserRoles", "UserId", c => c.String(nullable: false, maxLength: 128));
            //AlterColumn("dbo.AspNetUserRoles", "RoleId", c => c.String(nullable: false, maxLength: 128));
            //AlterColumn("dbo.AspNetRoles", "Name", c => c.String(nullable: false, maxLength: 256));
            //AddPrimaryKey("dbo.AspNetUserLogins", new[] { "LoginProvider", "ProviderKey", "UserId" });
            //AddPrimaryKey("dbo.AspNetUserRoles", new[] { "UserId", "RoleId" });
            //CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
            //CreateIndex("dbo.AspNetUserClaims", "UserId");
            //CreateIndex("dbo.AspNetUserLogins", "UserId");
            //CreateIndex("dbo.AspNetUserRoles", "UserId");
            //CreateIndex("dbo.AspNetUserRoles", "RoleId");
            //CreateIndex("dbo.AspNetRoles", "Name", unique: true, name: "RoleNameIndex");
            //AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
        //    DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
        //    DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
        //    DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
        //    DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
        //    DropIndex("dbo.AspNetRoles", "RoleNameIndex");
        //    DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
        //    DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
        //    DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
        //    DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
        //    DropIndex("dbo.AspNetUsers", "UserNameIndex");
        //    DropPrimaryKey("dbo.AspNetUserRoles");
        //    DropPrimaryKey("dbo.AspNetUserLogins");
        //    AlterColumn("dbo.AspNetRoles", "Name", c => c.String());
        //    AlterColumn("dbo.AspNetUserRoles", "RoleId", c => c.String(maxLength: 128));
        //    AlterColumn("dbo.AspNetUserRoles", "UserId", c => c.String(maxLength: 128));
        //    AlterColumn("dbo.AspNetUserLogins", "UserId", c => c.String(maxLength: 128));
        //    AlterColumn("dbo.AspNetUserLogins", "ProviderKey", c => c.String());
        //    AlterColumn("dbo.AspNetUserLogins", "LoginProvider", c => c.String());
        //    AlterColumn("dbo.AspNetUserClaims", "UserId", c => c.String(maxLength: 128));
        //    AlterColumn("dbo.AspNetUserClaims", "UserId", c => c.String());
        //    AlterColumn("dbo.AspNetUsers", "UserName", c => c.String());
        //    AlterColumn("dbo.AspNetUsers", "Email", c => c.String());
        //    AddPrimaryKey("dbo.AspNetUserRoles", new[] { "RoleId", "UserId" });
        //    AddPrimaryKey("dbo.AspNetUserLogins", "UserId");
        //    RenameColumn(table: "dbo.AspNetUserRoles", name: "RoleId", newName: "IdentityRole_Id");
        //    RenameColumn(table: "dbo.AspNetUserRoles", name: "UserId", newName: "MyWalletUser_Id");
        //    RenameColumn(table: "dbo.AspNetUserLogins", name: "UserId", newName: "MyWalletUser_Id");
        //    RenameColumn(table: "dbo.AspNetUserClaims", name: "UserId", newName: "MyWalletUser_Id");
        //    AddColumn("dbo.AspNetUserRoles", "RoleId", c => c.String(nullable: false, maxLength: 128));
        //    AddColumn("dbo.AspNetUserRoles", "UserId", c => c.String(nullable: false, maxLength: 128));
        //    AddColumn("dbo.AspNetUserLogins", "UserId", c => c.String(nullable: false, maxLength: 128));
        //    AddColumn("dbo.AspNetUserClaims", "UserId", c => c.String());
        //    CreateIndex("dbo.AspNetUserRoles", "IdentityRole_Id");
        //    CreateIndex("dbo.AspNetUserRoles", "MyWalletUser_Id");
        //    CreateIndex("dbo.AspNetUserLogins", "MyWalletUser_Id");
        //    CreateIndex("dbo.AspNetUserClaims", "MyWalletUser_Id");
        //    AddForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles", "Id");
        //    AddForeignKey("dbo.IdentityUserRoles", "MyWalletUser_Id", "dbo.MyWalletUsers", "Id");
        //    AddForeignKey("dbo.IdentityUserLogins", "MyWalletUser_Id", "dbo.MyWalletUsers", "Id");
        //    AddForeignKey("dbo.IdentityUserClaims", "MyWalletUser_Id", "dbo.MyWalletUsers", "Id");
        //    RenameTable(name: "dbo.AspNetRoles", newName: "IdentityRoles");
        //    RenameTable(name: "dbo.AspNetUserRoles", newName: "IdentityUserRoles");
        //    RenameTable(name: "dbo.AspNetUserLogins", newName: "IdentityUserLogins");
        //    RenameTable(name: "dbo.AspNetUserClaims", newName: "IdentityUserClaims");
        //    RenameTable(name: "dbo.AspNetUsers", newName: "MyWalletUsers");
        }
    }
}
