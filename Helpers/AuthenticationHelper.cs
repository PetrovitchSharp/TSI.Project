using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace TSI.Helpers
{
	public class AuthenticationHelper
	{
        public static async Task Authenticate(string userName, HttpContext httpContext)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            var props = new AuthenticationProperties();
            props.ExpiresUtc = DateTime.Now.AddMinutes(30);

            // установка аутентификационных куки
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id), props);
        }

    }
}
