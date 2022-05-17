using System.Collections.Generic;
using DataAccessLayer.Model;
using Entity.Model;

namespace DataAccessLayer.Interfaces
{
    public interface IEmployeeRepository
    {
        List<GetEmployees_Result> GetEmployees(bool isActive);
        List<GetEmployeesByProject_Result> GetEmployeesByProject(int projectId);
        void InsertUpdateEmployee(Employee employee);
        bool UpdateEmployeeStatus(int employeeId, bool status);
    }
}
