namespace ProjectRoseOfSharon.Business.Migration
{
    /// <summary>
    /// Met deze strategie beweegt de aanroeper zich:
    /// <list type="number">
    /// <item>Altijd in dezelfde beweging totdat het niet meer kan</item>
    /// <item>Is dat niet mogelijk, dan wordt in alle 8 richtingen rondom de huidige
    /// spot gekeken waar de meeste ruimte (rechtdoor) beschikbaar is, en beweegt
    /// zich vanaf dan daar naartoe, herhaal vanaf 1</item>
    /// </list>
    /// </summary>
    public class MaxSpotsMigrationStrategy : MigrationStrategyBase
    {
        public override Direction? GetDirection(ISpot spot, Direction dir)
        {
            throw new NotImplementedException();
        }
    }
}
