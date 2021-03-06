using System.Collections.Generic;
using System.Threading.Tasks;
using Neusta.CompamyService.Gui.CompanyServiceApi;

namespace Neusta.CompamyService.Gui.Services
{


    public class CompanyService : ICompanyService
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

        public async Task<IList<CompanyDto>> Get()
        {
            return await _companyApi.ApiCompanyGetAsync();
        }

        public async Task<CompanyDto> GetById(long id)
        {
            return await _companyApi.ApiCompanyCompanyidGetAsync(id);
        }

        public async Task<IList<CompanyAttributeDto>> GetAttributes()
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

        public async Task<CompanyAttributeDto> GetAttributeById(long id)
        {
            return await _companyApi.AttributesAttributeidAsync(id);
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

        public async Task Delete(long companyId)
        {
            await _companyApi.ApiCompanyCompanyidDeleteAsync(companyId);
        }

        public async Task DeleteAttribute(long id)
        {
            await _companyApi.AttributesDeleteAsync(id);
        }
    }
}