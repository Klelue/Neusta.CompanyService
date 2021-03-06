using System.Collections.Generic;

namespace Neusta.CompanyService.DTOs
{
    public class CompanyAttributeDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int OrderNumber { get; set; }

       public bool Visible { get; set; }

        public List<CompanyAttributeValueDto> CompanyAttributeValues { get; set; }
    }
}