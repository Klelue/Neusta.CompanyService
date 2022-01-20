using System.Collections.Generic;
using Neusta.CompanyService.Gui.CompanyServiceApi;

namespace Neusta.CompanyService.Gui.Models
{
    public class TableModel
    {
        public IList<CompanyAttributeDto> Attributes { get; set; }
        public IList<CompanyDto> Companies { get; set; }

    }
}