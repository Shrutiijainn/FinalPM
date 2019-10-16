using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ProjectManagerUI.ViewModels
{
    public class ProjectViewModel
    {

        
        public int ProjectId { get; set; }
        [StringLength(50)]
        [Required]
        
        public string ProjectTitle { get; set; }

        [Required]
       
        public DateTime ProjectStartDate { get; set; }
        [Required]
        
        public DateTime ProjectEndDate { get; set; }
       
        public int EmployeeId { get; set; }


      
    }
}