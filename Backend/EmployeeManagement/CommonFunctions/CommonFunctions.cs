using EmployeeManagement.Models;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.CommonFunctions
{
    public class UtilityFunctions
    {
        public static JsonResponse GetJsonResponse(int responseStatus, string message, dynamic result)
        {
            return new JsonResponse()
            {
                ResponseStatus = responseStatus,
                Message = message,
                Result = result
            };
        }
    }
}