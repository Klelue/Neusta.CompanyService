using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Neusta.CompamyService.Gui.CompanyServiceApi;
using Neusta.CompamyService.Gui.Services;

namespace Neusta.CompamyService.Gui.Pages.CompanyTable
{
    public class CompanyTableNotLoggedInModel : PageModel
    {
        public IList<CompanyAttributeDto> attributes;
        public IList<CompanyDto> companies;

        private ICompanyService companyService;

        public CompanyTableNotLoggedInModel(ICompanyService service)
        {
            companyService = service;
        }

        public async Task OnGetAsync()
        {
           
        }

        public async Task<PartialViewResult> OnGetTablePartialAsync()
        {
            companies = await companyService.Get();
            attributes = await companyService.GetAttributes();

            return Partial("_TablePartialNotLoggedIn");
        }
    }
}
