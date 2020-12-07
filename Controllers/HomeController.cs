using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Theme_20_Homework_fromEmpty;

namespace Theme_20_Homework_fromEmpty
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
            //return RedirectToAction("GameOver", "Result", new { area = "" });
            //return RedirectToAction("GameOver", "Result");
        }
    }
}
