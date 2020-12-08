using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Theme_20_Homework_fromEmpty.Models
{
    public class User : IEquatable<User>
    {
        public static string BotName;
        public static int BotId;

        static User()
        {
            BotName = "Bot";
            BotId = 0;
        }

        //public static User GetBot()
        //{
        //    return new User
        //    {
        //      //  Id = BotId,
        //        Name = BotName
        //    };
        //}

        public bool Equals(User other)
        {
            return this.Id == other.Id;
        }

        public User() 
        {
            Games = new List<Game>();
        }



        public int Id { get; set; }
     //   [Key]
        public string Name { get; set; }

        public List<Game> Games { get; set; }

        public void AddGame(Game game)
        {
            Games.Add(game);
        }
    }
}
