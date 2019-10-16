using ProjectmanagerDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagerDAL;
using Entities;
using Exceptions;

namespace ProjectManagerBLL
    {
        public class ProjectService
        {
            static ProjectRepository ProjectRepo = null;
            public ProjectService()
            {

            }
            public List<Project> Display()
            {
                try
                {
                    using (ProjectRepo = new ProjectRepository())
                    {
                        return ProjectRepo.Display().ToList();
                    }
                }
                catch (ProjectManagerException e)
            {
                    throw e;
                }
                }
                public bool AddProject(Project proj)
                {
                    try
                    {
                        using (ProjectRepo = new ProjectRepository())
                        {
                            return ProjectRepo.Add(proj);
                        }
                    }
                    catch (ProjectManagerException e)
                    {

                        throw e;
                    }
                }


            }
        }
    

