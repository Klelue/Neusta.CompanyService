using Microsoft.EntityFrameworkCore;
using Neusta.CompanyService.Database.Contexts;
using Neusta.CompanyService.Database.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Neusta.CompanyService.Database.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CompanyServiceDbContext _dbContext;

        public CompanyRepository(CompanyServiceDbContext dbContext)
        {
            _dbContext = dbContext;
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

        public CompanyAttribute GetAttributeById(long id)
        {
            return _dbContext.CompanyAttribute
                .Where(attribute => attribute.Id == id)
                .Include(attribute => attribute.CompanyAttributeValues)
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
            var company = GetById(id);
            if (company != null)
            {
                if (company.CompanyAttributeValues != null)
                    _dbContext.CompanyAttributeValue.RemoveRange(company.CompanyAttributeValues);

                _dbContext.Remove(company);
                _dbContext.SaveChanges();
            }
        }

        public void SaveAttribute(CompanyAttribute companyAttribute)
        {
            _dbContext.CompanyAttribute.Add(companyAttribute);
            _dbContext.SaveChanges();
        }

        public void DeleteAttribute(long id)
        {
            var companyAttribute = GetAttributeById(id);
            if (companyAttribute != null)
            {
                if (companyAttribute.CompanyAttributeValues != null)
                    _dbContext.CompanyAttributeValue.RemoveRange(companyAttribute.CompanyAttributeValues);

                _dbContext.CompanyAttribute.Remove(companyAttribute);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateAttribute(CompanyAttribute attribute)
        {
            _dbContext.CompanyAttribute.Update(attribute);
            _dbContext.SaveChanges();
        }

        public void UpdateAttributeValue(CompanyAttributeValue value)
        {
            _dbContext.CompanyAttributeValue.Update(value);
            _dbContext.SaveChanges();
        }

        public void SaveAttributeValue(CompanyAttributeValue value)
        {
            _dbContext.CompanyAttributeValue.Add(value);
            _dbContext.SaveChanges();
        }
    }
}