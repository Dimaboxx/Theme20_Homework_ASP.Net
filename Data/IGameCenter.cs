using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theme_20_Homework_fromEmpty.Data
{
    public interface IGameCenter
    {
        void AddGame(Game game);
        Game Game();
    }
}
