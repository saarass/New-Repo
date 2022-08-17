namespace ProjectRoseOfSharon.Business
{
    /// <summary>
    /// Een plek op een terrain. Er kan hooguit 1 biological op een tile staan.
    /// </summary>
    public abstract class SpotBase : ISpot
    {
        /// <summary>
        /// Aantal porties mest dat er op deze spot aanwezig is.
        /// </summary>
        public int AmountOfFertilizer { get; protected set; }

        public SpotBase(ISpotConfig config, Terrain terrain, Position position)
        {
			Config = config;
			Terrain = terrain;
            Position = position;
        }

        /// <summary>
        /// De configuratie van deze spot.
        /// </summary>
		public ISpotConfig Config { get; }

        /// <summary>
        /// Het terrein waarop deze spot zich bevindt.
        /// </summary>
		public Terrain Terrain { get; }

        /// <summary>
        /// De positie van deze spot op het terrein.
        /// </summary>
        public Position Position { get; }

        /// <summary>
        /// De biological op deze spot.
        /// </summary>
        public IBiological? Biological { get; private set; }

        /// <summary>
        /// Of deze spot vrij is van biologicals.
        /// </summary>
        public bool IsFree()
        {
            return Biological == null;
        }

        /// <summary>
        /// Geeft de ratio van vruchtbaarheid, 0 = niets te eten, tot 1 == volledig vol voedsel, kan niets meer bij.
        /// </summary>
        public abstract float GetFertilityRatio();

        /// <summary>
        /// Verwijdert de biological van deze spot (handig wanneer je een biological wil verplaatsen van de ene naar de andere spot).
        /// </summary>
        public void Remove(IBiological biological)
        {
            Biological = null;
        }

        /// <summary>
        /// Plaatst de biological op deze spot (let op: verwijder zelf de biological van de andere spot).
        /// Gooit een <see cref="InvalidOperationException"/> als er al een biological op deze spot staat.
        /// </summary>
        public void Move(IBiological biological)
        {
            if (Biological != null)
            {
                throw new InvalidOperationException($"This spot is already taken by a {Biological.GetType().Name}!");
            }

            Biological = biological;
        }

        /// <summary>
        /// Geeft de relatieve spot ten opzichte van deze spot in de gegeven richting (met stap 1)
        /// </summary>
        public ISpot? GetRelativeSpot(Direction direction)
        {
            Position newPos = Position.To(direction);

            if (Terrain.IsOutOfBounds(newPos))
            {
                return null;
            }
            else
            {
                return Terrain.Spots[newPos.X, newPos.Y];
            }
        }

        /// <summary>
        /// Of de spot in gegeven richting ook daadwerkelijk van type T is.
        /// </summary>
        protected bool Is<T>(Direction d) where T : ISpot
        {
            var spot = GetRelativeSpot(d);

            return spot != null && spot is T;
        }

        /// <summary>
        /// Poep op deze spot.
        /// </summary>
        public void Poop(int amount)
        {
            if (AmountOfFertilizer != Config.MaxAmountOfFertilizer)
            {
                AmountOfFertilizer = Math.Clamp(AmountOfFertilizer + amount, 0, Config.MaxAmountOfFertilizer);
            }
        }

        /// <summary>
        /// Voert het gedrag voor de volgende iteratie uit (wordt aangeroepen vanuit Terrain).
        /// </summary>
        public abstract void Update();

        // handig met debuggen
        public override string ToString()
        {
            return $"Spot at {Position}, type: {GetType().Name}, biological: {Biological?.GetType().Name}";
        }
    }
}