using UserAuthMVC.Models.ViewModels;
using UserAuthMVC.Models;

namespace UserAuthMVC.Repository.IRepo
{
    public interface IUserRepo
    {
        CookieUserItem Register(Register model);
        CookieUserItem Validate(Login model);
    }
}
