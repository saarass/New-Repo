namespace ProjectRoseOfSharon.Business
{
    public class DesertSpot : SpotBase
    {
        public DesertSpot(DesertConfig config, Terrain terrain, Position position) : base(config, terrain, position)
        {
        }

		public override float GetFertilityRatio()
		{
            return 0; // desert is not fertile
		}

		public override void Update()
        {
            // TODO: er gebeurt nu nog niets...
        }
    }
}
