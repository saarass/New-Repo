using System.Runtime.Serialization;

namespace ProjectRoseOfSharon.Business.Exceptions
{
    /// <summary>
    /// Deze exceptie wordt gegooid als er geen groep geplaatst kan worden op de gevraagde locatie.
    /// </summary>
    [Serializable]
    internal class CannotPlaceGroupException : Exception
    {
        public CannotPlaceGroupException()
        {
        }

        public CannotPlaceGroupException(string? message) : base(message)
        {
        }

        public CannotPlaceGroupException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CannotPlaceGroupException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}