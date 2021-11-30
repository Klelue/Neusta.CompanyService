using System.Collections.Generic;
using Neusta.CompanyService.Database.Entities;
using Neusta.CompanyService.DTOs;

namespace Neusta.CompanyService.Mappers
{
    public class CompanyMapper : ICompanyMapper
    {
        public CompanyDto MapCompanyToCompanyDto(Company company)
        {
            CompanyDto companyDto = new CompanyDto
            {
                Id = company.Id,
                CompanyAttributeValues = MapAllCompanyAttributValuesToCompanyAttributValueDtos(company.CompanyAttributeValues)
            };

            return companyDto;
        }

        private List<CompanyAttributeValueDto> MapAllCompanyAttributValuesToCompanyAttributValueDtos(List<CompanyAttributeValue> companyCompanyAttributeValues)
        {
            List<CompanyAttributeValueDto> companyAttributeValueDtos = new List<CompanyAttributeValueDto>();

            if (companyCompanyAttributeValues != null)
            {
                foreach (CompanyAttributeValue companyAttributeValue in companyCompanyAttributeValues)
                {
                    companyAttributeValueDtos.Add(MapCompanyAttributeValueToCompanyAttributeValueDto(companyAttributeValue));
                }
            }

            return companyAttributeValueDtos;
        }

        private CompanyAttributeValueDto MapCompanyAttributeValueToCompanyAttributeValueDto(CompanyAttributeValue companyAttributeValue)
        {
            CompanyAttributeValueDto companyAttributeValueDto = new CompanyAttributeValueDto
            {
                CompanyAttributeId = companyAttributeValue.CompanyAttributeId,
                CompanyId = companyAttributeValue.CompanyAttributeId,
                Value = companyAttributeValue.Value
            };

            return companyAttributeValueDto;
        }

        public Company MapCompanyDtoToCompany(CompanyDto companyDto)
        {
            Company company = new Company
            {
                Id = companyDto.Id,
                CompanyAttributeValues = MapAllCompanyAttributValueDtosToCompanyAttributValues(companyDto.CompanyAttributeValues)
            };

            return company;
        }

        private List<CompanyAttributeValue> MapAllCompanyAttributValueDtosToCompanyAttributValues(List<CompanyAttributeValueDto> companyCompanyAttributeValueDtos)
        {
            List<CompanyAttributeValue> companyAttributeValues = new List<CompanyAttributeValue>();

            if (companyCompanyAttributeValueDtos != null)
            {
                foreach (CompanyAttributeValueDto companyAttributeValueDto in companyCompanyAttributeValueDtos)
                {
                    companyAttributeValues.Add(MapCompanyAttributeValueDtoToCompanyAttributeValue(companyAttributeValueDto));
                }
            }
            return companyAttributeValues;
        }

        public CompanyAttributeValue MapCompanyAttributeValueDtoToCompanyAttributeValue(CompanyAttributeValueDto companyAttributeValueDto)
        {
            CompanyAttributeValue companyAttributeValue = new CompanyAttributeValue
            {
                CompanyAttributeId = companyAttributeValueDto.CompanyAttributeId,
                CompanyId = companyAttributeValueDto.CompanyId,
                Value = companyAttributeValueDto.Value
            };

            return companyAttributeValue;
        }

        public CompanyAttributeDto MapCompanyAttributeToCompanyAttributeDto(CompanyAttribute companyAttribute)
        {
            CompanyAttributeDto companyAttributeDto = new CompanyAttributeDto
            {
                Id = companyAttribute.Id,
                Name = companyAttribute.Name,
                CompanyAttributeValues = MapAllCompanyAttributValuesToCompanyAttributValueDtos(companyAttribute.CompanyAttributeValues)
            };

            return companyAttributeDto;
        }

        public CompanyAttribute MapCompanyAttributeDtoToCompanyAttribute(CompanyAttributeDto companyAttributeDto)
        {
            CompanyAttribute companyAttribute = new CompanyAttribute
            {
                Id = companyAttributeDto.Id,
                Name = companyAttributeDto.Name,
                CompanyAttributeValues =
                    MapAllCompanyAttributValueDtosToCompanyAttributValues(companyAttributeDto.CompanyAttributeValues)
            };

           return companyAttribute;
        }
    }
}