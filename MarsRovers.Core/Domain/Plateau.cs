using System.Collections.Generic;

namespace MarsRovers.Core.Domain
{
    /// <summary>
    /// Respresnts the Plateau that the Mars Rovers move around
    /// </summary>
    public class Plateau
    {
        /// <summary>
        /// Creates a Plateau and initilises the available Coordinates using the X and Y values provided
        /// </summary>
        /// <param name="x">Max horizontal position</param>
        /// <param name="y">Max vertical position</param>
        public Plateau(int x, int y) : this(new Coordinate(x, y)) {}
        
        /// <summary>
        /// Creates a Plateau and initialises the available Coordinates collection using the Max Coordinate
        /// </summary>
        /// <param name="maxCoordinate">Coordinate representing the maximum size of the Plateau</param>
        public Plateau(Coordinate maxCoordinate)
        {
            Coordinates = new List<Coordinate>();

            for (var i = 0; i <= maxCoordinate.X; i++)
            {
                for (var j = 0; j <= maxCoordinate.Y; j++)
                {
                    Coordinates.Add(new Coordinate(i, j));
                }
            }
        }

        public List<Coordinate> Coordinates { get; set; }
    }
}
