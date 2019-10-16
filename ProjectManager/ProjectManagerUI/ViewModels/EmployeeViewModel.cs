using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ProjectManagerDAL;
namespace ProjectManagerUI.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        [StringLength(30)]
        [Required]
        [Display(Name = "Enter Employee Name")]
        public string EmployeeName { get; set; }
        [StringLength(30)]
        [Required]
        [Display(Name = "Enter Employee Designation")]
        public string EmployeeDesignation { get; set; }
    }
}