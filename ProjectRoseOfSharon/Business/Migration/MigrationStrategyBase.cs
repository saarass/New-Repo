namespace ProjectRoseOfSharon.Business.Migration
{
    /**
         * Om onderstaande functies te kunnen impementeren is de volgende informatie handig:
         * 
         * We hebben te maken met een terrein waarop zich koeien, schapen, geiten, herders, bomen, etc kunnen 
         * bevinden. Om bij te houden waar alles zich bevindt, is het terrein onderverdeeld in 'spots', waarbij elke spot
         * maximaal 1 koe, schaap, geit of herder kan bevatten. Staat er niets op, dan is de spot 'free'. Een spot heeft dus een 
         * bepaalde positie op het terrein, aangegeven door x en y coordinaten.
         * 
         * Dit terrein bestaat uit 10 bij 10 spots:
         * ╔═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╗
         * ║   ║   ║   ║   ║   ║   ║   ║   ║   ║   ║
         * ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣
         * ║   ║   ║   ║   ║   ║   ║   ║   ║   ║   ║
         * ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣
         * ║   ║   ║   ║   ║   ║   ║   ║   ║   ║   ║
         * ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣
         * ║   ║   ║   ║   ║   ║   ║   ║   ║   ║   ║
         * ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣
         * ║   ║   ║   ║   ║   ║   ║   ║   ║   ║   ║
         * ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣
         * ║   ║   ║   ║   ║   ║   ║ x ║   ║   ║   ║
         * ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣
         * ║   ║   ║   ║   ║   ║   ║   ║   ║   ║   ║
         * ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣
         * ║   ║   ║   ║   ║   ║   ║   ║   ║   ║   ║
         * ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣
         * ║   ║   ║   ║   ║   ║   ║   ║   ║   ║   ║
         * ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣
         * ║   ║   ║   ║   ║   ║   ║   ║   ║   ║   ║
         * ╚═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╝
         *
         * De spot linksbovenin bevindt zich op positie (0, 0). De spot met de 'x' erin bevind zich op positie (6, 5). 
         * Dus x = 6, y = 5. Dus eerst tel je naar rechts, dan naar onderen.
         * 
         * Een spot heeft verscheidene properties en methods, maar de volgende zijn nu van belang:
         *  - GetRelativeSpot(Direction dir)    geeft de spot in de gegeven richting van de huidige spot terug
         *  - IsFree()                          geeft true als er niets op de spot staat
         *  - Position                          de positie van de spot
         *  
         * Een positie heeft ook meerdere properties en methods, maar de volgende zijn nu van belang:
         *  - X                                 De x-coordinaat van de positie
         *  - Y                                 De y-coordinaat van de positie
         */

    /// <summary>
    /// Dit is de basis voor Migratie Strategieën, waarin allerlei handige functies zijn opgenomen 
    /// voor specifieke strategieën. Een herder volgt een bepaalde <see cref="IMigrationStrategy"/>, en volgt daarbij
    /// dus de richting die door die strategie wordt aangegeven (via de method GetDirection()).
    /// </summary>
    public abstract class MigrationStrategyBase : IMigrationStrategy
    {
        public MigrationStrategyBase()
        {
            
        }

        /// <summary>
        /// Geeft het aantal opeenvolgende vrije spots van de huidige <paramref name="spot"/> 
        /// in de gegeven richting (<paramref name="dir"/>), tot maximaal <paramref name="maxCount"/> spots.
        /// </summary>
        /// <param name="spot">de spot</param>
        /// <param name="dir"></param>
        /// <param name="maxCount"></param>
        /// <returns></returns>
        protected int GetMaxFreeSpots(ISpot spot, Direction dir, int maxCount)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Geeft, met de klok mee, de volgende richting na <paramref name="dir"/>. 
        /// <code>
        /// ⬉🠕⬈
        /// 🠔 ➝
        /// ⬋🠗⬊
        /// </code>
        /// </summary>
        /// <param name="dir">de huidige direction waarvan de volgende met de klok mee wordt opgevraagd</param>
        /// <returns>De volgende direction met de klok mee</returns>
        /// <exception cref="InvalidOperationException">Als er een <paramref name="dir"/> gegeven is die nergens op slaat</exception>
        /// <remarks>
        /// Om een diagonale richting terug te geven gebruik je de bitwise "or" operator: |
        /// <code>
        /// Direction upRight = Direction.Up | Direction.Right
        /// </code>
        /// </remarks>
        protected Direction GetNextDirectionClockwise(Direction dir)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Geef true terug als de spot in de gegeven <paramref name="direction"/> 
        /// vanuit de gegeven <paramref name="spot"/> beschikbaar (free) is. 
        /// </summary>
        /// <param name="spot">de spot waarvanuit naar de andere wordt gekeken</param>
        /// <param name="direction">de richting waarop wordt gekeken vanuit de gegeven spot</param>
        /// <returns>true als de betreffende spot beschikbaar is (free)</returns>
        protected bool IsFree(ISpot spot, Direction direction)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Geeft true als spots <paramref name="a"/> en <paramref name="b"/> buren zijn, 
        /// met andere woorden als de twee in een van de 8 richtingen maar 1 spot verschillen.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        protected bool AreNeighbours(ISpot a, ISpot b)
        {
            throw new NotImplementedException();
        }

        // deze geen body/implementatie geven, want dit is een abstract method. Daar leer je meer over in de komende weken.
        public abstract Direction? GetDirection(ISpot spot, Direction dir);
    }
}
