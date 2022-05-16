using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class ProjectViewModel
    {

        int? Id { get; set; }

        string Name { get; set; }   

        string Description { get; set; }    

        DateTime StartDate { get; set; }    

        string Status { get; set; } 

        Boolean IsActive { get; set; }  

    }
}