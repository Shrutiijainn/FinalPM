using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using ProjectManagerUI.ViewModels;
using Exceptions;
using ProjectManagerDAL;
using ProjectmanagerBLL;

namespace ProjectManagerUI.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            return View("Home");
        }
        public ActionResult ViewTasks()
        {
            try
            {
                var objTaskService = new TaskService();
                var list = objTaskService.Display();
                var ViewList = new List<TaskViewModel>();
                foreach (var item in list)
                {
                    ViewList.Add(new TaskViewModel() { TaskId = item.TaskId, TaskName = item.TaskName, TaskDescription = item.TaskDescription, TaskStartDate = item.TaskStartDate, TaskEndDate = item.TaskEndDate, ProjectId = item.ProjectId, EmployeeId = item.EmployeeId });
                }
                return View("ViewTask", ViewList);
            }
            catch (ProjectManagerException e)
            {
                return Content("Error");
            }
        }
        public ActionResult AddTask()
        {
            return View("AddTask");
        }



        [HttpPost]
        public ActionResult AddTask(TaskViewModel item)
        {
            TaskN task = new TaskN() { TaskId = item.TaskId, TaskName = item.TaskName, TaskDescription = item.TaskDescription, TaskStartDate = item.TaskStartDate,TaskPriority = item.TaskPriority,TaskStatus =item.TaskStatus, TaskEndDate = item.TaskEndDate, ProjectId = item.ProjectId, EmployeeId = item.EmployeeId };
            try
            {
                var objTaskService = new TaskService();
                if (objTaskService.AddTask(task))
                {

                    return Content("Task added");
                }
                return Content("Cannot Add Task");
            }
            catch (ProjectManagerException e)
            {
                throw;
            }
        }
    }
}
