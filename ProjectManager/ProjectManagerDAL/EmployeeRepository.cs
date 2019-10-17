using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerDAL
{
    public class EmployeeRepository : IRepository<Employee>
    {
        ProjectManagerModel _dbContext;

        public EmployeeRepository()
        {
            _dbContext = new ProjectManagerModel();
        }

        public bool Add(Employee item)
        {
            var IsAdded = false;
            try
            {
                _dbContext.Employees.Add(item);
                IsAdded = _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new ProjectManagerException("error adding data" + ex);
            }
            return IsAdded;
        }

        public Employee Find(int id)
        {
            try
            {
                return _dbContext.Employees.Find(id);
            }
            catch (Exception ex)
            {
                throw new ProjectManagerException("Error finding Task" + ex);
            }
        }

        public List<Employee> Display()
        {
            try
            {
                return _dbContext.Employees.ToList();
            }
            catch (Exception ex)
            {
                throw new ProjectManagerException("Error getting data" + ex);
            }
        }
        public List<Employee> DisplayDesignation()
        {
            ProjectManagerModel context = new ProjectManagerModel();

            var Query = from item in context.Projects
                        select item.EmployeeId;
            var q = from Employee in context.Employees
                    where Employee.EmployeeDesignation == "ProjectManager" && !Query.Contains(Employee.EmployeeId)
                    select Employee;
            return q.ToList();

        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}