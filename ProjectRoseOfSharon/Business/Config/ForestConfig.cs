namespace ProjectRoseOfSharon.Business
{
	public class ForestConfig : ISpotConfig
	{
		public int MaxAmountOfFertilizer { get; set; }
		public int MinAmountOfFertilizerForEvolution { get; set; }
        public int MaxAmountOfBranches { get; set; }
        /// <summary>
        /// Aantal porties mest dat nodig is om 1 portie takken te laten groeien.
        /// </summary>
        public int FertilizerToBranchRatio { get; set; }

        /// <summary>
        /// Aantal iteraties waarna er 1 gratis portie takken wordt gegroeid (zonder de kosten van mest).
        /// </summary>
        public int NrOfIterationsForFreeBranch { get; set; }

        public ForestConfig()
        {
            MaxAmountOfFertilizer = MaxAmountOfFertilizerConfig.Default;
            MinAmountOfFertilizerForEvolution = MinAmountOfFertilizerForEvolutionConfig.Default;
            MaxAmountOfBranches = MaxAmountOfBranchesConfig.Default;
            FertilizerToBranchRatio = FertilizerToBranchRatioConfig.Default;
            NrOfIterationsForFreeBranch = NrOfIterationsForFreeBranchConfig.Default;
        }

        public ConfigItem MaxAmountOfFertilizerConfig { get; set; } = new(1, 30, 60);
        public ConfigItem MinAmountOfFertilizerForEvolutionConfig { get; set; } = new(1, 10, 40);
        public ConfigItem MaxAmountOfBranchesConfig { get; set; } = new(1, 30, 60);
        public ConfigItem FertilizerToBranchRatioConfig { get; set; } = new(1, 10, 20);
        public ConfigItem NrOfIterationsForFreeBranchConfig { get; set; } = new(1, 50, 100);
    }
}
