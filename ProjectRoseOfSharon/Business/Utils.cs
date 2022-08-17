namespace ProjectRoseOfSharon.Business
{
	public abstract class Utils
	{
        /// <summary>
        /// Keert de richting om, dus bijvoorbeeld <c>Up | Right</c> wordt <c>Down | Left</c>.
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static Direction Flip(Direction dir)
        {
            Direction result = 0;
            if (dir.HasFlag(Direction.Up))
            {
                result |= Direction.Down;
            }
            if (dir.HasFlag(Direction.Right))
            {
                result |= Direction.Left;
            }
            if (dir.HasFlag(Direction.Down))
            {
                result |= Direction.Up;
            }
            if (dir.HasFlag(Direction.Left))
            {
                result |= Direction.Right;
            }

            return result;
        }

        /// <summary>
        /// Geeft de richting van <paramref name="spot"/> naar <paramref name="target"/> terug.
        /// </summary>
        /// <param name="spot"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Direction GetDirectionTo(ISpot spot, Position target)
        {
            Direction result = 0;
            var divx = target.X - spot.Position.X;
            var divy = target.Y - spot.Position.Y;
            if (divx > 0)
            {
                result |= Direction.Right;
            }
            else if (divx < 0)
            {
                result |= Direction.Left;
            }

            if (divy > 0)
            {
                result |= Direction.Down;
            }
            else if (divy < 0)
            {
                result |= Direction.Up;
            }

            return result;
        }
    }
}
