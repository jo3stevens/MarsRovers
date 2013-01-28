using System;
using System.IO;
using System.Reflection;
using MarsRovers.Core.Domain;
using MarsRovers.Core.Exceptions;
using MarsRovers.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRovers.UnitTests
{
    [TestClass]
    public class MarsRoversTests
    {
        [TestMethod]
        public void ValidPathIsSuccessful()
        {
            //Load the test file from Embedded Resource
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MarsRovers.UnitTests.Resources.Valid.txt");
            var inputFile = InputFileHelper.LoadInputFile(stream);

            TestRovers(inputFile);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCoordinateException), "InvalidCoordinateException expected")]
        public void InvalidMaxCoordiateThrowsInvalidCoordinateException()
        {
            //Load the test file from Embedded Resource
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MarsRovers.UnitTests.Resources.InvalidMaxCoordinate.txt");
            var inputFile = InputFileHelper.LoadInputFile(stream);

            TestRovers(inputFile);
        }

        [TestMethod]
        [ExpectedException(typeof(CoordinatesOutOfBoundsException), "CoordinatesOutOfBoundsException expected")]
        public void StartPositionOffPlateauThrowsCoordinatesOutOfBoundsException()
        {
            //Load the test file from Embedded Resource
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MarsRovers.UnitTests.Resources.InvalidStartPosition.txt");
            var inputFile = InputFileHelper.LoadInputFile(stream);

            TestRovers(inputFile);
        }

        [TestMethod]
        [ExpectedException(typeof(CoordinatesOutOfBoundsException), "CoordinatesOutOfBoundsException expected")]
        public void MovingRoverOffPlateauThrowsCoordinatesOutOfBoundsException()
        {
            //Load the test file from Embedded Resource
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MarsRovers.UnitTests.Resources.InvalidCoordinate.txt");
            var inputFile = InputFileHelper.LoadInputFile(stream);

            TestRovers(inputFile);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPathException), "InvalidPathException expected")]
        public void InvalidPathInputThrowsInvalidPathException()
        {
            //Load the test file from Embedded Resource
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MarsRovers.UnitTests.Resources.InvalidPath.txt");
            var inputFile = InputFileHelper.LoadInputFile(stream);

            TestRovers(inputFile);
        }

        private static void TestRovers(InputFile inputFile)
        {
            //Create the Plateau
            var plateau = new Plateau(inputFile.MaxCoordinate);

            //Create the first rover
            var rover1 = new Rover(plateau, inputFile.RoverPaths[0].StartCoordinate, inputFile.RoverPaths[0].StartDirection);
            //Move the rover
            rover1.SetPath(inputFile.RoverPaths[0].Path);
            //Test against expected result
            Assert.IsTrue(rover1.ToString().Equals("1 3 N"), string.Concat(rover1.ToString(), " should be 1 3 N"));

            //Create the second rover
            var rover2 = new Rover(plateau, inputFile.RoverPaths[1].StartCoordinate, inputFile.RoverPaths[1].StartDirection);
            //Move the rover
            rover2.SetPath(inputFile.RoverPaths[1].Path);
            //Test against expected result
            Assert.IsTrue(rover2.ToString().Equals("5 1 E"), string.Concat(rover2.ToString(), " should be 5 1 E"));
        }
    }
}
