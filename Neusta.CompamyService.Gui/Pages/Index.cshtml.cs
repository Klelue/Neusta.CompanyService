using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Neusta.CompamyService.Gui.CompanyServiceApi;
using Neusta.CompamyService.Gui.Models;
using Neusta.CompamyService.Gui.Services;
using System.Threading.Tasks;

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

        public async Task<PartialViewResult> OnGetEditAttributeModalPartialAsync(CompanyAttributeDto attribute)
        {
            return Partial("Modals/_EditAttribute", attribute);
        }

        public async Task<PartialViewResult> OnGetEditCompanyModalPartialAsync(CompanyDto company)
        {
            var editCompanyModel = new EditCompanyModel
            {
                Attributes = await _companyService.GetAttributes(),
                Company = company
            };
            return Partial("Modals/_EditCompany", editCompanyModel);
        }

        public async Task<IActionResult> OnPostAttributeAsync(string attributeName)
        {
            var attribute = new CompanyAttributeDto()
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

        public async Task<IActionResult> OnPostUpdateAttributeAsync(CompanyAttributeDto attribute)
        {
            await _companyService.UpdateAttribute(attribute);
            return await OnGetTablePartial();
        }

        public async Task<ActionResult> OnPostDeleteAsync(long id)
        {
            await _companyService.Delete(id);
            return await OnGetTablePartial();
        }

        public async Task<IActionResult> OnPostUpdateAsync(CompanyDto company)
        {
            await _companyService.Update(company);
            return await OnGetTablePartial();
        }

        public async Task<IActionResult> OnPostDeleteAttributeAsync(long attributeId)
        {
            await _companyService.DeleteAttribute(attributeId);
            return await OnGetTablePartial();
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