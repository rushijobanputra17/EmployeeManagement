using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;

namespace DataAccessLayer.Services
{ 
    public class EmployeeRepository : IEmployeeRepository
    {
        private harshmungra_SatvaEntities objDataAccess;

        public EmployeeRepository()
        {
            objDataAccess = new harshmungra_SatvaEntities();
        }
        public List<GetEmployees_Result> GetEmployees(bool isActive)
        {
            return objDataAccess.GetEmployees(isActive).ToList();
        }

        public List<GetEmployeesByProject_Result> GetEmployeesByProject(int projectId)
        {
            return objDataAccess.GetEmployeesByProject(projectId).ToList();
        }

        public void InsertUpdateEmployee(Employee employee)
        {
            objDataAccess.InsertUpdateEmployee(employee.Id, employee.Name, employee.DeptId, employee.JoiningDate, employee.Salary, employee.IsDeleted, employee.IsActive);
        }

        public bool UpdateEmployeeStatus(int employeeId, bool status)
        {
            return objDataAccess.UpdateEmployeeStatus(employeeId, status).FirstOrDefault().Value;
        }
    }
}
