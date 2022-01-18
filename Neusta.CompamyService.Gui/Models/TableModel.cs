using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Neusta.CompamyService.Gui.CompanyServiceApi;
using Neusta.CompamyService.Gui.Services;

namespace Neusta.CompamyService.Gui.Models
{
    public class TableModel : PageModel
    {
        public IList<CompanyAttributeDto> attributes;
        public IList<CompanyDto> companies;

        private ICompanyService companyService;

        public TableModel(ICompanyService service)
        {
            companyService = service;
        }

        public async Task<PartialViewResult> OnGetAsync()
        {
            companies = await companyService.Get();
            attributes = await companyService.GetAttributes();
            return Partial("_TablePartial");
        }

        public async Task OnPostAsync()
        {
            await companyService.Save(new CompanyDto());
            await OnGetAsync();

        }

        public async Task OnPostUpdateAttributeAsync(string attributeName, CompanyAttributeDto attribute)
        {
            attribute.Name = attributeName;
            await companyService.UpdateAttribute(attribute);
            await OnGetAsync(); 
        }

        public async Task OnPostUpdateValueAsync(string newValue, CompanyAttributeValueDto
            value)
        {
            value.Value = newValue;
            await companyService.UpdateAttributeValue(value);
            await OnGetAsync();
        }
    }
}
