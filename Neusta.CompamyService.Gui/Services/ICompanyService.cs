using System.Collections.Generic;
using System.Threading.Tasks;
using Neusta.CompamyService.Gui.CompanyServiceApi;

namespace Neusta.CompamyService.Gui.Services
{
    public interface ICompanyService
    {
        Task Save(CompanyDto company);
        Task<List<CompanyDto>> Get();
        Task<List<CompanyAttributeDto>> GetAttributes();
        Task SaveAttribute(CompanyAttributeDto companyAttributeDto);
        Task Update(CompanyDto company);
        Task UpdateAttribute(CompanyAttributeDto attribute);
        Task SaveAttributeValue(CompanyAttributeValueDto value);
        Task UpdateAttributeValue(CompanyAttributeValueDto value);
    }
}