using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;

namespace SchoolApp.Web.Attribute
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomAuthorizeAttribute: System.Attribute
    {

        public CustomAuthorizeAttribute()
        {

           
        }
      
    }
}
 