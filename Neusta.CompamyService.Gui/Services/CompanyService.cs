using System.Collections.Generic;
using System.Threading.Tasks;
using Neusta.CompanyService.Gui.CompanyServiceApi;

namespace Neusta.CompamyService.Gui.Services
{
    public class CompanyService
    {
        private readonly CompanyApi _companyApi;

        public CompanyService(CompanyApi companyApi)
        {
            _companyApi = companyApi;
        }

        public async Task Save(CompanyDto company)
        {
            await _companyApi.ApiCompanyPostAsync(company);
        }

        public async Task<List<CompanyDto>> Get()
        {
            return await _companyApi.ApiCompanyGetAsync();
        }

        public async Task<List<CompanyAttributeDto>> GetAttributes()
        {
            return await _companyApi.AttributesGetAsync();
        }
    }
}