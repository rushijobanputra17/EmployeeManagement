using System.Collections.Generic;
using Entity.Model;

namespace DataAccessLayer.Interfaces
{
    public interface IActivityRepository
    {
        List<GetActivityHistory_Result> GetAllActivity(int Projectid, int EmployeeId);
    }
}
