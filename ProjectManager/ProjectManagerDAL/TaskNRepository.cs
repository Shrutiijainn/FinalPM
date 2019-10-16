using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using Entities;
using Exceptions;
using ProjectManagerDAL;

namespace ProjectmanagerDAL
{
    /**
     * Repository for managing Tasks
         */
    public class TaskNRepository : IRepository<TaskN>
    {
        public bool Add(TaskN obj)
        {
            try
            {
                if (obj != null)
                {
                    using (var objContext = new ProjectManagerModel())
                    {
                        objContext.Tasks.Add(obj);
                        return objContext.SaveChanges() > 0;
                    }
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


        //public Project Find(int id)
        //{
        //    throw new NotImplementedException();
        //}


        public List<TaskN> Display()
        {
            try
            {
                using (var objContext = new ProjectManagerModel())
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
            }
            catch (ProjectManagerException e)
            {
                throw e;
            }
        }
        ProjectManagerModel _dbContext;
        public TaskNRepository()
        {
            _dbContext = new ProjectManagerModel();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}

        TaskN IRepository<TaskN>.Find(int id)
        {
            throw new NotImplementedException();
        }
    }
}


