using DataAccessLayer.Services;
using EmployeeManagement.CommonFunctions;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagement.Controllers
{
    public class ProjectController : ApiController
    {
        public static ProjectRepository projectRepository = new ProjectRepository();
        public JsonResponse objResponse;

        public JsonResponse GetProjects(bool isActive)
        {
            try
            {
                var projects = projectRepository.GetAllProject(isActive);
                objResponse = UtilityFunctions.GetJsonResponse(1, "Records found : " + projects.Count(), projects);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    objResponse = UtilityFunctions.GetJsonResponse(2, "Exception", ex.InnerException.Message);
                }
                else
                {
                    objResponse = UtilityFunctions.GetJsonResponse(2, "Exception", ex.Message);
                }
            }
            return objResponse;
        }
    }
}
