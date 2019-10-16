namespace ProjectManagerDAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectManagerDAL.ProjectManagerModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjectManagerDAL.ProjectManagerModel context)
        {
            context.Employees.AddOrUpdate(p=>p.EmployeeName,
                new Employee() { EmployeeName = "Shruti Jain", EmployeeDesignation = "ProjectManager" },
                new Employee() { EmployeeName = "Vaishnavi Awasthi", EmployeeDesignation = "ProjectManager" },
                new Employee() { EmployeeName = "Pranav Dixit", EmployeeDesignation = "ProjectManager" },
                new Employee() { EmployeeName = "Jojo Jose", EmployeeDesignation = "Developer" },
                new Employee() { EmployeeName = "Payal", EmployeeDesignation = "Developer" }
           );

        }
    }
}
