using AutoMapper;
using Core.CommonFunctions;
using DataAccessLayer.Model.ViewModel;
using DataAccessLayer.Services;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagement.Controllers
{
    public class ActivityController : ApiController
    {
        public static ActivityRepository activityRepository = new ActivityRepository();

        public static AutoMapper.MapperConfiguration config = new AutoMapper.MapperConfiguration(cgf => cgf.CreateMap<EmployeeViewModel, Employee>());
        public static Mapper mapper = new Mapper(config);
        public JsonResponse objResponse;
        public JsonResponse GetActivity(int ProjectId,int EmployeeId)
        {
            try
            {
                var activtrys = activityRepository.GetAllActivity(ProjectId,EmployeeId);
                objResponse = UtilityFunctions.GetJsonResponse(1, "Records found : " + activtrys.Count(), activtrys);
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
