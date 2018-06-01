namespace FightClub
{
    abstract class Player : IOptions
    {
        BodyParts body { get; set; }
        public string Name { get; set; }
        public int Hp { get; set; }
        virtual public void getHit(BodyParts attacked, BattleEventArgs e)
        {
            if (attacked == body)
            {
                Block?.Invoke(this, e);
            }
            else
            {
                Hp -= (int)attacked;
                e.hp = Hp;
                if (Hp > 0)
                    Wound?.Invoke(this, e);
                else
                    Death?.Invoke(this, e);
            }
        }
        virtual public void setBlock(BodyParts defended)
        {
            body = defended;
        }
        public delegate void BattleEventHandler(object Sender, BattleEventArgs e);
        public event BattleEventHandler Block;   
        public event BattleEventHandler Wound;   
        public event BattleEventHandler Death;   

    }
}
