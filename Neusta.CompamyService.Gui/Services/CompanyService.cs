using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Neusta.CompanyService.Gui.CompanyServiceApi;

namespace Neusta.CompanyService.Gui.Services
{
    public class CompanyService
    {
        private readonly CompanyApi _companyServiceApi;

        public CompanyService(CompanyApi companyServiceApi)
        {
            _companyServiceApi = companyServiceApi;
        }

        public async Task<List<CompanyDto>> GetAll()
        {
            return await _companyServiceApi.ApiCompanyGetAsync();
        }

        public async Task<CompanyDto> GetById(long id)
        {
            return await _companyServiceApi.ApiCompanyCompanyidGetAsync(id);
        }

        public async Task<List<CompanyAttributeDto>> GetAttributes()
        {
            return await _companyServiceApi.AttributesGetAsync();
        }

        public async Task Save(CompanyDto company)
        {
            _companyServiceApi.ApiCompanyPostAsync(company);
        }

        public async Task SaveAttribute(CompanyAttributeDto attribute)
        {
            _companyServiceApi.AttributesPostAsync(attribute);
        }
    }
}