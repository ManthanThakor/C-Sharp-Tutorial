using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Threading.Tasks;
using UserAuthMVC.Models;
using UserAuthMVC.Models.ViewModels;

namespace UserAuthMVC.Repository.Utilitie
{
    public class UserManager : IUserManager
    {
        public async Task SignInAsync(HttpContext httpContext, CookieUserItem user, bool isPresent = false)
        {
            string CookieAuthenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            var claims = GetUserClaims(user);

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = isPresent,   // Use "Remember me" logic if isPresent is true
                ExpiresUtc = isPresent ? DateTime.UtcNow.AddDays(30) : (DateTime?)null  // Set expiration for persistent login
            };

            await httpContext.SignInAsync(CookieAuthenticationScheme, claimsPrincipal, authProperties);
        }

        public async Task SignOutAsync(HttpContext httpContext)
        {
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        private List<Claim> GetUserClaims(CookieUserItem user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.EmailAddress)
            };

            return claims;
        }
    }
}
