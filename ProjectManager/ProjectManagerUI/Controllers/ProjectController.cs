﻿using ProjectManagerBLL;
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
        IRepository<Employee> EmpRepo;

        ProjectService objProjectService = null;

        public ProjectController()
        {
            objProjectService = new ProjectService();
            EmpRepo = new EmployeeRepository();
        }
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewProjects()
        {
            try
            {
                var list = objProjectService.Display();
                var ViewList = new List<ProjectViewModel>();
                foreach (var item in list)
                {
                    ViewList.Add(new ProjectViewModel()
                    {
                        ProjectId = item.ProjectId,
                        ProjectTitle = item.ProjectTitle,
                        ProjectStartDate = item.ProjectStartDate,
                        ProjectEndDate = item.ProjectEndDate,
                        EmployeeId = item.EmployeeId
                    });
                }
                return View("ViewProjects", ViewList);
            }
            catch (ProjectManagerException e)
            {
                return Content("Error" + e.Message);
            }
        }
        public ActionResult AddProject()
        {
            var item = new ProjectViewModel();
            item.Employees = new SelectList(EmpRepo.Display(), "EmployeeId", "EmployeeName");
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(true)]
        public ActionResult AddProject(ProjectViewModel item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Project = new Project()
                    {
                        ProjectId = item.ProjectId,
                        ProjectTitle = item.ProjectTitle,
                        ProjectStartDate = item.ProjectStartDate,
                        ProjectEndDate = item.ProjectEndDate,
                        EmployeeId = item.EmployeeId
                    };
                    var Added = objProjectService.AddProject(Project);
                    if (Added)
                    {
                        return RedirectToAction("ViewProjects");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to add");
                        return View(item);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "One or More validation failed");
                    return View(item);
                }
            }
            catch (ProjectManagerException e)
            {
                return Content("Error" + e.Message);
            }
        }
    }
}
