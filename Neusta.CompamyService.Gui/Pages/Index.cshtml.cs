using Microsoft.AspNetCore.Mvc.RazorPages;
using Neusta.CompamyService.Gui.CompanyServiceApi;
using Neusta.CompamyService.Gui.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Neusta.CompamyService.Gui.Pages
{
    public class IndexModel : PageModel
    {
        public IList<CompanyDto> companies;
        public IList<CompanyAttributeDto> attributes;


        private ICompanyService companyService;

        public IndexModel(ICompanyService service)
        {
            companyService = service;
        }

        public async Task OnGetAsync()
        {
            companies = await companyService.Get();
            attributes = await companyService.GetAttributes();
        }

        public async Task OnPostAsync()
        {
            await companyService.Save(new CompanyDto());
            await OnGetAsync();
        }

        public async Task OnPostAttributeAsync()
        {
            await companyService.SaveAttribute(new CompanyAttributeDto());
            await OnGetAsync();
        }

        public async Task OnPutAttributeAsync(CompanyAttributeDto attribute)
        {
            await companyService.UpdateAttribute(attribute);
            await OnGetAsync();
        }

        public async Task OnPutAttributeValuesAsync(CompanyAttributeValueDto value)
        {
            await companyService.UpdateAttributeValue(value);
            await OnGetAsync();
        }
        public async Task OnPostAttributeValuesAsync(CompanyAttributeValueDto value)
        {
            await companyService.SaveAttributeValue(value);
            await OnGetAsync();
        }

        public IActionResult OnGetDemo1()
        {
            return new JsonResult("Hello");
        }
    }
}