﻿using System.Linq;
using System.Security.Claims;

namespace CarBlog2.Extension
{
    public static class IdentityExtensions {



        public static string GetSpecificClaim(this ClaimsPrincipal claimsPrincipal, string claimType) {

            var claim = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == claimType);
            return (claim != null) ? claim.Value : string.Empty;
        
        
        }
    }
}
