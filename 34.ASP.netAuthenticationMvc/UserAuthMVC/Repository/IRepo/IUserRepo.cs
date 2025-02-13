using UserAuthMVC.Models.ViewModels;
using UserAuthMVC.Models;

namespace UserAuthMVC.Provider.IRepository
{
    public interface IUserRepo
    {
        CookieUserItem Register(Register model);
        CookieUserItem Validate(Login model);
    }
}
