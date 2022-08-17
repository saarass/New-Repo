namespace ProjectRoseOfSharon.Business
{
	public interface IAnimalConfig
    {
        /// <summary>
        /// De afstand (hemelsbreed) waarbinnen dit dier iets kan waarnemen. 
        /// Let op: omdat een diagonale stap net zo snel gaat als een verticale of horizontale stap, is het gezichtsveld
        /// een vierkant, en niet een cirkel zoals je wellicht zou verwachten.
        /// </summary>
        int ViewRange { get; set; }

        /// <summary>
        /// De maximale "FoodLevel" van een dier.
        /// </summary>
        int MaxFoodLevel { get; set; }

        /// <summary>
        /// De minimale "FoodLevel" voor een gezond dier. Wanneer de "FoodLevel" van een dier lager is
        /// dan deze waarde, wilt hij/zij alleen nog maar eten, en negeert dus waar de herder of kudde is
        /// totdat de FoodLevel weer op peil is.
        /// </summary>
        int MinHealthyFoodLevel { get; set; }

		/// <summary>
        /// Aantal porties gras dat een dier in 1 maaltijd consumeert.
        /// </summary>
        int PortionsPerMeal { get; set; }

        /// <summary>
        /// Minimale hoeveelheid poep dat een dier in zijn darmen heeft voordat het moet poepen.
        /// </summary>
		int MinPoopLevelToDefecate { get; set; }

        /// <summary>
        /// Op het moment dat een dier poept, wordt het samengeperst. Dit getal (tussen 0 en 1) geeft aan 
        /// hoeveel volume de poep nog heeft bij het poepen. Factor van 1 is 100% van de poep, .2 geeft aan 20% van de poep.
        /// </summary>
        int PoopCompressionFactor { get; set; }

        /** Onderstaande items zijn voor het configureren van de gelijknamige configuratie waarden. Hierin staan de min en max waarden geconfigureerd. */

        ConfigItem ViewRangeConfig { get; }
        ConfigItem MaxFoodLevelConfig { get; }
        ConfigItem MinHealthyFoodLevelConfig { get; }
        ConfigItem PortionsPerMealConfig { get; }
		ConfigItem MinPoopLevelToDefecateConfig { get; }
        ConfigItem PoopCompressionFactorConfig { get; }

    }
}
