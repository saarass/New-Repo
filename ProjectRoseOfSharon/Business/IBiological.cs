namespace ProjectRoseOfSharon.Business
{
    /// <summary>
    /// Alle herders en dieren zijn biologicals.
    /// </summary>
	public interface IBiological
    {
        /// <summary>
        /// De spot waarop deze IBiological zich bevindt.
        /// </summary>
        ISpot Spot { get; set; }

        /// <summary>
        /// Voert het gedrag voor de volgende iteratie uit (wordt aangeroepen vanuit Terrain).
        /// </summary>
        void Update();

    }
}
