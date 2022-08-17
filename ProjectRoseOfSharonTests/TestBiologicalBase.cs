using NUnit.Framework;
using ProjectRoseOfSharon.Business;

namespace ProjectRoseOfSharonTests
{
	public class TestBiologicalBase
	{
		private Terrain? Terrain { get; set; }

		[SetUp]
		public void Setup()
		{
			var config = new TerrainConfig()
			{
				Height = 5,
				Width = 5
			};
			Terrain = new Terrain(config, new CowConfig(), new GoatConfig(), new DesertConfig(), new GrassConfig(), new ForestConfig());
		}

        [Test]
        public void Move_OutOfBoundsTop_ReturnsFalse()
        {
            // we don't have to test all out of bounds scenarios, since we already do that in TestTerrain
            var b = new TestBiological(new DesertSpot(new DesertConfig(), Terrain!, new Position(0, 0)));
            bool result = b.Move(ProjectRoseOfSharon.Direction.Up);
            Assert.False(result);
        }

        [Test]
        public void Move_OutOfBoundsRight_ReturnsFalse()
        {
            // we don't have to test all out of bounds scenarios, since we already do that in TestTerrain
            var b = new TestBiological(new DesertSpot(new DesertConfig(), Terrain!, new Position(4, 0)));
            bool result = b.Move(ProjectRoseOfSharon.Direction.Right);
            Assert.False(result);
        }

        [Test]
        public void Move_OutOfBoundsBottom_ReturnsFalse()
        {
            // we don't have to test all out of bounds scenarios, since we already do that in TestTerrain
            var b = new TestBiological(new DesertSpot(new DesertConfig(), Terrain!, new Position(0, 4)));
            bool result = b.Move(ProjectRoseOfSharon.Direction.Down);
            Assert.False(result);
        }

        [Test]
        public void Move_OutOfBoundsLeft_ReturnsFalse()
        {
            // we don't have to test all out of bounds scenarios, since we already do that in TestTerrain
            var b = new TestBiological(new DesertSpot(new DesertConfig(), Terrain!, new Position(0, 0)));
            bool result = b.Move(ProjectRoseOfSharon.Direction.Left);
            Assert.False(result);
        }

        [Test]
        public void Move_WithinBounds_ReturnsTrue()
        {
            // we don't have to test all scenarios, since we already do that in TestTerrain.
            var b = new TestBiological(new DesertSpot(new DesertConfig(), Terrain!, new Position(0, 1)));
            bool result = b.Move(ProjectRoseOfSharon.Direction.Up);
            Assert.True(result);
            Assert.AreEqual(b.Spot.Position, new Position(0, 0));
        }


    }

	internal class TestBiological : BiologicalBase
	{
		public TestBiological(ISpot spot) : base(spot)
		{
		}

		public override void Update()
		{
		}
	}
}