using System;

namespace MarsRovers.Core.Exceptions
{
    /// <summary>
    /// Exception thrown when the navigation path for a Rover contains invalid characters
    /// </summary>
    public class InvalidPathException : ApplicationException
    {
        public InvalidPathException() : base("The navigation path includes invalid characters.") { }
        public InvalidPathException(string message) : base(message) { }
    }
}
