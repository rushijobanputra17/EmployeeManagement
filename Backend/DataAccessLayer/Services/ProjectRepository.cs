﻿using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class ProjectRepository
    {
        private harshmungra_SatvaEntities objDataAccess;

        public ProjectRepository()
        {
            objDataAccess = new harshmungra_SatvaEntities();
        }

        public List<GetProjects_Result> GetAllProject(bool isActicve)
        {
            return objDataAccess.GetProjects(isActicve).ToList();
        }

        public GetProjectById_Result GetProjectByid(int projectId)
        {
            return objDataAccess.GetProjectById(projectId).FirstOrDefault();
        }

        public void InsertUpdateProject(Project project)
        {
            objDataAccess.InsertUpdateProject(project.Id,project.Name,project.Description,project.StartDate,project.IsActive);
        }

        public int? DeleteProject(int projectId)
        {
            return objDataAccess.DeleteProject(projectId).FirstOrDefault().Response;
        }

        public void changeProjectStatus(int id, string status)
        {
            objDataAccess.ChangeProjectStatus(id, status);
        }


        public List<GetProjectsByEmployee_Result> GetProjectByEmployeeId(int? employeeId)
        {
            return objDataAccess.GetProjectsByEmployee(employeeId).ToList();
        }
    }
}
