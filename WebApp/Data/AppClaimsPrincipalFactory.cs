using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using WebApp.Data.Account;

namespace WebApp.Data
{
    public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<User>
    {
        public AppClaimsPrincipalFactory(UserManager<User> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        { }

        public async override Task<ClaimsPrincipal> CreateAsync(User user)
        {
            var principal = await base.CreateAsync(user);

            ((ClaimsIdentity)principal.Identity!).AddClaims(new[] {
                new Claim("Department", user.Department),
                new Claim("Position", user.Position)
            });
            return principal;
        }
    }
}
