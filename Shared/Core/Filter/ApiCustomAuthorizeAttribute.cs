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
            var token = context.HttpContext.Request.Headers.ContainsKey("authorization");
            if (!token)
            {
                //context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Unauthorized);
                context.Result = new UnauthorizedResult();

                return;
            }

            JwtSecurityToken tokenS = getToken(context);
            if (tokenS.ValidTo < DateTime.Now)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
        private JwtSecurityToken getToken(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.ContainsKey("authorization")) return null;
            var token = context.HttpContext.Request.Headers["authorization"].ToString();
            if (token == null) return null;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            return tokenS;
        }

    }
}
