using Mellow.BL.Managers.Abstract;
using Mellow.Entites.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mellow.RazorPage.Pages.Odalar
{
    public class CreateModel(IManager<Oda> manager) : PageModel
    {

        [BindProperty]
        public InputModel InsertModel { get; set; } = new();
        public void OnGet()
        {
           
            InsertModel.OdaTipi2 = Enum.GetNames(typeof(OdaTipi))
                .Select(x => new SelectListItem
            {
                Text = x,
                Value = ((byte)Enum.Parse(typeof(OdaTipi), x)).ToString()
            }).ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Oda oda = new()
                {
                    OdaNumarasi = InsertModel.OdaNo,
                    YatakSayisi = InsertModel.YatakSayisi,
                    OdaTipi = InsertModel.OdaTipi
                };
               var result= await manager.InsertAsync(oda, default);
                if(result.Success)
                {
                    return RedirectToPage("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Message);
                    }
                }
                return Page();
            }

            return Page();
        }
        public class InputModel
        {
            [Required(ErrorMessage ="Oda numarasi zorunludur")]
            [DisplayName("Oda No")]
            public byte OdaNo { get; set; }

            [DisplayName("Yatak Sayisi")]
            public byte YatakSayisi { get; set; }
            public List<SelectListItem>? OdaTipi2 { get; set; }
            public OdaTipi OdaTipi { get; set; }


        }
    }
}
