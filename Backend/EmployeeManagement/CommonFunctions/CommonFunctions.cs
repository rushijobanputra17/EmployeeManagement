using EmployeeManagement.Models;

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