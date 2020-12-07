using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theme_20_Homework_fromEmpty
{
    public class Game
    {

        public static int defaultStartValue;
        public static int defaultStepValue;
        public static string BotName;

        static Game()
        {
            defaultStartValue = 33;
            defaultStepValue = 5;
            BotName = "Bot";
        }

        private List<string> users;
        //private int InitialCount;
        
        public int MaxStep { get; }
        
        public int Count { get;  set; }
        
        public string CurrentUser { get;  set; }

        private int currentUserID;
        public bool GameOver { get; private set; }

        public Game(int maxStep, int InitValue, params string[] User)
        {
            Count = InitValue;
            MaxStep = maxStep;
            users = new List<string>( User);
            if (User.Length == 1)
            {
                users.Add(BotName);
            }
            currentUserID = 0;
            CurrentUser = users[currentUserID];
        }

        public Game() { }
       

        public void Step(int stepvalue)
        {
            if ((Count - stepvalue) >= 0)
            {

                Count -= stepvalue;
                if (Count == 0)
                {
                    GameOver = true;
                }
                
            }
          //  nextStep();
        }

        public void nextUser()
        {
            if (currentUserID < users.Count-1)
            {
                currentUserID++;
            }
            else
            {
                currentUserID = 0;
            }

            CurrentUser = users[currentUserID];
            //if(CurrentUser == BotName)
            //{
            //    Step(autostep());
            //}
        }

        public int Botstep()
        {
            int result;
            if (Count <= MaxStep-1)
                result = Count;
            else if (Count % (MaxStep-1) != 0)
            {

                result = Count - (Count / (MaxStep-1)) * (MaxStep-1) - 1;
                if (result == 0)
                    result = MaxStep - 1;
            }
            else 
                result = (new Random()).Next(1,MaxStep);
            return result;
        }
    }
}
