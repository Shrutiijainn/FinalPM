namespace ProjectManagerDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedchangedb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Tasks", new[] { "EmployeeId" });
            DropIndex("dbo.Tasks", new[] { "ProjectId" });
            CreateTable(
                "dbo.TaskNs",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        TaskName = c.String(nullable: false, maxLength: 100, unicode: false),
                        TaskDescription = c.String(maxLength: 300, unicode: false),
                        TaskStartDate = c.DateTime(nullable: false, storeType: "date"),
                        TaskEndDate = c.DateTime(nullable: false, storeType: "date"),
                        TaskPriority = c.Int(nullable: false),
                        TaskStatus = c.String(maxLength: 8000, unicode: false),
                        ProjectId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: false)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: false)
                .Index(t => t.EmployeeId)
                .Index(t => t.ProjectId);
            
            DropTable("dbo.Tasks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        TaskName = c.String(nullable: false, maxLength: 100, unicode: false),
                        TaskDescription = c.String(maxLength: 300, unicode: false),
                        TaskStartDate = c.DateTime(nullable: false, storeType: "date"),
                        TaskEndDate = c.DateTime(nullable: false, storeType: "date"),
                        TaskPriority = c.Int(nullable: false),
                        TaskStatus = c.String(maxLength: 8000, unicode: false),
                        ProjectId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId);
            
            DropForeignKey("dbo.TaskNs", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.TaskNs", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.TaskNs", new[] { "ProjectId" });
            DropIndex("dbo.TaskNs", new[] { "EmployeeId" });
            DropTable("dbo.TaskNs");
            CreateIndex("dbo.Tasks", "ProjectId");
            CreateIndex("dbo.Tasks", "EmployeeId");
            AddForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: false);
            AddForeignKey("dbo.Tasks", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: false);
        }
    }
}
