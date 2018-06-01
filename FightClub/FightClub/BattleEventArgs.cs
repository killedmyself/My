using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightClub
{
    class BattleEventArgs : EventArgs 
    {
        public string name { get; set; }
        public int hp { get; set; }
        public BodyParts body { get; set; }
        public BattleEventArgs(string name, int hp)
        {
            this.name = name;
            this.hp = hp;
        }
    }
}
