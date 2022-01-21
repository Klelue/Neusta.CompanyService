using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Neusta.CompamyService.Gui.CompanyServiceApi;
using Neusta.CompamyService.Gui.Models;
using Neusta.CompamyService.Gui.Services;

namespace Neusta.CompamyService.Gui.Pages
{
    public class IndexModel : PageModel
    {
        public TableValues TableValues { get; set; }
        private ICompanyService companyService;

        public IndexModel(ICompanyService service)
        {
            companyService = service;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            await LoadValues();
            return Page();
        }

        private async Task LoadValues()
        {
            TableValues = new TableValues (companyService)
            {
                Companies = await companyService.Get(),
                Attributes = await companyService.GetAttributes()
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await companyService.Save(new CompanyDto());
            await LoadValues();
            return Partial("CompanyTable/_CompanyTableLoggedIn", TableValues);
        }

        public async Task<IActionResult> OnPostAttributeAsync(string attributeName, CompanyAttributeDto attribute)
        {
            attribute.Name = attributeName;
            await companyService.UpdateAttribute(attribute);
            return Partial("CompanyTable/_CompanyTableLoggedIn", TableValues);
        }
    }
}