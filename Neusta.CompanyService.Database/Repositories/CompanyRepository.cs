using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Neusta.CompanyService.Database.Contexts;
using Neusta.CompanyService.Database.Entities;

namespace Neusta.CompanyService.Database.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CompanyServiceDbContext _dbContext;

        public CompanyRepository(CompanyServiceDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public List<Company> GetAll()
        {
            return _dbContext.Company
                .Include(company => company.CompanyAttributeValues)
                .ToList();
        }

        public Company GetById(long id)
        {
            return _dbContext.Company
                .Where(company => company.Id == id)
                .Include(company => company.CompanyAttributeValues)
                .FirstOrDefault();
        }

        public List<CompanyAttribute> GetAllAttributes()
        {
            return _dbContext.CompanyAttribute
                .Include(company => company.CompanyAttributeValues)
                .ToList();
        }

        public void Save(Company company)
        {
            _dbContext.Add(company);
            _dbContext.SaveChanges();
        }

        public void Update(Company company)
        {
            _dbContext.Update(company);
            _dbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            Company company = GetById(id);

            if (company.CompanyAttributeValues != null)
            {
                _dbContext.CompanyAttributeValue.RemoveRange(company.CompanyAttributeValues);
            }

            _dbContext.Remove(company);
            _dbContext.SaveChanges();
        }

        public void SaveAttribute(CompanyAttribute companyAttribute)
        {
            _dbContext.CompanyAttribute.Add(companyAttribute);
            _dbContext.SaveChanges();
        }

        public void DeleteAttribute(long id)
        {
            CompanyAttribute companyAttribute = _dbContext.CompanyAttribute
                .Where(companyAttribute => companyAttribute.Id == id).FirstOrDefault();

            if (companyAttribute.CompanyAttributeValues != null)
            {
                _dbContext.CompanyAttributeValue.RemoveRange(companyAttribute.CompanyAttributeValues);
            }

            _dbContext.CompanyAttribute.Remove(companyAttribute);
            _dbContext.SaveChanges();
        }
    }
}