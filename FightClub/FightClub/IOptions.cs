namespace FightClub
{
    interface IOptions
    {
        //TODO: Block ,Wound ,Death
        void getHit(BodyParts p , BattleEventArgs e);
        void setBlock(BodyParts p);
       
    }
}
