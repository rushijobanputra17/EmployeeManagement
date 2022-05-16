﻿using AutoMapper;
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
    public class ProjectController : ApiController
    {
        public static ProjectRepository projectRepository = new ProjectRepository();
        public JsonResponse objResponse;
        public static AutoMapper.MapperConfiguration config = new AutoMapper.MapperConfiguration(cgf => cgf.CreateMap<ProjectViewModel, Project>());
        public static Mapper mapper = new Mapper(config);

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

        [HttpPost]
        public JsonResponse InsertProject(ProjectViewModel project)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    projectRepository.InsertUpdateProject(mapper.Map<Project>(project));
                    objResponse = UtilityFunctions.GetJsonResponse(1, "Record added successfully", project);
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
    }
}
