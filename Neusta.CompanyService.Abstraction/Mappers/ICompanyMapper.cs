using Neusta.CompanyService.Database.Entities;
using Neusta.CompanyService.DTOs;

namespace Neusta.CompanyService.Mappers
{
    public interface ICompanyMapper
    {
        public CompanyDto MapCompanyToCompanyDto(Company company);
        public Company MapCompanyDtoToCompany(CompanyDto companyDto);
        public CompanyAttributeDto MapCompanyAttributeToCompanyAttributeDto(CompanyAttribute companyAttribute);
        public CompanyAttribute MapCompanyAttributeDtoToCompanyAttribute(CompanyAttributeDto companyAttributeDto);

        public CompanyAttributeValue MapCompanyAttributeValueDtoToCompanyAttributeValue(
            CompanyAttributeValueDto companyAttributeValueDto);
    }
}