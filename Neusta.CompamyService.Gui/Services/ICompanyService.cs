using System.Collections.Generic;
using System.Threading.Tasks;
using Neusta.CompamyService.Gui.CompanyServiceApi;

namespace Neusta.CompamyService.Gui.Services
{
    public interface ICompanyService
    {
        Task Save(CompanyDto company);
        Task<IList<CompanyDto>> Get();
        Task<IList<CompanyAttributeDto>> GetAttributes();
        Task SaveAttribute(CompanyAttributeDto companyAttributeDto);
        Task Update(CompanyDto company);
        Task UpdateAttribute(CompanyAttributeDto attribute);
        Task SaveAttributeValue(CompanyAttributeValueDto value);
        Task UpdateAttributeValue(CompanyAttributeValueDto value);
        Task Delete(long companyId);
    }
}