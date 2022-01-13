using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Neusta.CompamyService.Gui.CompanyServiceApi;
using Neusta.CompamyService.Gui.Services;

namespace Neusta.CompamyService.Gui.Views.CompanyTable
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

            return new PartialViewResult
            {
                ViewName = "_TablePartial",
                ViewData = new ViewDataDictionary<List<CompanyAttributeDto>>(ViewData, attributes) //ToDO
            };
        }
    }
}
