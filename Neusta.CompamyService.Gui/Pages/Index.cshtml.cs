using System.Collections.Generic;
using System.Linq;
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

        public async Task<PartialViewResult> OnGetAddAttributeModalPartialAsync()
        {
            return Partial("Modals/_AddAttribute");
        }

        public async Task<PartialViewResult> OnGetEditAttributeModalPartialAsync(IList<CompanyAttributeDto> attributes)
        {
            return Partial("_EditAttribute", attributes);
        }
        
        public async Task<IActionResult> OnPostAttributeAsync(string attributeName)
        {
            CompanyAttributeDto attribute = new CompanyAttributeDto()
            {
                Name = attributeName
            };
            await _companyService.SaveAttribute(attribute);

            return await OnGetTablePartial();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _companyService.Save(new CompanyDto());
            return await OnGetTablePartial();
        }

        public async Task<IActionResult> OnPostUpdateAttributeAsync(long attributeId, string attributeName = null)
        {
            IList<CompanyAttributeDto> att = await _companyService.GetAttributes();
            var attribute = att.First(a => a.Id == attributeId);
            if (attributeName != null)
            {
                attribute.Name = attributeName;
            }
            else
            {
                attribute.Visible = !attribute.Visible;
            }
            await _companyService.UpdateAttribute(attribute);

            return await OnGetTablePartial();
        }

        public async Task<ActionResult> OnPostDeleteAsync(long id)
        {
            await _companyService.Delete(id);
            return await OnGetTablePartial();
        }

        public async Task<IActionResult> OnPostUpdateAsync(long id)
        {
            IList<CompanyDto> companies = await _companyService.Get();
            CompanyDto company = companies.First(c => c.Id == id);
            company.Visible = !company.Visible;
            await _companyService.Update(company);
            return await OnGetTablePartial();
        }

        public async Task<IActionResult> OnPostDeleteAttributeAsync(long attributeId)
        {
            await _companyService.DeleteAttribute(attributeId);
            return await OnGetTablePartial();
        }

        public async Task<IActionResult> OnPostUpdateValueAsync(long companyId, long attributeId, string valueName)
        {
            var value = Value(companyId, attributeId, valueName);
            await _companyService.UpdateAttributeValue(value);
            return await OnGetTablePartial();
        }

        public async Task<IActionResult> OnPostValueAsync(long companyId, long attributeId, string valueName)
        {
            var value = Value(companyId, attributeId, valueName);
            await _companyService.SaveAttributeValue(value);
            return await OnGetTablePartial();
        }

        private static CompanyAttributeValueDto Value(long companyId, long attributeId, string valueName)
        {
            return new CompanyAttributeValueDto()
            {
                CompanyId = companyId,
                CompanyAttributeId = attributeId,
                Value = valueName
            };
        }
        
        private async Task<PartialViewResult> OnGetTablePartial()
        {
            await LoadValues();
            return Partial("CompanyTable/_CompanyTableLoggedIn", TableValues);
        }

        private async Task LoadValues()
        {
            TableValues = new TableValues()
            {
                Companies = await _companyService.Get(),
                Attributes = await _companyService.GetAttributes()
            };
        }
    }
}