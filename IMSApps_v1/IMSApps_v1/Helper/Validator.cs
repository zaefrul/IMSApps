using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSApps_v1.Helper
{
    public class Validator
    {
        public static bool Product(HttpRequestBase Request)
        {
            string a = Request.Form["Name"];
            return true;
        }

        public static bool IsNumber(String value)
        {
            return value.All(Char.IsDigit);
        }
    }

}