namespace ProjectManagerDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Projecttaskadded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "EmployeeName", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AlterColumn("dbo.Employees", "EmployeeDesignation", c => c.String(nullable: false, maxLength: 30, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "EmployeeDesignation", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Employees", "EmployeeName", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
    }
}
