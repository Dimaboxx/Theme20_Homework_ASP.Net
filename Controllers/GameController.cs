using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Theme_20_Homework_fromEmpty.ContextFolder;
using Theme_20_Homework_fromEmpty.Models;

namespace Theme_20_Homework_fromEmpty
{
    public class GameController : Controller
    {
        public ILogger _logger;
    //    private IGameCenter _GameCenter;

   //     public Game game;

       // public GameController(ILogger<GameController> logger, IGameCenter GameCenter)
        public GameController(ILogger<GameController> logger)
        {
            // _GameCenter = GameCenter;
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
            DataContext dataContext = new DataContext();
            User user = dataContext.Users.SingleOrDefault(u => u.Name == name);
            if (user == null)
            {
                 user = new User() { Name = name };
                 dataContext.Users.Add(user);
            }
            User userbot = dataContext.Users.SingleOrDefault(u => u.Name == Models.User.BotName);
            if (userbot == null)
            {
                userbot = new User() { Name = Models.User.BotName };
                dataContext.Users.Add(user);
            }

            _logger.LogInformation($"startvalue : {startvalue} step : {step}");
            user.AddGame(new Game(int.Parse(step)+1, int.Parse(startvalue), user, userbot));
            dataContext.SaveChanges();
        //    _GameCenter.AddGame(new Game(int.Parse(step)+1, int.Parse(startvalue), name));
            return RedirectToAction("Index", "Game");
        }
 
        [HttpGet]
        public IActionResult Index( )
        {
            DataContext dataContext = new DataContext();





           // User user1 = dataContext.Users.Include(u => u.Games).OrderBy(u => u.Id).Last();
            User user = dataContext.Users.Where(u => u.Name != Models.User.BotName).Include(u => u.Games).ThenInclude(g => g.Users).OrderBy(u => u.Id).Last();

            Game currentGame = user.Games.Where(g => g.GameOver != true).OrderBy(e => e.Id).LastOrDefault();
            if (currentGame == null)
                return RedirectToAction("NewGame", "Game");
            if (!currentGame.GameOver)
            {
                if(currentGame.CurrentUser.Name == Models.User.BotName)
                {
                     currentGame.Step(currentGame.Botstep());
                     currentGame.nextUser();
                    dataContext.SaveChanges();
                    if (currentGame.GameOver)
                    {
                        return Redirect("~/Result/GameOver");
                    }
                       return Redirect("~/Game/Index");
                }



             ViewData["Game"] = currentGame;
            return View();

            }
            else
                return Redirect("~/Result/GameOver");
        }

        [HttpPost]
        public IActionResult Index(string nextstep)
        {

            DataContext dataContext = new DataContext();

            User user = dataContext.Users.Where(u => u.Name != Models.User.BotName).Include(u => u.Games).ThenInclude(g => g.Users).OrderBy(u => u.Id).Last();
            Game currentGame = user.Games.Where(g => g.GameOver != true).OrderBy(e => e.Id).LastOrDefault();

            currentGame.Step(int.Parse(nextstep));
            dataContext.SaveChanges();
            if (currentGame.GameOver)
                return Redirect("~/Result/WinerPage");
            currentGame.nextUser();
            dataContext.SaveChanges();
            return Redirect("~/Game/Index");
        }




    }
}
