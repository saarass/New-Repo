using ProjectRoseOfSharon.Business.Migration;

namespace ProjectRoseOfSharon.Business
{
    /// <summary>
    /// Een herder van een groep. 
    /// </summary>
    public interface IShepherd : IBiological
    {
        /// <summary>
        /// De groep die deze herder hoedt.
        /// </summary>
        IGroup Group { get; }

        /// <summary>
        /// De huidige richting waar de herder heengaat.
        /// </summary>
        Direction Direction { get; }

        /// <summary>
        /// De strategie die de herder toepast om zijn/haar route te bepalen.
        /// </summary>
        IMigrationStrategy MigrationStrategy { get; set; }
    }
}