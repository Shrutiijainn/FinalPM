namespace ProjectManagerDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeindatatype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "ProjectStartDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Projects", "ProjectEndDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Tasks", "TaskStartDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Tasks", "TaskEndDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "TaskEndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tasks", "TaskStartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "ProjectEndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "ProjectStartDate", c => c.DateTime(nullable: false));
        }
    }
}
