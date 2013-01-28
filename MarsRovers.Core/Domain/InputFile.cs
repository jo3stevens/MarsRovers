using System.Collections.Generic;

namespace MarsRovers.Core.Domain
{
    /// <summary>
    /// Represents an input file
    /// </summary>
    public class InputFile
    {
        /// <summary>
        /// Creates an InputFile with a filename
        /// </summary>
        /// <param name="filename"></param>
        public InputFile(string filename) : this()
        {
            Filename = filename;
        }

        /// <summary>
        /// Creates an InputFile
        /// </summary>
        public InputFile()
        {
            RoverPaths = new List<RoverPath>();
        }

        public string Filename { get; set; }
        public Coordinate MaxCoordinate { get; set; }
        public List<RoverPath> RoverPaths { get; set; }
    }
}
