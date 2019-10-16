namespace ProjectManagerDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Taskentityadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        TaskName = c.String(nullable: false, maxLength: 100, unicode: false),
                        TaskDescription = c.String(nullable: false, maxLength: 300, unicode: false),
                        TaskStartDate = c.DateTime(nullable: false),
                        TaskEndDate = c.DateTime(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Tasks", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Tasks", new[] { "ProjectId" });
            DropIndex("dbo.Tasks", new[] { "EmployeeId" });
            DropTable("dbo.Tasks");
        }
    }
}
