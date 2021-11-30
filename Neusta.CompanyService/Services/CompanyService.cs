using System.Collections.Generic;
using System.Linq;
using Neusta.CompanyService.Database.Entities;
using Neusta.CompanyService.Database.Repositories;
using Neusta.CompanyService.DTOs;
using Neusta.CompanyService.Mappers;
using Neusta.CompanyService.Validators;

namespace Neusta.CompanyService.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repository;
        private readonly ICompanyMapper _mapper;
        private readonly ICompanyValidator _validator;

        public CompanyService(ICompanyRepository repository, ICompanyMapper mapper, ICompanyValidator validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }
        public IList<CompanyDto> GetAll()
        {
            IList<Company> companies = _repository.GetAll();
            return companies.Select(_mapper.MapCompanyToCompanyDto).ToList();
        }

        public CompanyDto GetById(long id)
        {
            Company company = _repository.GetById(id);
            _validator.FoundCompany(company);
            return _mapper.MapCompanyToCompanyDto(company);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public IList<CompanyAttributeDto> GetAllAttributeDtos()
        {
            IList<CompanyAttribute> companyAttributes = _repository.GetAllAttributes();
            return companyAttributes.Select(_mapper.MapCompanyAttributeToCompanyAttributeDto).ToList();
        }

        public void Save(CompanyDto companyDto)
        {
            Company company = _mapper.MapCompanyDtoToCompany(companyDto);
            _repository.Save(company);
        }

        public void Update(CompanyDto companyDto)
        {
            Company company = _mapper.MapCompanyDtoToCompany(companyDto);
            _repository.Update(company);
        }

        public void SaveAttribute(CompanyAttributeDto attributeDto)
        {
            CompanyAttribute attribute = _mapper.MapCompanyAttributeDtoToCompanyAttribute(attributeDto);
            _repository.SaveAttribute(attribute);
        }

        public void UpdateAttribute(CompanyAttributeDto attributeDto)
        {
            CompanyAttribute attribute = _mapper.MapCompanyAttributeDtoToCompanyAttribute(attributeDto);
            _repository.UpdateAttribute(attribute);
        }

        public void UpdateAttributeValue(CompanyAttributeValueDto valueDto)
        {
            CompanyAttributeValue value = _mapper.MapCompanyAttributeValueDtoToCompanyAttributeValue(valueDto);
            _repository.UpdateAttributeValue(value);
        }

        public void SaveAttributeValue(CompanyAttributeValueDto valueDto)
        {
            CompanyAttributeValue value = _mapper.MapCompanyAttributeValueDtoToCompanyAttributeValue(valueDto);
            _repository.SaveAttributeValue(value);
        }
    }
}