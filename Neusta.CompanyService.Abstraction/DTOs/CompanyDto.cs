using System.Collections.Generic;

namespace Neusta.CompanyService.DTOs
{
    public class CompanyDto
    {
        public long Id { get; set; }

        public bool Visible { get; set; }

        public List<CompanyAttributeValueDto> CompanyAttributeValues { get; set; }
    }
}