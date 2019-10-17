using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exceptions;

namespace ProjectManagerDAL
{
    public class ProjectRepository : IRepository<Project>
    {
        ProjectManagerModel objContext;

        public ProjectRepository()
        {
            objContext = new ProjectManagerModel();
        }

        public bool Add(Project obj)
        {
            try
            {
                if (obj != null)
                {
                    objContext.Projects.Add(obj);
                    return objContext.SaveChanges() > 0;
                }
                else
                {
                    throw new ProjectManagerException("No Project to add");
                }
            }
            catch (ProjectManagerException e)
            {
                throw e;
            }
        }
        //public List<Employee> projectmanagerlist()
        //{
        //    ProjectManagerModel context = new ProjectManagerModel();

        //    var Query = from item in context.Projects
        //                select item.EmployeeId;
        //    var q = from Employee in context.Employees
        //            where Employee.EmployeeDesignation == "ProjectManager" && !Query.Contains(Employee.EmployeeId)
        //            select Employee;
        //    return q.ToList();
        //}

        public Project Find(int id)
        {
            try
            {
                return objContext.Projects.Find(id);
            }
            catch (ProjectManagerException e)
            {
                throw e;
            }
            throw new ProjectManagerException("Error finding Project");
        }

        public List<Project> Display()
        {
            try
            {
                if (objContext.Projects.Count() > 0)
                {
                    return objContext.Projects.ToList();
                }
                else
                {
                    throw new ProjectManagerException("No Data To Display");
                }
            }
            catch (ProjectManagerException e)
            {
                throw e;
            }
        }
        public void Dispose()
        {
            objContext.Dispose();
        }
    }
}