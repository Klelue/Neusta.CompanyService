using System.Collections.Generic;
using Neusta.CompanyService.Database.Entities;

namespace Neusta.CompanyService.Database.Repositories
{
    public interface ICompanyRepository
    {
        public List<Company> GetAll();

        public Company GetById(long id);

        public List<CompanyAttribute> GetAllAttributes();

        public void Save(Company company);

        public void Update(Company company);

        public void Delete(long id);

        public void SaveAttribute(CompanyAttribute companyAttribute);

        public void DeleteAttribute(long id);
    }
}