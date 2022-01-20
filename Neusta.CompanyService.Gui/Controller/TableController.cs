using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neusta.CompanyService.Gui.Models;
using Neusta.CompanyService.Gui.Services;

namespace Neusta.CompanyService.Gui.Controller
{
    public class TableController : Microsoft.AspNetCore.Mvc.Controller
    {
        private TableModel tableModel;
        private ICompanyService companyService;

        public TableController(ICompanyService service)
        {
            companyService = service;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["TableModel"] = new TableModel
            {
                Attributes = await companyService.GetAttributes(),
                Companies = await companyService.Get()
            };
            return View();
        }
        public async Task<IActionResult> PartialVIew()
        {
            
            return View();
        }


    }
}
