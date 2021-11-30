using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Neusta.CompanyService.DTOs;
using Neusta.CompanyService.Services;

namespace Neusta.CompanyService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public IList<CompanyDto> GetAll()
        {
            return _companyService.GetAll();
        }

        [HttpGet("companyId")]
        public CompanyDto GetById(long id)
        {
            return _companyService.GetById(id);
        }

        [HttpDelete("companyID")]
        public ActionResult Delete(long id)
        {
            _companyService.Delete(id);
            return Ok();
        }

        [HttpPut("/attributeValues")]
        public ActionResult PutAttributeValue(CompanyAttributeValueDto value)
        {
            _companyService.UpdateAttributeValue(value);
            return Ok();
        }

        [HttpPost("/attributeValues")]
        public ActionResult PostAttributeValue(CompanyAttributeValueDto value)
        {
            _companyService.SaveAttributeValue(value);
            return Ok();
        }

        [HttpGet("/attributes")]
        public IList<CompanyAttributeDto> GetAllAttributes()
        {
            return _companyService.GetAllAttributeDtos();
        }

        [HttpPost("/attributes")]
        public ActionResult PostAttribute(CompanyAttributeDto attribute)
        {
            _companyService.SaveAttribute(attribute);
            return Ok();
        }

        [HttpPut("/attributes")]
        public ActionResult PutAttribute(CompanyAttributeDto attribute)
        {
            _companyService.UpdateAttribute(attribute);
            return Ok();
        }

        [HttpPost]
        public ActionResult Post(CompanyDto company)
        {
            _companyService.Save(company);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(CompanyDto company)
        {
            _companyService.Update(company);
            return Ok();
        }
    }
}
