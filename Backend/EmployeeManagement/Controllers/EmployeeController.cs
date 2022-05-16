using System;
using System.Linq;
using System.Web.Http;
using DataAccessLayer.Services;
using EmployeeManagement.CommonFunctions;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    [Authorize]
    public class EmployeeController : ApiController
    {
        public static EmployeeRepository employeeRepository = new EmployeeRepository();
        public JsonResponse objResponse;

        public JsonResponse GetEmployees(bool isActive)
        {
            try
            {
                var employees = employeeRepository.GetEmployees(isActive);
                objResponse = UtilityFunctions.GetJsonResponse(1, "Records found : " + employees.Count(), employees);
            }
            catch (Exception ex)
            {
                if(ex.InnerException != null)
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

        public JsonResponse GetEmployeesByProject(int projectId)
        {
            try
            {
                var employees = employeeRepository.GetEmployeesByProject(projectId);
                objResponse = UtilityFunctions.GetJsonResponse(1, "Records found : " + employees.Count(), employees);
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

        [HttpPost]
        public JsonResponse InsertEmployee()
        {
            
        }
    }
}
