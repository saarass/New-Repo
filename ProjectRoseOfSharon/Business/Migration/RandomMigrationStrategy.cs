namespace ProjectRoseOfSharon.Business.Migration
{
    public class RandomMigrationStrategy : IMigrationStrategy
    {
        private Random Dice { get; } = new Random();
        public Direction? GetDirection(ISpot spot, Direction dir)
        {
            Direction[] enumValues = Enum.GetValues<Direction>();
            int ix = Dice.Next(enumValues.Length);
            return enumValues[ix];
        }
    }
}
