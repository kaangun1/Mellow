using Mellow.BL.Managers.Abstract;
using Mellow.Entites.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mellow.RazorPage.Pages.Odalar
{
    public class IndexModel(IManager<Oda> manager) : PageModel
    {

        public ICollection<Oda> Odalar { get; set; } 
        public async Task OnGet()
        {
           Odalar = await manager.GetAllAsync(default);
        }
        //public async Task<IActionResult>  OnPost()
        //{
        //    return RedirectToPage("Create");
        //}
        //public async Task<IActionResult> OnPostDelete(int id)
        //{
        //    var oda = await manager.GetByIdAsync(id, default);
        //    if (oda == null)
        //    {
        //        return NotFound();
        //    }
        //    await manager.DeleteAsync(oda, default);
        //    return RedirectToPage();
        //}
    }
}
