using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using SchoolApp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace SchoolApp.Web.Base
{
    public class loginMiddleware
    {

        private  Password _password = new Password();

        public loginMiddleware(string password)
           {
            _password.Value = password;
           }


        public  bool Login(string psw, HttpContext context)
        {
            if (psw == null)
                return false;

            if (psw == _password.Value)
            {
                // создаем один claim
                var claims = new List<Claim>
                 {
                new Claim(ClaimsIdentity.DefaultNameClaimType, psw)
                 };
                // создаем объект ClaimsIdentity
                ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                // установка аутентификационных куки
                context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));

                return true;
            }
              else
            {
                return false;
            }
               

        }

        public void Out(HttpContext context)
        {
            context.SignOutAsync();

        }



    }
}
