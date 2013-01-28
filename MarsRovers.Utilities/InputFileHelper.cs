using System.IO;
using MarsRovers.Core.Domain;

namespace MarsRovers.Utilities
{
    /// <summary>
    /// Loads flat file movement data into a managable class
    /// </summary>
    public static class InputFileHelper
    {
        /// <summary>
        /// Load the file provided
        /// </summary>
        /// <param name="filename">The path and name of the file to load</param>
        /// <returns>Instance of InputFile</returns>
        public static InputFile LoadInputFile(string filename)
        {
            InputFile inputFile;

            using (var stream = File.OpenRead(filename))
            {
                inputFile = LoadInputFile(stream);
            }

            inputFile.Filename = filename;

            return inputFile;
        }

        /// <summary>
        /// Load input from a Stream
        /// </summary>
        /// <param name="stream">The stream representing the input file</param>
        /// <returns>Instance of InputFile</returns>
        public static InputFile LoadInputFile(Stream stream)
        {
            var inputFile = new InputFile();

            using (var reader = new StreamReader(stream))
            {
                var maxCoordinateRead = false;

                while (!reader.EndOfStream)
                {
                    if (!maxCoordinateRead)
                    {
                        inputFile.MaxCoordinate = new Coordinate(reader.ReadLine());
                        maxCoordinateRead = true;
                    }

                    inputFile.RoverPaths.Add(new RoverPath(reader.ReadLine(), reader.ReadLine()));
                }
            }

            return inputFile;
        }
    }
}
