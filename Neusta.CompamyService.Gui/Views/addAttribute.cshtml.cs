using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Neusta.CompamyService.Gui.CompanyServiceApi;
using Neusta.CompamyService.Gui.Services;

namespace Neusta.CompamyService.Gui.Views
{
    public class AddAttributeModel : PageModel
    {
       
        private ICompanyService companyService;

        public AddAttributeModel(ICompanyService service)
        {
            companyService = service;
        }

        public async Task OnGetAsync()
        {
        }

        public async Task<IActionResult> OnPostAsync(string attributeName)
        {
            bool isValid = false;

           if (attributeName.Trim() != "")
            {
                await CreateNewAttributeDto(attributeName);
                isValid = true;
            }

           return Json(new {isValid, html=""});
        }


        private async Task CreateNewAttributeDto(string attributeName)
        {
            CompanyAttributeDto attribute = new CompanyAttributeDto
            {
                Name = attributeName
            };

            await companyService.SaveAttribute(attribute);
        }

    }
}
