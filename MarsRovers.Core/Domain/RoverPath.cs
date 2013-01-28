using System;
using MarsRovers.Core.Exceptions;

namespace MarsRovers.Core.Domain
{
    /// <summary>
    /// Defines the start location and path for a Rover
    /// </summary>
    public struct RoverPath
    {
        /// <summary>
        /// Creates a RoverPath from string location and path representations
        /// </summary>
        /// <param name="startLocation">Start position and direction as a string</param>
        /// <param name="path">The path for the Rover to take as a string</param>
        public RoverPath(string startLocation, string path) : this()
        {
            var location = startLocation.Split(new[] { ' ' });
            if (!location.Length.Equals(3))
            {
                throw new InvalidCoordinateException("Unexpected input format.");
            }

            int x, y;

            if (!int.TryParse(location[0], out x) || !int.TryParse(location[1], out y))
            {
                throw new InvalidCoordinateException("Invalid Coordinate format.");
            }

            StartCoordinate = new Coordinate(x, y);
            StartDirection = (Direction) Enum.Parse(typeof (Direction), location[2]);
            Path = path;
        }

        /// <summary>
        /// Creates a new RoverPath
        /// </summary>
        /// <param name="startCoordinate">The Coordinate to start the Rover at</param>
        /// <param name="startDirection">The Direction the rover should be racing</param>
        /// <param name="path">A string representation of the movement path</param>
        public RoverPath(Coordinate startCoordinate, Direction startDirection, string path) : this()
        {
            StartCoordinate = startCoordinate;
            StartDirection = startDirection;
            Path = path;
        }

        public Coordinate StartCoordinate { get; set; }
        public Direction StartDirection { get; set; }
        public string Path { get; set; }
    }
}
