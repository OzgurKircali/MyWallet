﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Expanses", "RepetetiveTimePeriod", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Expanses", "RepetetiveTimePeriod", c => c.Int(nullable: false));
        }
    }
}
