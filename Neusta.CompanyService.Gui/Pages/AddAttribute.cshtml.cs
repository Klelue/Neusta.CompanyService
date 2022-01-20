using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Neusta.CompanyService.Gui.CompanyServiceApi;
using Neusta.CompanyService.Gui.Services;


namespace Neusta.CompanyService.Gui.Pages
{
    public class AddAttributeModel : PageModel
    {
        [BindProperty]
        public string AttributeName { get; set; }
        
        private ICompanyService companyService;

        public AddAttributeModel(ICompanyService service)
        {
            companyService = service;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        { 
            string isValid = "false";

            if (!string.IsNullOrWhiteSpace(AttributeName))
            {
                await CreateNewAttributeDto();
                isValid = "true";
            }
            return new JsonResult(isValid);
        }


        private async Task CreateNewAttributeDto()
        {
            CompanyAttributeDto attribute = new CompanyAttributeDto
            {
                Name = AttributeName
            };

            await companyService.SaveAttribute(attribute);
        }

    }
}
