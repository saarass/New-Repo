namespace ProjectRoseOfSharon.Business.Migration
{
    public interface IMigrationStrategy
    {
        /// <summary>
        /// Geeft de volgende richting terug gegeven de <paramref name="spot"/> en huidige richting (<paramref name="dir"/>). 
        /// Geeft 'null' terug als er stil moet worden gestaan.
        /// </summary>
        /// <param name="spot">de huidige plek van hetgeen zich beweegt</param>
        /// <param name="dir">de huidige richting van hetgeen zich beweegt</param>
        /// <returns>de volgende richting waarin hetgeen zich beweegt zich moet gaan bewegen, of 'null' als er stil moet worden gestaan</returns>
        Direction? GetDirection(ISpot spot, Direction dir);

    }
}
