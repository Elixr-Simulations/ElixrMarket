using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ElixrMarket.Web
{
    public static class Helpers
    {
        public static Guid GetCurrentUserId(this HttpContext context)
        {
            var id = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (id != null)
            {
                return new Guid(id);
            }

            throw new NullReferenceException();
        }
    }
}
