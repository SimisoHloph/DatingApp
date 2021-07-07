using Microsoft.AspNetCore.Http;
using System;
namespace Dating.API.Helpers
{
    public static class Extentions
    {
        public static void addApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("ApplicationErro-Error", message);
            response.Headers.Add("Access-Control-Expose-Hearders","ApplicationErro-Error");
            response.Headers.Add("Access-Control-Allow-Origin","*");
        }

        public static int CalculateAge(this DateTime theDateTime)
        {
            var age = DateTime.Today.Year-theDateTime.Year;
            if(theDateTime.AddYears(age)> DateTime.Today)
            {
                age--;
            }
            return age;
        }
    }
}