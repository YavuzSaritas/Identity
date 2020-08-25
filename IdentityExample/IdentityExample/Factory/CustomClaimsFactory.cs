using IdentityExample.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityExample.Factory
{
    public class CustomClaimsFactory : UserClaimsPrincipalFactory<User>
    {
        public CustomClaimsFactory(UserManager<User> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            /*User Classındaki propertyleri claim olarak ekliyoruz*/
            var identity = await base.GenerateClaimsAsync(user);
            var claimList = new List<Claim>() {
                new Claim("FirstName",user.FirstName),
                new Claim("LastName",user.LastName)
            };
            identity.AddClaims(claimList);
            return identity;
        }
    }
}
