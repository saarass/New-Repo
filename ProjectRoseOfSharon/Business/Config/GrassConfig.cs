namespace ProjectRoseOfSharon.Business
{
	public class GrassConfig : ISpotConfig
	{
		public int MaxAmountOfFertilizer { get; set; }
        public int MinAmountOfFertilizerForEvolution { get; set; }
        public int MaxAmountOfGrass { get; set; }
        /// <summary>
        /// Aantal porties mest dat nodig is om 1 portie gras te laten groeien.
        /// </summary>
        public int FertilizerToGrassRatio { get; set; }

        /// <summary>
        /// Aantal iteraties waarna er 1 gratis portie gras wordt gegroeid (zonder de kosten van mest).
        /// </summary>
        public int NrOfIterationsForFreeGrass { get; set; }

        public GrassConfig()
		{
            MaxAmountOfFertilizer = MaxAmountOfFertilizerConfig.Default;
            MinAmountOfFertilizerForEvolution = MinAmountOfFertilizerForEvolutionConfig.Default;
            MaxAmountOfGrass = MaxAmountOfGrassConfig.Default;
            FertilizerToGrassRatio = FertilizerToGrassRatioConfig.Default;
            NrOfIterationsForFreeGrass = NrOfIterationsForFreeGrassConfig.Default;
        }

        public ConfigItem MaxAmountOfFertilizerConfig { get; set; } = new(1, 15, 30);
        public ConfigItem MinAmountOfFertilizerForEvolutionConfig { get; set; } = new(1, 10, 40);
        public ConfigItem MaxAmountOfGrassConfig { get; set; } = new(1, 15, 30);
        public ConfigItem FertilizerToGrassRatioConfig { get; set; } = new(1, 5, 20);
        public ConfigItem NrOfIterationsForFreeGrassConfig { get; set; } = new(1, 50, 100);
    }
}
