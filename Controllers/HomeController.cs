using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoleTOP_MVC.Models;

namespace RoleTOP_MVC.Controllers {
    public class HomeController : Controller {
        public IActionResult Index () {
            //ViewData["NomeView"] = "Home";
            ViewData.Add("NomeView","Home");
            return View ();
        }
        public IActionResult Estrutura () {
            return View ();
        }
    }
}