using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Theme_20_Homework_fromEmpty
{
    public class ResultController : Controller
    {
        public IActionResult GameOver()
        {
            return View();
        }

        public IActionResult WinerPage()
        {
            return View();
        }
    }
}
