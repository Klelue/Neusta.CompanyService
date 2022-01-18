using System.Collections.Generic;
using System.Threading.Tasks;
using Neusta.CompanyService.Gui.CompanyServiceApi;

namespace Neusta.CompanyService.Gui.Services
{


    public class CompanyService : ICompanyService
    {
        private readonly CompanyServiceApi.CompanyServiceApi _companyApi;

        public CompanyService(CompanyServiceApi.CompanyServiceApi companyApi)
        {
            _companyApi = companyApi;
        }

        public async Task Save(CompanyDto company)
        {
            await _companyApi.CompanyAsync(company);
        }

        public async Task<List<CompanyDto>> Get()
        {
            return await _companyApi.CompanyAllAsync();
        }

        public async Task<List<CompanyAttributeDto>> GetAttributes()
        {
            return await _companyApi.AttributesGetAsync();
        }

        public async Task SaveAttribute(CompanyAttributeDto attribute)
        {
            await _companyApi.AttributesPostAsync(attribute);
        }

        public async Task Update(CompanyDto company)
        {
            await _companyApi.ApiCompanyPutAsync(company);
        }

        public async Task UpdateAttribute(CompanyAttributeDto attribute)
        {
            await _companyApi.AttributesPutAsync(attribute);
        }

        public async Task SaveAttributeValue(CompanyAttributeValueDto value)
        {
            await _companyApi.AttributevaluesPostAsync(value);
        }

        public async Task UpdateAttributeValue(CompanyAttributeValueDto value)
        {
            await _companyApi.AttributevaluesPutAsync(value);
        }
    }
}