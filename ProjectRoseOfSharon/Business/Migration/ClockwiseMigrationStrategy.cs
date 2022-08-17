namespace ProjectRoseOfSharon.Business.Migration
{
    /// <summary>
    /// Met deze strategie beweegt de aanroeper zich 1 keer per 10 iteraties:
    /// <list type="number">
    /// <item>Altijd in dezelfde beweging totdat het niet meer kan</item>
    /// <item>Is dat niet mogelijk, dan wordt met de klok mee de eerstvolgende
    /// vrije richting opgegaan (waarbij op z'n minst 1 stap in die richting gezet kan 
    /// worden), herhaal vanaf 1</item>
    /// </list>
    /// </summary>
    public class ClockwiseMigrationStrategy : MigrationStrategyBase
    {
        public override Direction? GetDirection(ISpot spot, Direction dir)
        {
            throw new NotImplementedException();
        }
    }
}
