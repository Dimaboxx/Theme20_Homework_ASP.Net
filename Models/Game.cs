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
        static string BotName;

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
 
        }

        private void nextStep()
        {
            if (currentUserID < users.Count)
            {
                currentUserID++;
            }
            else
            {
                currentUserID = 0;
            }

            CurrentUser = users[currentUserID];
            if(CurrentUser == BotName)
            {
                Step(autostep());
            }
        }

        private int autostep()
        {
            int result;
            if (Count <= MaxStep)
                result = MaxStep;
            else if (Count % MaxStep != 0)
                result = Count - (Count / MaxStep) * MaxStep - 1;
            else 
                result = (new Random()).Next(MaxStep);
            return result;
        }
    }
}
