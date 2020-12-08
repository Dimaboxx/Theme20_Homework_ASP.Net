using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theme_20_Homework_fromEmpty.Models;

namespace Theme_20_Homework_fromEmpty
{
    public class Game
    {

        public static int defaultStartValue;
        public static int defaultStepValue;


        static Game()
        {
            defaultStartValue = 33;
            defaultStepValue = 5;
        }

        public List<User> Users { get; set; }
        //private int InitialCount;
        
        public int Id { get; set; } 

        public int MaxStep { get; set; }
        
        public int Count { get;  set; }
        
        public User CurrentUser { get => Users[currentUserID]; }
        public string CurrentUserName { get => Users[currentUserID].Name; }


        public int currentUserID { get; set; }

        public bool GameOver { get; private set; }

        public Game(int maxStep, int InitValue, params User[] user)
        {
            Count = InitValue;
            MaxStep = maxStep;
            Users = new List<User>(user);
//            Users.Add(user); 
//            AddBot();
            //if (User.Length == 1)
            //{
            //    Users.Add(BotName);
           // }
            currentUserID = 0;
 
        }

        public Game() { }
       
        //public void AddBot()
        //{
        //    Users.Add(User.GetBot());
        //}

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

        public void nextUser()
        {
            if (currentUserID < Users.Count-1)
            {
                currentUserID++;
            }
            else
            {
                currentUserID = 0;
            }

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
