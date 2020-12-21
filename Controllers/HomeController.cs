using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Avaliação_PMESP.Models;

namespace Avaliação_PMESP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetImportacoes()
        {
            return View();
        }

        public IActionResult GetImportacao()
        {            
            return View();
        }
        
    }
}
