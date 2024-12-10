using AspNetCoreHero.ToastNotification.Abstractions;
using Mellow.Entites.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mellow.RazorPage.Pages
{
    public class IndexModel: PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly INotyfService notyfService;
        private readonly UserManager<AppUser> userManager;

        public IndexModel(ILogger<IndexModel> logger,INotyfService notyfService)
        {
           
            _logger = logger;
            this.notyfService = notyfService;
        }

        public async Task  OnGet()
        {
            notyfService.Success("Welcome to Mellow");
            //IdentityResult result = await userManager.CreateAsync(new AppUser { UserName = "admin" }, "admin123");
            // if (result.Succeeded)
            // {
            //     _logger.LogInformation("User created");
            // }
            // else
            // {
            //     foreach (var error in result.Errors)
            //     {
            //         _logger.LogError(error.Description);
            //     }
            // }
        }
    }
}
