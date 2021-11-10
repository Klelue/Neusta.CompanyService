using Neusta.CompanyService.Database.Entities;

namespace Neusta.CompanyService.Validators
{
    public interface ICompanyValidator
    {
        public void FoundCompany(Company company);
    }
}