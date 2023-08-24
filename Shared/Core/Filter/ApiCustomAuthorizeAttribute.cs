using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Filter
{
    public class ApiCustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
      
            if (!context.HttpContext.Request.Headers.ContainsKey("authorization"))
            {
                //context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Unauthorized);
                context.Result = new UnauthorizedResult();

                return;
            }
           
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var id =  JwtHelper.JwtHelper.ValidateToken(token);
            if (!string.IsNullOrEmpty(id))
            {
                context.Result = new UnauthorizedResult();
                return;
            }


        }
     

    }
}
