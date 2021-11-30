using System.Collections.Generic;
using Neusta.CompanyService.DTOs;

namespace Neusta.CompanyService.Services
{
    public interface ICompanyService
    {
        public IList<CompanyDto> GetAll();
        public CompanyDto GetById(long id);
        public void Delete(long id);
        public IList<CompanyAttributeDto> GetAllAttributeDtos();
        public void Save(CompanyDto companyDto);
        public void Update(CompanyDto companyDto);
        public void SaveAttribute(CompanyAttributeDto attributeDto);
        public void UpdateAttribute(CompanyAttributeDto attributeDto);
        public void UpdateAttributeValue(CompanyAttributeValueDto valueDto);
        public void SaveAttributeValue(CompanyAttributeValueDto valueDto);
    }
}