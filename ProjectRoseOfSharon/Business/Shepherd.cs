using ProjectRoseOfSharon.Business.Migration;

namespace ProjectRoseOfSharon.Business
{
    /// <summary>
    /// Een herder van een groep. 
    /// </summary>
    /// <typeparam name="T">Het type dier dat deze herder hoedt</typeparam>
    public class Shepherd<T> : BiologicalBase, IShepherd where T : IAnimal
    {
        /// <summary>
        /// De richting waar deze herder momenteel heen gaat.
        /// </summary>
        public Direction Direction { get; private set; }

        /// <summary>
        /// De strategie die bepaalt hoe deze herder zich verplaatst.
        /// </summary>
        public IMigrationStrategy MigrationStrategy { get; set; } = new RandomMigrationStrategy(); // default strategy if none is provided

        /// <summary>
        /// De groep dieren die deze herder hoedt.
        /// </summary>
        public Group<T> Group { get; }

        // Omdat we IShepherd implementeren, moeten we ook de niet-generieke property 'Group' implementeren,
        // maar die retourneert gewoon onze property Group van type Group<T>
        IGroup IShepherd.Group => Group;

        public Shepherd(Group<T> group, ISpot spot) : base(spot)
        {
            Direction = Direction.Down | Direction.Right;
            Group = group;
        }

        /// <summary>
        /// Voert het gedrag voor de volgende iteratie uit (wordt aangeroepen vanuit Terrain).
        /// </summary>
        public override void Update()
        {
            var dir = MigrationStrategy.GetDirection(Spot, Direction);
            if(dir != null)
			{
                Direction = dir.Value;
                Move(Direction);
            }
        }
    }
}
