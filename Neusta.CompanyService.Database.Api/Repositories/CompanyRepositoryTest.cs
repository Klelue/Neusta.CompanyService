using System.Collections.Generic;
using System.Linq;
using Neusta.CompanyService.Database.Api.Repositories;
using Neusta.CompanyService.Database.Entities;
using Neusta.CompanyService.Database.Repositories;
using NUnit.Framework;

namespace Neusta.CompanyService.Database.Test.Repositories
{
    [TestFixture]
    public class CompanyRepositoryTest : TestBaseRepository
    {
        private CompanyRepository repository;

        [SetUp]
        public void SetUp()
        {
            repository = new CompanyRepository(context);
        }

        [Test]
        public void GetAllReturnsAllCompanies()
        {
            context.Company.AddRange(GetExampleCompanyWithoutAttributValues());
            context.SaveChanges();

            List<Company> result = repository.GetAll();

            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Id, Is.EqualTo(1));
        }

        [Test]
        public void GetAllReturnsComapniesWithAttributValues()
        {
            context.Company.AddRange(GetExampleCompaniesWithAttributValues());
            context.SaveChanges();

            List<Company> result = repository.GetAll();

            Assert.That(result[0].CompanyAttributeValues.Count, Is.EqualTo(1));
            Assert.That(result[1].CompanyAttributeValues.Count, Is.EqualTo(1));
            Assert.That(result[0].CompanyAttributeValues[0].Value, Is.EqualTo("SD"));
            Assert.That(result[1].CompanyAttributeValues[0].Value, Is.EqualTo("HEC"));
        }

        [Test]
        public void GetByIdReturnsCompanies()
        {
            context.Company.AddRange(GetExampleCompanyWithoutAttributValues());
            context.SaveChanges();

            Company result = repository.GetById(1);

            Assert.That(result.Id, Is.EqualTo(1));

            result = repository.GetById(2);

            Assert.That(result.Id, Is.EqualTo(2));
        }

        [Test]
        public void GetByIdReturnsCompaniesWithAttributValues()
        {
            context.Company.AddRange(GetExampleCompaniesWithAttributValues());
            context.SaveChanges();

            Company result = repository.GetById(1);

            Assert.That(result.CompanyAttributeValues[0].Value,  Is.EqualTo("SD"));

            result = repository.GetById(2);

            Assert.That(result.CompanyAttributeValues[1].Value,  Is.EqualTo("HEC"));
        }

        [Test]
        public void GetAllAttributesReturnsCompanyAttributes()
        {
            context.CompanyAttribute.Add(GetExampleAttributWithoutCompanyAttributeValues());
            context.SaveChanges();

            List<CompanyAttribute> result = repository.GetAllAttributes();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Id, Is.EqualTo(1));
            Assert.That(result[0].Name, Is.EqualTo("name"));
        }

        [Test]
        public void GetAllAttributesReturnsCompanyAttributesWithValues()
        {
            CompanyAttribute companyAttribute = GetExampleAttributWithCompanyAttributeValues();
            context.CompanyAttribute.Add(companyAttribute);
            context.SaveChanges();

            List<CompanyAttribute> result = repository.GetAllAttributes();

            Assert.That(result[0].CompanyAttributeValues[0].Value, Is.EqualTo("SD"));
        }

        [Test]
        public void SaveSavesCompany()
        {
            List<Company> companies = GetExampleCompanyWithoutAttributValues();

            repository.Save(companies[0]);
            Company result = repository.GetById(1);

            Assert.That(result.Id, Is.EqualTo(1));
        }    
        
        [Test]
        public void SaveSavesCompanyWithAttributes()
        {
            List<Company> companies = GetExampleCompaniesWithAttributValues();
            repository.Save(companies[0]);
            Company result = repository.GetById(1);

            Assert.That(result.CompanyAttributeValues[0].Value, Is.EqualTo("SD"));
            Assert.That(result.CompanyAttributeValues[0].CompanyAttributeId, Is.EqualTo(1));
            Assert.That(result.CompanyAttributeValues[0].CompanyId, Is.EqualTo(1));
        }

        [Test]
        public void DeleteDeletesCompany()
        {
            context.Company.AddRange(GetExampleCompanyWithoutAttributValues());
            context.SaveChanges();

            repository.Delete(1);
            Company result = repository.GetById(1);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void DeleteDeltesCompanyAttributeValues()
        {
            context.Company.AddRange(GetExampleCompanyWithoutAttributValues());
            context.SaveChanges();

            repository.Delete(1);
            CompanyAttributeValue result = context.CompanyAttributeValue
                .FirstOrDefault(value => value.CompanyId == 1);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void DeleteAttributeDeletesAttribute()
        {
            context.CompanyAttribute.Add(GetExampleAttributWithoutCompanyAttributeValues());
            context.SaveChanges();

            repository.DeleteAttribute(1);
            CompanyAttribute result = context.CompanyAttribute.FirstOrDefault(attribute => attribute.Id == 1);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void DeleteAttributeDeletesAttributeValues()
        {
            context.CompanyAttribute.Add(GetExampleAttributWithCompanyAttributeValues());
            context.SaveChanges();

            repository.DeleteAttribute(1);
            CompanyAttributeValue result = context.CompanyAttributeValue
                .FirstOrDefault(value => value.CompanyAttributeId == 1);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void UpdateUpdatesFirmenAttributeValues()
        {
            List<Company> companies = GetExampleCompaniesWithAttributValues();
            context.Company.AddRange(companies);
            context.SaveChanges();

            companies[1].CompanyAttributeValues[0].Value = "KURSWECHSEL";
            repository.Update(companies[1]);
            Company result = repository.GetById(2);

            Assert.That(result.CompanyAttributeValues[0].Value, Is.EqualTo("KURSWECHSEL"));
        }

        private CompanyAttribute GetExampleAttributWithCompanyAttributeValues()
        {
            CompanyAttribute companyAttribute = GetExampleAttributWithoutCompanyAttributeValues();
            companyAttribute.CompanyAttributeValues = GetExampleAttributValues(1, "SD");

            return companyAttribute;
        }

        public CompanyAttribute GetExampleAttributWithoutCompanyAttributeValues()
        {
            CompanyAttribute companyAttribute = new CompanyAttribute
            {
                Id = 1,
                Name = "name"
            };
            return companyAttribute;
        }

        private List<Company> GetExampleCompaniesWithAttributValues()
        {
            List<Company> companies = GetExampleCompanyWithoutAttributValues();

            companies[0].CompanyAttributeValues = GetExampleAttributValues(companies[0].Id, "SD");
            companies[1].CompanyAttributeValues = GetExampleAttributValues(companies[1].Id, "HEC");

            return companies;
        }

        private List<CompanyAttributeValue> GetExampleAttributValues(long companyId, string name)
        {
            List<CompanyAttributeValue> values = new List<CompanyAttributeValue>();

            values.Add(new CompanyAttributeValue
            {
                CompanyAttributeId = 1,
                CompanyId = companyId,
                Value = name
            });

            return values;
        }

        private List<Company> GetExampleCompanyWithoutAttributValues()
        {
            List<Company> companies = new List<Company>();

            companies.Add(new Company
            {
                Id = 1
            });

            companies.Add(new Company
            {
                Id = 2
            });

            return companies;
        }
    }
}