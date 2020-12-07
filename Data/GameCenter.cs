using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theme_20_Homework_fromEmpty.Data
{
    public class GameCenter : IGameCenter
    {

        /// <summary>
        /// тут нужно соотносить пользователя и игру, пока это избыточно.
        /// </summary>
        /// 


        private List<Game> gamelist;

        public GameCenter()
        {
            gamelist = new List<Game>();
        }

        public void AddGame(Game game)
        {
            gamelist.Add(game);
        }
        
        public Game Game () { 
            
            {
                return gamelist[gamelist.Count-1];
            } 
        
        }


    }
}
