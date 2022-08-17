namespace ProjectRoseOfSharon.Business
{
	public class DesertConfig : ISpotConfig
    {
        public int MaxAmountOfFertilizer { get; set; }
        public int MinAmountOfFertilizerForEvolution { get; set; }

        public DesertConfig()
        {
            MaxAmountOfFertilizer = MaxAmountOfFertilizerConfig.Default;
            MinAmountOfFertilizerForEvolution = MinAmountOfFertilizerForEvolutionConfig.Default;
        }

        public ConfigItem MaxAmountOfFertilizerConfig { get; set; } = new(1, 15, 30);
        public ConfigItem MinAmountOfFertilizerForEvolutionConfig { get; set; } = new(1, 6, 40);
    }
}
