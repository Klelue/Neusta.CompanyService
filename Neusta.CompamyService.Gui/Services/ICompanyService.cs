using System.Collections.Generic;
using System.Threading.Tasks;
using Neusta.CompamyService.Gui.CompanyServiceApi;

namespace Neusta.CompamyService.Gui.Services
{
    public interface ICompanyService
    {
        Task Save(CompanyDto company);
        Task<IList<CompanyDto>> Get();
        Task<CompanyDto> GetById(long id);
        Task<IList<CompanyAttributeDto>> GetAttributes();
        Task SaveAttribute(CompanyAttributeDto attribute);
        Task Update(CompanyDto company);
        Task<CompanyAttributeDto> GetAttributeById(long id);
        Task UpdateAttribute(CompanyAttributeDto attribute);
        Task SaveAttributeValue(CompanyAttributeValueDto value);
        Task UpdateAttributeValue(CompanyAttributeValueDto value);
        Task Delete(long id);
        Task DeleteAttribute(long id);
    }
}