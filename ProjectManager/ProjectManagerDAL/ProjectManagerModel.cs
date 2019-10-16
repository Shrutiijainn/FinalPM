namespace ProjectManagerDAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    internal class ProjectManagerModel : DbContext
    {
        public ProjectManagerModel()
            : base("name=ProjectManagerModel")
        {
        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Project> Projects{ get; set; }
        public virtual DbSet<TaskN> Tasks { get; set; }

    }
}