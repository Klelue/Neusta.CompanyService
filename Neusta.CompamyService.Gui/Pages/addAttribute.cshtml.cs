using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Neusta.CompamyService.Gui.CompanyServiceApi;

namespace Neusta.CompamyService.Gui.Pages
{
    public class addAttributeModel : PageModel
    {
       
        public void OnGet()
        {
        }

        public async Task OnPostAsync(string attributeName)
        {
            if (attributeName.Trim() == "")
            {
                return;
            }

            await CreateNewAttributeDto(attributeName);
        }


        private async Task<CompanyAttributeDto> CreateNewAttributeDto(string attributeName)
        {
            CompanyAttributeDto attribute = new CompanyAttributeDto
            {
                Name = attributeName
            };

            return attribute;
        }

    }
}
