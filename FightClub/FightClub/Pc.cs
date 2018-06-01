using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightClub
{
    class Pc : Player
    {
        public Pc()
        {
            Name = "Computer";
            Hp = 100;
        }
        public Pc(string Name)
        {
            this.Name = Name;
            Hp = 100;
        }
    }
}
