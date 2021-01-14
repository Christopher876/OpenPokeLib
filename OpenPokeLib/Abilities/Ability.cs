namespace OpenPokeLib.Abilities
{
    public abstract class Ability
    {
        public string Name { get; set; }

        //These are all the different times that an ability can activate and do something
        public virtual object BeforeTurn()
        {
            return null;
            
        } // For example to apply a multiplier to an attack such as with Blaze

        public virtual object BeforeTurn(object input)
        {
            return null;
        }

        public virtual object AfterOpponentAttack()
        {
            return null;
        } //For example Flash Fire to check if Pokemon is hit with a fire type move

        public virtual object AfterTurn()
        {
            return null;
        } // For example Rain Dish that replenishes Hp after both pokemon have attacked

        public virtual object Action()
        {
            return null;
        } //What should the ability do when it is triggered
        
        //Print out the ability
        
        public override string ToString()
        {
            return Name;
        }
    }
}