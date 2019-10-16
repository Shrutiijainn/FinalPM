using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Exceptions;
using ProjectManagerDAL;

namespace ProjectmanagerDAL
{
    /**
     * Repository for managing Projects
         */
    public class ProjectRepository : IRepository<Project>
    {
        public List<Project> Display()
        {
            try
            {
                using (var objContext = new ProjectManagerModel())
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
            }
            catch (ProjectManagerException e)
            {
                throw e;
            }
        }
        public bool Add(Project obj)
        {
            try
            {
                if (obj != null)
                {
                    using (var objContext = new ProjectManagerModel())
                    {
                        objContext.Projects.Add(obj);
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

        public Project Find(int id)
        {
            throw new NotImplementedException();
        }
        ProjectManagerModel _dbContext;

        public ProjectRepository()
        {
            _dbContext = new ProjectManagerModel();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
