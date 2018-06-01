using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightClub
{
    class User : Player
    {
        public User()
        {
            Name = "Player1";
            Hp = 100;
        }
        public User(string Name )
        {
            this.Name = Name;
            Hp = 100;
        }


    }
}
