using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Neusta.CompamyService.Gui.CompanyServiceApi;
using Neusta.CompamyService.Gui.Services;

namespace Neusta.CompamyService.Gui.Models
{
    public class TableValues
    {
        public IList<CompanyAttributeDto> Attributes { get; set; }
        public IList<CompanyDto> Companies { get; set; }
    }
}