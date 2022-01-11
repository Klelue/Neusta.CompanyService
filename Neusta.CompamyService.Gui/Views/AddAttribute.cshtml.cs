using System.Threading.Tasks;
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

        public async Task OnGetAsync()
        {
        }

        public async Task OnPostAsync(string attributeName)
        {
            if (attributeName.Trim() == "")
            {
                await OnGetAsync();
            }
            else
            {
                await CreateNewAttributeDto(attributeName);
            }
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
