using Exceptions;
using ProjectManagerDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using ProjectmanagerDAL;

namespace ProjectmanagerBLL
    {
        public class TaskService
        {
            static TaskNRepository TaskNRepo = null;
            public TaskService()
            {

            }
            public List<TaskN> Display()
            {
                try
                {
                    using (TaskNRepo =  new TaskNRepository())
                    {
                        return TaskNRepo.Display().ToList();
                    }
                }
                catch (ProjectManagerException e)
            {
                    throw e;
                }
                }
                public bool AddTask(TaskN proj)
                {
                    try
                    {
                        using (TaskNRepo = new TaskNRepository())
                        {
                            return TaskNRepo.Add(proj);
                        }
                    }
                    catch (ProjectManagerException e)
                    {

                        throw e;
                    }
                }


            }
        }
    

