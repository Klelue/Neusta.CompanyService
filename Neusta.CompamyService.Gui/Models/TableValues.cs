﻿using Neusta.CompamyService.Gui.CompanyServiceApi;
using System.Collections.Generic;

namespace Neusta.CompamyService.Gui.Models
{
    public class TableValues
    {
        public IList<CompanyAttributeDto> Attributes { get; set; }
        public IList<CompanyDto> Companies { get; set; }
    }
}