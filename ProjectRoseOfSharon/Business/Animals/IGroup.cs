using System.Collections;

namespace ProjectRoseOfSharon.Business
{
    public interface IGroup
    {
        /// <summary>
        /// De herder van deze groep.
        /// </summary>
        IShepherd Shepherd { get; }

        /// <summary>
        /// De dieren in deze groep.
        /// </summary>
        IEnumerable Animals { get; }
    }

    public interface IAnimal : IBiological
    {
    }

    public class Group<T> : IGroup
    {
        public IShepherd Shepherd { get; }

        public IEnumerable Animals { get; }
    }

    
}