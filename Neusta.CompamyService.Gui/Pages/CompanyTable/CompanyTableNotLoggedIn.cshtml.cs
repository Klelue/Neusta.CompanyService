using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Neusta.CompamyService.Gui.CompanyServiceApi;

namespace Neusta.CompamyService.Gui.Pages.CompanyTable
{
    public class CompanyTableNotLoggedInModel : PageModel
    {
        public IList<CompanyAttributeDto> attributes;
        public IList<CompanyDto> companies;

        public void OnGet(IList<CompanyAttributeDto> attributes, IList<CompanyDto> companies)
        {
            this.attributes = attributes;
            this.companies = companies;
        }
    }
}
