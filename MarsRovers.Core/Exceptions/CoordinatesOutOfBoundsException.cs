using System;

namespace MarsRovers.Core.Exceptions
{
    /// <summary>
    /// Exception thrown when an attempt to move a Rover out of the Plateau occurs
    /// </summary>
    public class CoordinatesOutOfBoundsException : ApplicationException
    {
        public CoordinatesOutOfBoundsException(int x, int y) : base(string.Format("Coordinates out of bounds (x:{0}, y:{1}).", x, y)) { }
        public CoordinatesOutOfBoundsException(string message) : base(message) { }
    }
}
