using DataAccessLayer.Model;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IProjectRepository
    {
        List<GetProjects_Result> GetAllProject(bool isActicve);

        List<GetProjectById_Result> GetProjectByid(int id);

        void InsertUpdateProject(Project project);

        int? DeleteProject(int projectId);

        void changeProjectStatus(int id, string status);

        List<GetProjectsByEmployee_Result> GetProjectByEmployeeId(int? employeeId);
    }
}
