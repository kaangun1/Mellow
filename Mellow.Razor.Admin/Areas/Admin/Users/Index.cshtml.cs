using Mellow.Entites.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Mellow.RazorPage.Pages.Admin.Users
{

    [Authorize]
    public class IndexModel(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager) : PageModel
    {



        [BindProperty]
        public List<UserVM> UsersVM { get; set; } = new();
        public async Task OnGet()
        {
           var users = await userManager.Users.ToListAsync();
            foreach (var user in users)
            {
                UserVM model = new();
                model.User = user;
                model.RoleNames = await userManager.GetRolesAsync(user) as List<string>;
                UsersVM.Add(model);
            }

        }

        public class UserVM
        {
            public AppUser User { get; set; }
            public List<string> RoleNames { get; set; } = new();
        }

    }
}
