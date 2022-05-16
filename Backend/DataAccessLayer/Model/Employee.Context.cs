﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class harshmungra_SatvaEntities : DbContext
    {
        public harshmungra_SatvaEntities()
            : base("name=harshmungra_SatvaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
    
        public virtual ObjectResult<GetEmployees_Result> GetEmployees(Nullable<bool> isActive)
        {
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("IsActive", isActive) :
                new ObjectParameter("IsActive", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetEmployees_Result>("GetEmployees", isActiveParameter);
        }
    
        public virtual ObjectResult<GetEmployeesByProject_Result> GetEmployeesByProject(Nullable<int> projectId)
        {
            var projectIdParameter = projectId.HasValue ?
                new ObjectParameter("ProjectId", projectId) :
                new ObjectParameter("ProjectId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetEmployeesByProject_Result>("GetEmployeesByProject", projectIdParameter);
        }
    
        public virtual int InsertUpdateEmployee(Nullable<int> empId, string name, Nullable<int> deptId, Nullable<System.DateTime> joiningDate, Nullable<decimal> salary, Nullable<bool> isDeleted, Nullable<bool> isActive)
        {
            var empIdParameter = empId.HasValue ?
                new ObjectParameter("EmpId", empId) :
                new ObjectParameter("EmpId", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var deptIdParameter = deptId.HasValue ?
                new ObjectParameter("DeptId", deptId) :
                new ObjectParameter("DeptId", typeof(int));
    
            var joiningDateParameter = joiningDate.HasValue ?
                new ObjectParameter("JoiningDate", joiningDate) :
                new ObjectParameter("JoiningDate", typeof(System.DateTime));
    
            var salaryParameter = salary.HasValue ?
                new ObjectParameter("Salary", salary) :
                new ObjectParameter("Salary", typeof(decimal));
    
            var isDeletedParameter = isDeleted.HasValue ?
                new ObjectParameter("IsDeleted", isDeleted) :
                new ObjectParameter("IsDeleted", typeof(bool));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("IsActive", isActive) :
                new ObjectParameter("IsActive", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertUpdateEmployee", empIdParameter, nameParameter, deptIdParameter, joiningDateParameter, salaryParameter, isDeletedParameter, isActiveParameter);
        }
    
        public virtual int ChangeProjectStatus(Nullable<int> projectId, string status)
        {
            var projectIdParameter = projectId.HasValue ?
                new ObjectParameter("ProjectId", projectId) :
                new ObjectParameter("ProjectId", typeof(int));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ChangeProjectStatus", projectIdParameter, statusParameter);
        }
    
        public virtual ObjectResult<GetProjectById_Result> GetProjectById(Nullable<int> projectId)
        {
            var projectIdParameter = projectId.HasValue ?
                new ObjectParameter("ProjectId", projectId) :
                new ObjectParameter("ProjectId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProjectById_Result>("GetProjectById", projectIdParameter);
        }
    
        public virtual ObjectResult<GetProjects_Result> GetProjects(Nullable<bool> isActive)
        {
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("IsActive", isActive) :
                new ObjectParameter("IsActive", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProjects_Result>("GetProjects", isActiveParameter);
        }
    
        public virtual ObjectResult<GetProjectsByEmployee_Result> GetProjectsByEmployee(Nullable<int> employeeId)
        {
            var employeeIdParameter = employeeId.HasValue ?
                new ObjectParameter("EmployeeId", employeeId) :
                new ObjectParameter("EmployeeId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProjectsByEmployee_Result>("GetProjectsByEmployee", employeeIdParameter);
        }
    
        public virtual int InsertUpdateProject(Nullable<int> projectId, string name, string description, Nullable<System.DateTime> startDate, Nullable<bool> isActive)
        {
            var projectIdParameter = projectId.HasValue ?
                new ObjectParameter("ProjectId", projectId) :
                new ObjectParameter("ProjectId", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("IsActive", isActive) :
                new ObjectParameter("IsActive", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertUpdateProject", projectIdParameter, nameParameter, descriptionParameter, startDateParameter, isActiveParameter);
        }
    
        public virtual ObjectResult<DeleteProject_Result> DeleteProject(Nullable<int> projectId)
        {
            var projectIdParameter = projectId.HasValue ?
                new ObjectParameter("ProjectId", projectId) :
                new ObjectParameter("ProjectId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DeleteProject_Result>("DeleteProject", projectIdParameter);
        }
    }
}
