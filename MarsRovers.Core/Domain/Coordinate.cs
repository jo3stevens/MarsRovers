using MarsRovers.Core.Exceptions;

namespace MarsRovers.Core.Domain
{
    /// <summary>
    /// Represents a location on the Plateau
    /// </summary>
    public struct Coordinate
    {
        /// <summary>
        /// Creates a Coordinate from a string representation of X and Y
        /// </summary>
        /// <param name="coordinate">X and Y as a string separated by a space</param>
        public Coordinate(string coordinate) : this()
        {
            var values = coordinate.Split(new[] { ' ' });

            if (!values.Length.Equals(2))
            {
                throw new InvalidCoordinateException("Unexpected input format.");
            }

            int x, y;

            if (!int.TryParse(values[0], out x) || !int.TryParse(values[1], out y))
            {
                throw new InvalidCoordinateException("Invalid Coordinate format.");
            }

            X = x;
            Y = y;
        }

        /// <summary>
        /// Creates a Coordinate from X and Y position
        /// </summary>
        /// <param name="x">Horizonal positioning</param>
        /// <param name="y">Vertical positioning</param>
        public Coordinate(int x, int y) : this()
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// Returns X and Y as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Concat(X, " ", Y);
        }
    }
}
