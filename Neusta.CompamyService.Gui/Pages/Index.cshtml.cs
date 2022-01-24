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
        private readonly ICompanyService _companyService;

        public IndexModel(ICompanyService service)
        {
            _companyService = service;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await LoadValues();
            return Page();
        }

        public PartialViewResult OnGetEditModalPartial()
        {
            return new PartialViewResult()
            {
                ViewName = "AddAttribute",
            };
        }

        private async Task LoadValues()
        {
            TableValues = new TableValues(_companyService)
            {
                Companies = await _companyService.Get(),
                Attributes = await _companyService.GetAttributes()
            };
        }

        public async Task<IActionResult> OnPostAttributeAsync()
        {
            CompanyAttributeDto attribute = new CompanyAttributeDto()
            {
                Name = Request.Form["attributeName"].ToString()
            };
            await _companyService.SaveAttribute(attribute);

            return await GetTablePartial();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _companyService.Save(new CompanyDto());
            return await GetTablePartial();
        }

        public async Task<IActionResult> OnPostUpdateAttributeAsync()
        {
            var requestId = long.Parse(Request.Form["attributeId"]);
            var att = await _companyService.GetAttributes();
            var attribute = att.Find(a => a.Id == requestId);
            attribute.Name = Request.Form["attributeName"].ToString();
            await _companyService.UpdateAttribute(attribute);

            return await GetTablePartial();
        }

        public async Task<IActionResult> OnPostUpdateValueAsync()
        {
            var value = CompanyAttributeValueDto();
            await _companyService.UpdateAttributeValue(value);
            return await GetTablePartial();
        }

        public async Task<IActionResult> OnPostValueAsync()
        {
            var value = CompanyAttributeValueDto();
            await _companyService.SaveAttributeValue(value);
            return await GetTablePartial();
        }

        private CompanyAttributeValueDto CompanyAttributeValueDto()
        {
            var value = new CompanyAttributeValueDto()
            {
                CompanyId = long.Parse(Request.Form["companyId"]),
                CompanyAttributeId = long.Parse(Request.Form["attributeId"]),
                Value = Request.Form["valueName"].ToString()
            };
            return value;
        }

        private async Task<IActionResult> GetTablePartial()
        {
            await LoadValues();
            return Partial("CompanyTable/_CompanyTableLoggedIn", TableValues);
        }
    }
}