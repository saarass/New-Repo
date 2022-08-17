using System.Diagnostics.CodeAnalysis;

namespace ProjectRoseOfSharon.Business
{
    /// <summary>
    /// Een positie op Terrain en wordt aangegeven met een x en y coördinaat. De x waarde bepaald de horizontale positie
    /// en de y waarde de verticale positie.
    /// </summary>
    public struct Position
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Voegt de x en y waarde toe aan deze positie en retourneert het resultaat.
        /// </summary>
        public Position Add(int x, int y)
        {
            return new Position(X + x, Y + y);
        }

        /// <summary>
        /// berekent de afstand tot een ander punt.
        /// </summary>
        /// <param name="point">het andere punt</param>
        /// <returns>de afstand</returns>
        public double DistanceTo(Position pos)
        {
            // since the number of steps for going diagonal is the same as
            // going vertically of horizontally, the distance to any point
            // is the maximum of horizontal or vertical steps.
            return Math.Max(Math.Abs(X - pos.X), Math.Abs(Y - pos.Y));
        }

        /// <summary>
        /// Geeft de positie relatief ten opzichte van deze positie wanneer je je 1 stap in de gegeven richting beweegt.
        /// </summary>
        public Position To(Direction direction)
        {
            int dx = 0, dy = 0;

            if (direction.HasFlag(Direction.Up))
            {
                dy = -1;
            }
            if (direction.HasFlag(Direction.Down))
            {
                dy = 1;
            }
            if (direction.HasFlag(Direction.Left))
            {
                dx = -1;
            }
            if (direction.HasFlag(Direction.Right))
            {
                dx = 1;
            }

            return Add(dx, dy);
        }

        /// <summary>
        /// Fijn voor debuggen, geeft deze positie weer als (x, y) waarde.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        /// <summary>
        /// Vergelijkt posities a met positie b.
        /// </summary>
		public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return obj != null && obj is Position p && p.X == X && p.Y == Y;
        }

        /// <summary>
        /// Nodig om posities bijvoorbeeld in een dictionary te kunnen gebruiken.
        /// </summary>
        public override int GetHashCode()
        {
            // int32 maxvalue = 2147483647
            // 46000 * 46000  < 2147483647
            // dus voor een terrein tot 46000 x 46000 spots krijg je met onderstaande functie unieke waarden:
            return Y * 46000 + X;
        }

		/// <summary>
		/// Hierdoor kan je twee posities met elkaar vergelijken mbv de == operator.
		/// </summary>
		public static bool operator ==(Position a, Position b)
		{
			return a.Equals(b);
		}

        /// <summary>
		/// Hierdoor kan je twee posities met elkaar vergelijken mbv de != operator.
        /// </summary>
		public static bool operator !=(Position a, Position b)
		{
			return !a.Equals(b);
		}
	}
}