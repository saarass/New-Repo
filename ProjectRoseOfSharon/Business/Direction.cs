namespace ProjectRoseOfSharon
{
    /// <summary>
    /// Richting dat een biological zich in kan bewegen.
    /// </summary>
    /// <remarks>
    /// Deze enum maakt gebruik van een constructie genaamd 'flags', waardoor je waarden kan combineren.
    /// Zo kan je de waarde <c>myDirection = Direction.Up | Direction.Right</c> hebben, en met 
    /// <c>myDirection.HasFlag(Direction.Up)</c> checken of de richting 'myDirection' onder andere de 
    /// 'Direction.Up' bevat. 
    /// <br/>
    /// <br/>
    /// Let op: de check <c>myDirection == Direction.Up</c> geeft in dit geval 'false' terug.
    /// </remarks>
    public enum Direction
    {
        Up = 1 << 0, 
        Right = 1 << 1, 
        Down = 1 << 2, 
        Left = 1 << 3
    }
}