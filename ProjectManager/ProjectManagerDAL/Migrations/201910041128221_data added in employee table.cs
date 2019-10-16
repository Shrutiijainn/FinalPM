namespace ProjectManagerDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataaddedinemployeetable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Tasks", new[] { "EmployeeId" });
            DropIndex("dbo.Tasks", new[] { "ProjectId" });
            CreateIndex("dbo.Tasks", "EmployeeId");
            CreateIndex("dbo.Tasks", "ProjectId");
            AddForeignKey("dbo.Tasks", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: false);
            AddForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Tasks", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Tasks", new[] { "ProjectId" });
            DropIndex("dbo.Tasks", new[] { "EmployeeId" });
            CreateIndex("dbo.Tasks", "ProjectId");
            CreateIndex("dbo.Tasks", "EmployeeId");
            AddForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
            AddForeignKey("dbo.Tasks", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
        }
    }
}
