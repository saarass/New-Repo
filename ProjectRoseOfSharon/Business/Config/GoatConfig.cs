namespace ProjectRoseOfSharon.Business
{
	public class GoatConfig : IAnimalConfig
    {
        public int ViewRange { get; set; }
        public int MaxFoodLevel { get; set; }
        public int MinHealthyFoodLevel { get; set; }
        public int PortionsPerMeal { get; set; }
        public int MinPoopLevelToDefecate { get; set; }
        public int PoopCompressionFactor { get; set; }

        public GoatConfig()
        {
            ViewRange = ViewRangeConfig.Default;
            MaxFoodLevel = MaxFoodLevelConfig.Default;
            MinHealthyFoodLevel = MinHealthyFoodLevelConfig.Default;
            PortionsPerMeal = PortionsPerMealConfig.Default;
            MinPoopLevelToDefecate = MinPoopLevelToDefecateConfig.Default;
            PoopCompressionFactor = PoopCompressionFactorConfig.Default;
        }

        public ConfigItem ViewRangeConfig { get; } = new(1, 30, 50);
        public ConfigItem MaxFoodLevelConfig { get; } = new(1, 15, 60);
        public ConfigItem MinHealthyFoodLevelConfig { get; } = new(1, 5, 50);
        public ConfigItem PortionsPerMealConfig { get; } = new(1, 2, 10);
        public ConfigItem MinPoopLevelToDefecateConfig { get; } = new(1, 10, 20);
        public ConfigItem PoopCompressionFactorConfig { get; } = new(1, 70, 100);
    }
}
