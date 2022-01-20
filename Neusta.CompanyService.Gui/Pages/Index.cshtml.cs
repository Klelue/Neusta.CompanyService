using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Neusta.CompanyService.Gui.CompanyServiceApi;
using Neusta.CompanyService.Gui.Models;
using Neusta.CompanyService.Gui.Services;

namespace Neusta.CompanyService.Gui.Pages
{
    public class IndexModel : PageModel
    {
        public TableModel tableModel;

        private ICompanyService companyService;

        public IndexModel(ICompanyService service)
        {
            companyService = service;
        }

        public async Task OnGet()
        {
            tableModel = new TableModel
            {
                Attributes = await companyService.GetAttributes(),
                Companies = await companyService.Get()
            };
        }
    }
}
