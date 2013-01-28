using System;
using MarsRovers.Core.Domain;
using MarsRovers.Core.Exceptions;
using MarsRovers.Utilities;

namespace MarsRovers
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Ensure there is command line arguement (filename containing paths)
                if (!args.Length.Equals(1))
                {
                    throw new ApplicationException("Expecting one command line parameter.");
                }

                //Load the data from file specified in the command line argument
                var inputFile = InputFileHelper.LoadInputFile(args[0]);

                //Create the Plateau
                var plateau = new Plateau(inputFile.MaxCoordinate);

                //Loop through the paths for each rover
                foreach (var roverPath in inputFile.RoverPaths)
                {
                    try
                    {
                        //Create the Rover
                        var rover = new Rover(plateau, roverPath.StartCoordinate, roverPath.StartDirection);
                        //Set the Rover on it's path
                        rover.SetPath(roverPath.Path);
                        //Output the final location on the plateau
                        Console.WriteLine(rover.ToString());
                    }
                    catch (CoordinatesOutOfBoundsException ex)
                    {
                        Console.WriteLine(string.Concat("A CoordinatesOutOfBoundsException has occurred: ", ex.Message));
                    }
                    catch (InvalidCoordinateException ex)
                    {
                        Console.WriteLine(string.Concat("A InvalidCoordinateException has occurred: ", ex.Message));
                    }
                    catch (InvalidPathException ex)
                    {
                        Console.WriteLine(string.Concat("A InvalidPathException has occurred: ", ex.Message));
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Press enter to end.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Concat("An unexpected error has occurred: ", ex.Message));
                Console.WriteLine("Press enter to end.");
                Console.ReadLine();
            }
        }
    }
}
