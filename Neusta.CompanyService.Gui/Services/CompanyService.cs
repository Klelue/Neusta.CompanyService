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
            await _companyApi.Company2Async(company);
        }

        public async Task<IList<CompanyDto>> Get()
        {
            return await _companyApi.CompanyAllAsync();
        }

        public async Task<IList<CompanyAttributeDto>> GetAttributes()
        {
            return await _companyApi.AttributesAllAsync();
        }

        public async Task SaveAttribute(CompanyAttributeDto attribute)
        {
            await _companyApi.Attributes2Async(attribute);
        }

        public async Task Update(CompanyDto company)
        {
            await _companyApi.CompanyAsync(company);
        }

        public async Task UpdateAttribute(CompanyAttributeDto attribute)
        {
            await _companyApi.AttributesAsync(attribute);
        }

        public async Task SaveAttributeValue(CompanyAttributeValueDto value)
        {
            await _companyApi.AttributeValues2Async(value);
        }

        public async Task UpdateAttributeValue(CompanyAttributeValueDto value)
        {
            await _companyApi.AttributeValuesAsync(value);
        }
    }
}