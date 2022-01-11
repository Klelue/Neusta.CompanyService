using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Neusta.CompamyService.Gui.CompanyServiceApi;
using Neusta.CompamyService.Gui.Services;

namespace Neusta.CompamyService.Gui.Pages.CompanyTable
{
    public class CompanyTableLoggedInModel : PageModel
    {
        public IList<CompanyAttributeDto> attributes;
        public IList<CompanyDto> companies;

        private ICompanyService companyService;

        public CompanyTableLoggedInModel(ICompanyService service)
        {
            companyService = service;
        }

        public async Task OnGetAsync(IList<CompanyAttributeDto> attributes, IList<CompanyDto> companies)
        {
            this.attributes = attributes;
            this.companies = companies;
        }

        public async Task OnPostAsync()
        {
            await companyService.Save(new CompanyDto());
            
        }

        public async Task OnPostAttributeAsync()
        {
            
        }
    }
}
