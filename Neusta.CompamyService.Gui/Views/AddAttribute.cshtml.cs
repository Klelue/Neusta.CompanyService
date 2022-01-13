using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string attributeName)
        { 
            string isValid = "false";

            if (!string.IsNullOrWhiteSpace(attributeName))
            {
                await CreateNewAttributeDto(attributeName);
                isValid = "true";
            } 
           
           return new JsonResult(isValid);
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
