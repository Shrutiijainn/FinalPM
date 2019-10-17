using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Exceptions;

namespace ProjectManagerDAL
{
    public class TaskNRepository : IRepository<TaskN>
    {
        ProjectManagerModel objContext;

        public TaskNRepository()
        {
            objContext = new ProjectManagerModel();
        }

        public bool Add(TaskN obj)
        {
            try
            {
                if (obj != null)
                {
                    objContext.Tasks.Add(obj);
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

        public TaskN Find(int id)
        {
            try
            {
                return objContext.Tasks.Find(id);
            }
            catch (Exception ex)
            {
                throw new ProjectManagerException("Error finding Task" + ex);
            }
        }
        public List<Employee> Displaypendigtasks()
        {
            ProjectManagerModel context = new ProjectManagerModel();
            var EmployeesWithFullTasks = from task in context.Tasks
                                         group task by task.EmployeeId into grp
                                         where grp.Count() >= 5
                                         select grp.Key;

            var query2 = from emp in context.Employees
                         from t in context.Tasks
                         where emp.EmployeeDesignation == "Developer" && !EmployeesWithFullTasks.Contains(emp.EmployeeId)
                        && t.TaskStatus == "pending" || t.EmployeeId == emp.EmployeeId
                         select emp;
            return query2.ToList().Distinct(new EmployeeComparer()).ToList();
        }

       



        public List<TaskN> Display()
        {
            try
            {
                if (objContext.Tasks.Count() > 0)
                {
                    return objContext.Tasks.ToList();
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


        public List<TaskN> GetTasks(int projectId)
        {
            TaskN task = new TaskN();


            try
            {
                task = objContext.Tasks.Find(projectId);
                return objContext.Tasks.ToList();
            }
            catch (Exception ex)
            {
                throw new ProjectManagerException("Error finding Task" + ex);
            }

        }

        public bool AddTask(TaskN obj)
        {
            return true;
        }

        public void Dispose()
        {
            objContext.Dispose();
        }

    }
}