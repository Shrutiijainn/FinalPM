using ProjectManagerBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using ProjectManagerUI.ViewModels;
using Exceptions;
using ProjectManagerDAL;

namespace ProjectManagerUI.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            return View("Home");
        }
        public ActionResult ViewProjects()
        {
            try
            {
                var objProjectService = new ProjectService();
                var list = objProjectService.Display();
                var ViewList = new List<ProjectViewModel>();
                foreach (var item in list)
                {
                    ViewList.Add(new ProjectViewModel() { ProjectId = item.ProjectId, ProjectTitle = item.ProjectTitle, ProjectStartDate = item.ProjectStartDate, ProjectEndDate = item.ProjectEndDate, EmployeeId = item.EmployeeId });
                }
                return View("ViewProjects", ViewList);
            }
            catch (ProjectManagerException e)
            {
                return Content("Error"+e.Message);
            }
        }
        public ActionResult AddProject()
        {
            return View("AddProject");
        }

        [HttpPost]
        public ActionResult AddProject(ProjectViewModel item)
        {
            Project proj = new Project() { ProjectId = item.ProjectId, ProjectTitle = item.ProjectTitle, ProjectStartDate = item.ProjectStartDate, ProjectEndDate = item.ProjectEndDate, EmployeeId = item.EmployeeId };
            try
            {
                var objProjectService = new ProjectService();
                if (objProjectService.AddProject(proj))
                {

                    return Content("Project added");
                }
                return Content("Cannot Add project");
            }
            catch (ProjectManagerException e)
            {

                throw;
            }
        }
    }
}
