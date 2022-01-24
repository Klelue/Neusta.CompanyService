using System;
using System.Linq;
using System.Runtime.InteropServices;
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
       // public TableModel Table { get; set; }
        private readonly ICompanyService _companyService;

        public IndexModel(ICompanyService service)
        {
            _companyService = service;
         //   Table = new TableModel(_companyService);
        }
        public async Task<IActionResult> OnGetAsync()
        {
            await LoadValues();
            return Page();
        }

        private async Task LoadValues()
        {
            TableValues = new TableValues (_companyService)
            {
                Companies = await _companyService.Get(),
                Attributes = await _companyService.GetAttributes()
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _companyService.Save(new CompanyDto());
            return await GetTablePartial();
        }

        public async Task<IActionResult> OnPostAttributeAsync()
        {
            long requestId = Int64.Parse(Request.Form["attributeId"]);
            LoadValues();
            CompanyAttributeDto attribute = TableValues.Attributes.First(a => a.Id == requestId);
            attribute.Name = Request.Form["attributeName"].ToString();
            await _companyService.UpdateAttribute(attribute);

            return await GetTablePartial();
        }

        public async Task<IActionResult> OnPostUpdateValueAsync()
        {
            CompanyAttributeValueDto value = new CompanyAttributeValueDto()
            {
                CompanyId = Int64.Parse(Request.Form["companyId"]),
                CompanyAttributeId = Int64.Parse(Request.Form["attributeId"]),
                Value = Request.Form["valueName"].ToString()
            };
            await _companyService.UpdateAttributeValue(value);

            return await GetTablePartial();
        }

        public async Task<IActionResult> OnPostValueAsync()
        {
            CompanyAttributeValueDto value = new CompanyAttributeValueDto()
            {
                CompanyId = Int64.Parse(Request.Form["companyId"]),
                CompanyAttributeId = Int64.Parse(Request.Form["attributeId"]),
                Value = Request.Form["valueName"].ToString()
            };
            await _companyService.SaveAttributeValue(value);
            return await GetTablePartial();
        }

        private async Task<IActionResult> GetTablePartial()
        {
            await LoadValues();
            return Partial("CompanyTable/_CompanyTableLoggedIn", TableValues);
        }

    }
}