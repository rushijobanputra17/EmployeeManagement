using AutoMapper;
using DataAccessLayer.Model;
using DataAccessLayer.Model.ViewModel;
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
    public class EmployeeController : ApiController
    {
        public static EmployeeRepository employeeRepository = new EmployeeRepository();

        public static AutoMapper.MapperConfiguration config = new AutoMapper.MapperConfiguration(cgf => cgf.CreateMap<EmployeeViewModel, Employee>());
        public static Mapper mapper = new Mapper(config);

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

        [Route("GetEmployeesByProject")]
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
        public JsonResponse InsertEmployee(EmployeeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employeeRepository.InsertUpdateEmployee(mapper.Map<Employee>(model));
                    objResponse = UtilityFunctions.GetJsonResponse(1, "Record added successfully", model);
                }
                else
                {
                    objResponse = UtilityFunctions.GetJsonResponse(0, "Some input is invalid", ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage).ToList());
                }
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

        [HttpPut]
        public JsonResponse UpdateEmployee(EmployeeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employeeRepository.InsertUpdateEmployee(mapper.Map<Employee>(model));
                    objResponse = UtilityFunctions.GetJsonResponse(1, "Record updated successfully", model);
                }
                else
                {
                    objResponse = UtilityFunctions.GetJsonResponse(0, "Some input is invalid", ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage).ToList());
                }
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

        [HttpPatch]
        public JsonResponse UpdateEmployeeStatus(int employeeId, bool status)
        {
            try
            {
                if (employeeRepository.UpdateEmployeeStatus(employeeId, status))
                {
                    objResponse = UtilityFunctions.GetJsonResponse(1, "Status updated successfully", status);
                }
                else
                {
                    objResponse = UtilityFunctions.GetJsonResponse(0, "Error", "Error occured while updating status");
                }
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
