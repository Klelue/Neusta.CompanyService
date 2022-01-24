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
        public IList<CompanyAttributeDto> Attributes;
        public IList<CompanyDto> Companies;

        private ICompanyService companyService;

        public TableModel(ICompanyService service)
        {
            companyService = service;
        }

        public async Task<PartialViewResult> OnGetAsync()
        {
            Companies = await companyService.Get();
            Attributes = await companyService.GetAttributes();
         
            return Partial("CompanyTable/_CompanyTableNotLoggedIn", this);
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

