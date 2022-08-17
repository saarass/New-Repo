namespace ProjectRoseOfSharon.Business
{
    /// <summary>
    /// De basis voor alle biologicals (herders en dieren).
    /// </summary>
	public abstract class BiologicalBase : IBiological
	{
        /// <summary>
        /// De spot waarop deze biological zich begeeft.
        /// </summary>
        public ISpot Spot { get; set; }

        /// <summary>
        /// Het terrein waarop deze biological zich begeeft.
        /// </summary>
        protected Terrain Terrain => Spot.Terrain;

        /// <summary>
        /// Voor random dingen.
        /// </summary>
        protected readonly Random Dice = new Random();

        /// <summary>
        /// Maakt een biological en plaatst deze op de gegeven spot.
        /// </summary>
        /// <param name="spot"></param>
        public BiologicalBase(ISpot spot)
        {
            Spot = spot;
            spot.Move(this);
            Terrain.Biologicals.Add(this);
        }

        /// <summary>
        /// Beweeg naar de gegeven richting. Verwijdert de biological van de huidige spot en plaatst het op de spot in de gegeven richting.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns>true als het gelukt is, false als de biological niet in de gegeven richting kon bewegen</returns>
        public bool Move(Direction direction)
        {
            var spotTarget = Spot.GetRelativeSpot(direction);
            if (spotTarget != null && spotTarget.IsFree())
            {
                this.Spot.Remove(this);
                spotTarget.Move(this);
                this.Spot = spotTarget;
                return true;
            }
                
            return false;
        }

        /// <summary>
        /// Voert het gedrag voor de volgende iteratie uit (wordt aangeroepen vanuit Terrain).
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Geeft de richting naar de gegegeven target positie terug.
        /// </summary>
        protected Direction GetDirectionTo(Position target)
        {
            return Utils.GetDirectionTo(Spot, target);
        }
    }
}
