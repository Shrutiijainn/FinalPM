namespace ProjectManagerDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectandEmployeeentityadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false, maxLength: 30, unicode: false),
                        EmployeeDesignation = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectTitle = c.String(nullable: false, maxLength: 50, unicode: false),
                        ProjectStartDate = c.DateTime(nullable: false),
                        ProjectEndDate = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: false)
                .Index(t => t.EmployeeId);
            

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Projects", new[] { "EmployeeId" });
            DropTable("dbo.Projects");
            DropTable("dbo.Employees");
        }
    }
}
