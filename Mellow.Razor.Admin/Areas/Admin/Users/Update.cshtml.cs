using Mellow.Entites.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Mellow.RazorPage.Pages.Admin.Users
{
    public class UpdateModel(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager) : PageModel
    {


        [BindProperty]
        public UserVM UsersVM { get; set; } = new();
        public async Task OnGet(string Id)
        {
            var user = await userManager.FindByIdAsync(Id);
            if (user != null)
            {

                UsersVM.User = user;
                UsersVM.RoleNames = await userManager.GetRolesAsync(user) as List<string>; // burasi Kullaniciya ait olan roller
                var roller = await roleManager.Roles.ToListAsync(); // Sistemde tanimli olan butun roller

                foreach (var role in roller)
                {
                    //SelectListItem item = new();
                    //item.Text = role.Name;
                    //item.Value = role.Name;
                    //if (UsersVM.RoleNames.Contains(role.Name))
                    //{
                    //    item.Selected = true;
                    //}
                    UserRolesCheckBox item = new();
                    item.Value = role.Id;
                    item.Name = role.Name;
                    item.RoleId = role.Id;
                    if (UsersVM.RoleNames.Contains(role.Name))
                    {
                        item.IsChecked = true;
                    }
                    UsersVM.UserRolesCheckBoxes.Add(item);
                }


            }

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await userManager.FindByIdAsync(UsersVM.User.Id);
            user.Tcno = UsersVM.User.Tcno;

            await userManager.UpdateAsync(user);
            var userRoles = await userManager.GetRolesAsync(user) as List<string>;
            await userManager.RemoveFromRolesAsync(user, userRoles); // Oncelikle Kayitli olan butun rolerini remove edecek 


            foreach (var item in UsersVM.UserRolesCheckBoxes.Where(p => p.IsChecked == true).ToList())
            {

                await userManager.AddToRoleAsync(user, item.Name);
            }


            return RedirectToPage("Index");
        }
        public class UserVM
        {
            public AppUser User { get; set; }
            public List<string> RoleNames { get; set; } = new(); // Bu user'a ait olan rolleri tutacak

            public List<SelectListItem> SelectListItems { get; set; } = new(); // Ekranda selectList olarak gorunecek itemlari tutacak

            public List<UserRolesCheckBox> UserRolesCheckBoxes { get; set; } = new(); // Ekranda checkbox olarak gorunecek itemlari tutacak
        }
        public class UserRolesCheckBox
        {
            public string? Name { get; set; }
            public string? Value { get; set; }
            public bool IsChecked { get; set; }
            public string? RoleId { get; set; }
        }
        
    }
}
