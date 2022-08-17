using NUnit.Framework;
using ProjectRoseOfSharon;
using ProjectRoseOfSharon.Business;

namespace ProjectRoseOfSharonTests
{
	public class TestPosition
	{
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Equality_SameInstance_AreEqual()
		{
            Position posA = new Position(5, 7);
            Position posB = posA;

            Assert.AreEqual(posA, posB);
            Assert.True(posA == posB);
        }

        [Test]
        public void Equality_DifferentInstanceSameCoordinates_AreEqual()
        {
            Position posA = new Position(5, 7);
            Position posB = new Position(5, 7);

            Assert.AreEqual(posA, posB);
            Assert.True(posA == posB);
        }

        [Test]
        public void Equality_DifferentCoordinates_AreNotEqual()
        {
            Position posA = new Position(5, 7);
            Position posB = new Position(5, 8);

            Assert.AreNotEqual(posA, posB);
            Assert.True(posA != posB);

            posA = new Position(5, 7);
            posB = new Position(6, 7);

            Assert.AreNotEqual(posA, posB);
            Assert.True(posA != posB);
        }

        [Test]
        public void Add_Xis0AndYisNegative1_GivesCorrectCoordinate()
        {
            Position posA = new Position(5, 10);
            Position posB = posA.Add(0, -1);

            Assert.AreEqual(new Position(5, 9), posB);
        }

        [Test]
        public void Add_Xis1AndYisNegative1_GivesCorrectCoordinate()
        {
            Position posA = new Position(5, 10);
            Position posB = posA.Add(1, -1);

            Assert.AreEqual(new Position(6, 9), posB);
        }

        [Test]
        public void Add_Xis1AndYis0_GivesCorrectCoordinate()
        {
            Position posA = new Position(5, 10);
            Position posB = posA.Add(1, 0);

            Assert.AreEqual(new Position(6, 10), posB);
        }

        [Test]
        public void Add_Xis1AndYis1_GivesCorrectCoordinate()
		{
            Position posA = new Position(5, 10);
            Position posB = posA.Add(1, 1);

            Assert.AreEqual(new Position(6, 11), posB);
		}

        [Test]
        public void Add_Xis0AndYis1_GivesCorrectCoordinate()
        {
            Position posA = new Position(5, 10);
            Position posB = posA.Add(0, 1);

            Assert.AreEqual(new Position(5, 11), posB);
        }

        [Test]
        public void Add_XisNegative1AndYis1_GivesCorrectCoordinate()
        {
            Position posA = new Position(5, 10);
            Position posB = posA.Add(-1, 1);

            Assert.AreEqual(new Position(4, 11), posB);
        }

        [Test]
        public void Add_XisNegative1AndYis0_GivesCorrectCoordinate()
        {
            Position posA = new Position(5, 10);
            Position posB = posA.Add(-1, 0);

            Assert.AreEqual(new Position(4, 10), posB);
        }

        [Test]
        public void Add_XisNegative1AndYisNegative1_GivesCorrectCoordinate()
        {
            Position posA = new Position(5, 10);
            Position posB = posA.Add(-1, -1);

            Assert.AreEqual(new Position(4, 9), posB);
        }

        [Test]
        public void DistanceTo_AtoBAndBtoA_GivesSameResult()
		{
            Position posA = new Position(5, 10);
            Position posB = new Position(7, 2);

            Assert.AreEqual(posA.DistanceTo(posB), posB.DistanceTo(posA));
		}

        [Test]
        public void DistanceTo_SomePosition_GivesCorrectDistance()
        {
            Position posA = new Position(5, 10);
            Position posB = new Position(10, 10);

            Assert.AreEqual(5, posA.DistanceTo(posB));
        }

        [Test]
        public void DistanceTo_SomeDiagonalPosition_GivesCorrectDistance()
        {
            Position posA = new Position(5, 5);
            Position posB = new Position(10, 10);

            Assert.AreEqual(5, posA.DistanceTo(posB));
        }

        [Test]
        public void To_Up_GivesCorrectPosition()
		{
            Assert.AreEqual(new Position(5, 4), new Position(5, 5).To(Direction.Up));
		}

        [Test]
        public void To_UpRight_GivesCorrectPosition()
        {
            Assert.AreEqual(new Position(6, 4), new Position(5, 5).To(Direction.Up | Direction.Right));
        }

        [Test]
        public void To_Right_GivesCorrectPosition()
        {
            Assert.AreEqual(new Position(6, 5), new Position(5, 5).To(Direction.Right));
        }

        [Test]
        public void To_DownRight_GivesCorrectPosition()
        {
            Assert.AreEqual(new Position(6, 6), new Position(5, 5).To(Direction.Down | Direction.Right));
        }

        [Test]
        public void To_Down_GivesCorrectPosition()
        {
            Assert.AreEqual(new Position(5, 6), new Position(5, 5).To(Direction.Down));
        }

        [Test]
        public void To_DownLeft_GivesCorrectPosition()
        {
            Assert.AreEqual(new Position(4, 6), new Position(5, 5).To(Direction.Down | Direction.Left));
        }

        [Test]
        public void To_Left_GivesCorrectPosition()
        {
            Assert.AreEqual(new Position(4, 5), new Position(5, 5).To(Direction.Left));
        }

        [Test]
        public void To_UpLeft_GivesCorrectPosition()
        {
            Assert.AreEqual(new Position(4, 4), new Position(5, 5).To(Direction.Up | Direction.Left));
        }
    }
}