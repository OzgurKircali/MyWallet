namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test121 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpanseCategories",
                c => new
                    {
                        ExpanseCategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.ExpanseCategoryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExpanseCategories");
        }
    }
}
