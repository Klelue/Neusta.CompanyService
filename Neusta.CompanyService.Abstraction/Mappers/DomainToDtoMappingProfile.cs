using AutoMapper;
using Neusta.CompanyService.Database.Entities;
using Neusta.CompanyService.DTOs;

namespace Neusta.CompanyService.Mappers
{

    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<CompanyAttribute, CompanyAttributeDto>().ReverseMap();
            CreateMap<CompanyAttributeValue, CompanyAttributeValueDto>().ReverseMap();
        }
    }
}