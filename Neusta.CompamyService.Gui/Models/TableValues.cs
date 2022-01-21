using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Neusta.CompamyService.Gui.CompanyServiceApi;
using Neusta.CompamyService.Gui.Services;

namespace Neusta.CompamyService.Gui.Models
{
    public class TableValues
    {
        private ICompanyService companyService;

        public TableValues(ICompanyService service)
        {
            companyService = service;
        }

        public async Task<IActionResult> OnPostAttributeAsync(string attributeName, CompanyAttributeDto attribute)
        {
            attribute.Name = attributeName;
            await companyService.UpdateAttribute(attribute);
            await LoadValues();
            return new PartialViewResult();
        }

        private async Task LoadValues()
        {
            Companies = await companyService.Get();
            Attributes = await companyService.GetAttributes();
        }

        public IList<CompanyAttributeDto> Attributes { get; set; }
        public IList<CompanyDto> Companies { get; set; }
    }
}