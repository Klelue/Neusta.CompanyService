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
        public void Save(CompanyDto company);
        public void Update(CompanyDto company);
        public void SaveAttribute(CompanyAttributeDto attribute);
    }
}