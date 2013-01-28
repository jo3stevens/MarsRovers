using System;
using MarsRovers.Core.Exceptions;

namespace MarsRovers.Core.Domain
{
    /// <summary>
    /// Represents a Mars Rover
    /// </summary>
    public class Rover
    {
        /// <summary>
        /// Sets up the Rover and ensures the starting Coordinate is available on the Plateau
        /// </summary>
        /// <param name="plateau">The Plateau for the Rover to move around</param>
        /// <param name="coordinate">The starting Coordinate for the Rover</param>
        /// <param name="direction">The initial Direction the Rover is facing</param>
        public Rover(Plateau plateau, Coordinate coordinate, Direction direction)
        {
            Plateau = plateau;
            Direction = direction;

            if (!Plateau.Coordinates.Contains(coordinate))
            {
                throw new CoordinatesOutOfBoundsException(coordinate.X, coordinate.Y);
                
            }

            Coordinate = coordinate;
        }

        public Coordinate Coordinate { get; set; }
        public Direction Direction { get; set; }
        public Plateau Plateau { get; set; }

        /// <summary>
        /// Turn the Rover 90 degrees to the left
        /// </summary>
        private void Left()
        {
            Direction = Direction.Equals(Direction.N) ? Direction.W :  Direction = (Direction)(Convert.ToInt32(Direction) / 2);
        }
        
        /// <summary>
        /// Turn the Rover 90 degrees to the right
        /// </summary>
        private void Right()
        {
            Direction = Direction.Equals(Direction.W) ? Direction = Direction.N : (Direction)(Convert.ToInt32(Direction) * 2);
        }
        
        /// <summary>
        /// Attempts to move the Rover in the direction it is facing
        /// </summary>
        private void Move()
        {
            Coordinate newCoordinate;
            
            if (!CanMove(out newCoordinate))
            {
                throw new CoordinatesOutOfBoundsException(newCoordinate.X, newCoordinate.Y);
                
            }

            Coordinate = newCoordinate;
        }

        /// <summary>
        /// Move the Rover on the provided path. A path can be set as a string containing the letters L, R, M
        /// </summary>
        /// <param name="path">The movement path for the Rover</param>
        public void SetPath(string path)
        {
            foreach (var c in path.ToLower())
            {
                switch (c)
                {
                    case 'l':
                        Left();
                        break;

                    case 'r':
                        Right();
                        break;

                    case 'm':
                        Move();
                        break;

                    default:
                        throw new InvalidPathException();
                }
            }
        }

        /// <summary>
        /// Determines if the Rover can move on the current Plateau
        /// </summary>
        /// <param name="newCoordinate">Out parameter for new Coordinate</param>
        /// <returns>Whether the Rover can move on the current Plateau</returns>
        private bool CanMove(out Coordinate newCoordinate)
        {
            newCoordinate = new Coordinate();

            switch (Direction)
            {
                case Direction.N:
                    newCoordinate = new Coordinate(Coordinate.X, Coordinate.Y + 1);
                    break;

                case Direction.E:
                    newCoordinate = new Coordinate(Coordinate.X + 1, Coordinate.Y);
                    break;

                case Direction.S:
                    newCoordinate = new Coordinate(Coordinate.X, Coordinate.Y - 1);
                    break;

                case Direction.W:
                    newCoordinate = new Coordinate(Coordinate.X - 1, Coordinate.Y);
                    break;
            }

            return Plateau.Coordinates.Contains(newCoordinate);
        }

        /// <summary>
        /// Creates a string that show the Coordinates and Direcotion of the Rover
        /// </summary>
        /// <returns>The Coordinates and Direction of the Rover</returns>
        public override string ToString()
        {
            return string.Concat(Coordinate.ToString(), " ", Direction.ToString());
        }
    }
}
