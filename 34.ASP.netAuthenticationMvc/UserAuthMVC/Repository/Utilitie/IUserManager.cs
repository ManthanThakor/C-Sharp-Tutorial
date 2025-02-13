using Microsoft.AspNetCore.Http;
using UserAuthMVC.Models.ViewModels;
using System.Threading.Tasks;
using UserAuthMVC.Models;

namespace UserAuthMVC.Repository.Utilitie
{
    public interface IUserManager
    {
        Task SignInAsync(HttpContext HttpContext, CookieUserItem user, bool isPresent = false);
        Task SignOutAsync(HttpContext httpContext);
    }
}
