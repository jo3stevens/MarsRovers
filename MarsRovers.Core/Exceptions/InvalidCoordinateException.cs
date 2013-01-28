using System;

namespace MarsRovers.Core.Exceptions
{
    /// <summary>
    /// Exception thrown when the given Coordinates are not in a valid format
    /// </summary>
    public class InvalidCoordinateException : ApplicationException
    {
        public InvalidCoordinateException(string message) : base(message) { }
    }
}
