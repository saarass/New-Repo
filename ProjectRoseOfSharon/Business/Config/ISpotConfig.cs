namespace ProjectRoseOfSharon.Business
{
	public interface ISpotConfig
    {
        /// <summary>
        /// De maximum hoeveelheid mest dat op een enkele spot aanwezig kan zijn. 
        /// </summary>
        int MaxAmountOfFertilizer { get; set; }
        
        /// <summary>
        /// De minimale hoeveelheid mest dat nodig is om een spot te laten evolueren.
        /// </summary>
        int MinAmountOfFertilizerForEvolution { get; set; }
    }
}
