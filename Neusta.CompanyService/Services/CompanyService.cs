using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Neusta.CompanyService.Database.Entities;
using Neusta.CompanyService.Database.Repositories;
using Neusta.CompanyService.DTOs;

using Neusta.CompanyService.Validators;

namespace Neusta.CompanyService.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICompanyValidator _validator;

        public CompanyService(ICompanyRepository repository, IMapper mapper, ICompanyValidator validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }
        public IList<CompanyDto> GetAll()
        {
            IList<Company> companies = _repository.GetAll();
            return _mapper.Map<List<CompanyDto>>(companies);
        }

        public CompanyDto GetById(long id)
        {
            Company company = _repository.GetById(id);
            _validator.FoundCompany(company);
            return _mapper.Map<CompanyDto>(company);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public void DeleteAttribute(long id)
        {
            _repository.DeleteAttribute(id);
        }


        public IList<CompanyAttributeDto> GetAllAttributes()
        {
            IList<CompanyAttribute> companyAttributes = _repository.GetAllAttributes();
            return _mapper.Map<List<CompanyAttributeDto>>(companyAttributes);
        }

        public CompanyAttributeDto GetAttributeById(long id)
        {
            CompanyAttribute attribute = _repository.GetAttributeById(id);
            return _mapper.Map<CompanyAttributeDto>(attribute);
        }

        public void Save(CompanyDto companyDto)
        {
            Company company = _mapper.Map<Company>(companyDto);
            _repository.Save(company);
        }

        public void Update(CompanyDto companyDto)
        {
            Company company = _mapper.Map<Company>(companyDto);
            _repository.Update(company);
        }

        public void SaveAttribute(CompanyAttributeDto attributeDto)
        {
            CompanyAttribute attribute = _mapper.Map<CompanyAttribute>(attributeDto);
            _repository.SaveAttribute(attribute);
        }

        public void UpdateAttribute(CompanyAttributeDto attributeDto)
        {
            CompanyAttribute attribute = _mapper.Map<CompanyAttribute>(attributeDto);
            _repository.UpdateAttribute(attribute);
        }

        public void UpdateAttributeValue(CompanyAttributeValueDto valueDto)
        {
            CompanyAttributeValue value = _mapper.Map<CompanyAttributeValue>(valueDto);
            _repository.UpdateAttributeValue(value);
        }

        public void SaveAttributeValue(CompanyAttributeValueDto valueDto)
        {
            CompanyAttributeValue value = _mapper.Map<CompanyAttributeValue>(valueDto);
            _repository.SaveAttributeValue(value);
        }
    }
}