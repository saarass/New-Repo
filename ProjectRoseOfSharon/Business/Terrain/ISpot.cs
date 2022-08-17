namespace ProjectRoseOfSharon.Business
{
    /// <summary>
    /// Een plek op een terrain. Er kan hooguit 1 biological op een tile staan.
    /// </summary>
    public interface ISpot
    {
        /// <summary>
        /// De biological op deze spot.
        /// </summary>
        IBiological? Biological { get; }

        /// <summary>
        /// De positie van deze spot op het terrein.
        /// </summary>
        Position Position { get; }

        /// <summary>
        /// Het terrein waarop deze spot zich bevindt.
        /// </summary>
        Terrain Terrain { get; }

        /// <summary>
        /// Het aantal porties fertilizer op deze spot.
        /// </summary>
        int AmountOfFertilizer { get; }

        /// <summary>
        /// De configuratie van deze spot.
        /// </summary>
        ISpotConfig Config { get; }

        /// <summary>
        /// Geeft de relatieve spot ten opzichte van deze spot in de gegeven richting (met stap 1)
        /// </summary>
        ISpot? GetRelativeSpot(Direction direction);

        /// <summary>
        /// Of deze spot vrij is van biologicals.
        /// </summary>
        bool IsFree();

        /// <summary>
        /// Plaatst de biological op deze spot (let op: verwijder zelf de biological van de andere spot).
        /// Gooit een <see cref="InvalidOperationException"/> als er al een biological op deze spot staat.
        /// </summary>
        void Move(IBiological biological);

        /// <summary>
        /// Poep op deze spot.
        /// </summary>
		void Poop(int amount);

        /// <summary>
        /// Verwijdert de biological van deze spot (handig wanneer je een biological wil verplaatsen van de ene naar de andere spot).
        /// </summary>
        /// <param name="biological"></param>
		void Remove(IBiological biological);

        /// <summary>
        /// Geeft de ratio van vruchtbaarheid, 0 = niets te eten, tot 1 == volledig vol voedsel, kan niets meer bij.
        /// </summary>
        float GetFertilityRatio();

        /// <summary>
        /// Voert het gedrag voor de volgende iteratie uit (wordt aangeroepen vanuit Terrain).
        /// </summary>
        void Update();
    }
}