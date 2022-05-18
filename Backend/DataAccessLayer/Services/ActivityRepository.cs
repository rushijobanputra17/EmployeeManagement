using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using Entity.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Services
{
    public class ActivityRepository : IActivityRepository
    {
        private harshmungra_SatvaEntities objDataAccess;

        public ActivityRepository()
        {
            objDataAccess = new harshmungra_SatvaEntities();
        }
        public List<GetActivityHistory_Result> GetAllActivity(int Projectid, int EmployeeId)
        {
            return objDataAccess.GetActivityHistory().ToList(Projectid,EmployeeId);
        }
    }
}
