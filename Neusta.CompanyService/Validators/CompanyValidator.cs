using Neusta.CompanyService.Abstraction.Exceptions;
using Neusta.CompanyService.Database.Entities;

namespace Neusta.CompanyService.Validators
{
    public class CompanyValidator : ICompanyValidator
    {
        public void FoundCompany(Company company)
        {
            if (company == null)
            {
                throw new CompanyNotFoundException();
            }
        }
    }
}