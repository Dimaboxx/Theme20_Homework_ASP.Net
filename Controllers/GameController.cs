using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Theme_20_Homework_fromEmpty.Data;

namespace Theme_20_Homework_fromEmpty
{
    public class GameController : Controller
    {
        public ILogger _logger;
        private IGameCenter _GameCenter;

   //     public Game game;

        public GameController(ILogger<GameController> logger, IGameCenter GameCenter)
        {
            _GameCenter = GameCenter;
            _logger = logger;
        }




        [HttpGet]
        public IActionResult NewGame()
        {
            _logger.LogInformation($" {DateTime.UtcNow} get new Game");


            return View();
        }

  
        [HttpPost]
        public IActionResult NewGame( string startvalue, string step, string name )
        {
            _logger.LogInformation($"startvalue : {startvalue} step : {step}");

            _GameCenter.AddGame(new Game(int.Parse(step), int.Parse(startvalue), name));
            return RedirectToAction("Index", "Game");
        }
 
        [HttpGet]
        public IActionResult Index( )
        {
            Game currentGame = _GameCenter.Game();
            if (!currentGame.GameOver)
            {
                ViewData["Game"] = currentGame;
                return View();

            }
            else
                return Redirect("~/Result/GameOver!");
        }

        [HttpPost]
        public IActionResult Index(string nextstep)
        {
            Game game = _GameCenter.Game();
            game.Step(int.Parse(nextstep));
            if (game.GameOver)
                return Redirect("~/Result/WinerPage");
            return Redirect("~/Game/Index");
        }




    }
}
