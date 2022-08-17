using NUnit.Framework;
using ProjectRoseOfSharon;
using ProjectRoseOfSharon.Business;

namespace ProjectRoseOfSharonTests
{
	public class TestTerrain
	{
		private Terrain Terrain { get; } = new Terrain(new TerrainConfig()
		{
			Height = 2,
			Width = 2
		}, new CowConfig(), new GoatConfig(), new DesertConfig(), new GrassConfig(), new ForestConfig());

		[SetUp]
		public void Setup()
		{
			
		}

        [Test]
        public void GetRelativeSpot_OutOfBoundsTop_ReturnsNull()
        {
            var result = Terrain.GetSpot(new Position(0, 0)).GetRelativeSpot(ProjectRoseOfSharon.Direction.Up);
            Assert.Null(result);
        }


        [Test]
        public void Move_OutOfBoundsRight_ReturnsNull()
        {
            var result = Terrain.GetSpot(new Position(1, 0)).GetRelativeSpot(ProjectRoseOfSharon.Direction.Right);
            Assert.Null(result);
        }

        [Test]
        public void Move_OutOfBoundsBottom_ReturnsFalse()
        {
            var result = Terrain.GetSpot(new Position(0, 1)).GetRelativeSpot(ProjectRoseOfSharon.Direction.Down);
            Assert.Null(result);
        }

        [Test]
        public void Move_OutOfBoundsLeft_ReturnsFalse()
        {
            var result = Terrain.GetSpot(new Position(0, 0)).GetRelativeSpot(ProjectRoseOfSharon.Direction.Left);
            Assert.Null(result);
        }

        [Test]
        public void GetRelativeSpot_Up_ReturnsCorrectSpot()
        {
            var result = Terrain.GetSpot(new Position(1, 1)).GetRelativeSpot(Direction.Up);
            Assert.AreEqual(result?.Position, new Position(1, 0));
        }

        [Test]
        public void GetRelativeSpot_Right_ReturnsCorrectSpot()
        {
            var result = Terrain.GetSpot(new Position(0, 0)).GetRelativeSpot(Direction.Right);
            Assert.AreEqual(result?.Position, new Position(1, 0));
        }

        [Test]
        public void GetRelativeSpot_Down_ReturnsCorrectSpot()
        {
            var result = Terrain.GetSpot(new Position(0, 0)).GetRelativeSpot(Direction.Down);
            Assert.AreEqual(result?.Position, new Position(0, 1));
        }

        [Test]
        public void GetRelativeSpot_Left_ReturnsCorrectSpot()
        {
            var result = Terrain.GetSpot(new Position(1, 1)).GetRelativeSpot(Direction.Left);
            Assert.AreEqual(result?.Position, new Position(0, 1));
        }

        [Test]
        public void GetRelativeSpot_RightUp_ReturnsCorrectSpot()
        {
            var result = Terrain.GetSpot(new Position(0, 1)).GetRelativeSpot(Direction.Right | Direction.Up);
            Assert.AreEqual(result?.Position, new Position(1, 0));
        }

        [Test]
        public void GetRelativeSpot_RightDown_ReturnsCorrectSpot()
        {
            var result = Terrain.GetSpot(new Position(0, 0)).GetRelativeSpot(Direction.Right | Direction.Down);
            Assert.AreEqual(result?.Position, new Position(1, 1));
        }

        [Test]
        public void GetRelativeSpot_LeftUp_ReturnsCorrectSpot()
        {
            var result = Terrain.GetSpot(new Position(1, 1)).GetRelativeSpot(Direction.Left | Direction.Up);
            Assert.AreEqual(result?.Position, new Position(0, 0));
        }

        [Test]
        public void GetRelativeSpot_LeftDown_ReturnsCorrectSpot()
        {
            var result = Terrain.GetSpot(new Position(1, 0)).GetRelativeSpot(Direction.Left | Direction.Down);
            Assert.AreEqual(result?.Position, new Position(0, 1));
        }
    }
}