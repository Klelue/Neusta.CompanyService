using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Neusta.CompanyService.Gui.CompanyServiceApi;

namespace Neusta.CompamyService.Gui.Pages
{
    public class IndexModel : PageModel
    {
        public IList<CompanyDto> companies;
        public IList<CompanyAttributeDto> attributes;

        [Inject]
        private Services.CompanyService companyService { get; set; }

        public IndexModel()
        {
            companies = null;
            attributes = null;
        }

        public async Task OnGetAsync()
        {
            companies = await companyService.Get();
            attributes = await companyService.GetAttributes();
        }
    }
}
