using Neusta.CompamyService.Gui.CompanyServiceApi;
using System.Collections.Generic;

namespace Neusta.CompamyService.Gui.Models
{
    public class EditCompanyModel
    {
        public IList<CompanyAttributeDto> Attributes { get; set; }
        public CompanyDto Company { get; set; }
    }
}
