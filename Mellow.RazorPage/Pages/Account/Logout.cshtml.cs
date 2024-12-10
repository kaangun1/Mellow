using Mellow.Entites.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mellow.RazorPage.Pages.Account
{
    public class LogoutModel(SignInManager<AppUser> signInManager) : PageModel
    {
        public async Task OnGet()
        {
            signInManager.SignOutAsync();
            Response.Redirect("/Index");
        }
    }
}
