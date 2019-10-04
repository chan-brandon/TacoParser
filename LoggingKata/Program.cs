using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;


namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();

            string first = null;
            string second = null;
            double constant;
            double distance = 0d;
            ITrackable locA;
            ITrackable locB;
            Point corA;
            Point corB;
            GeoCoordinate one;
            GeoCoordinate two;

            for (int i = 0; i < locations.Length; i++)
            {
                logger.LogInfo("Finding first location with forloop");
                locA = locations[i];
                corA = locA.Location;
                one = new GeoCoordinate(corA.Latitude, corA.Longitude);

                for (int k = 0; k < locations.Length; k++)
                {
                    logger.LogInfo("Finding second location nested inside first forloop");
                    locB = locations[k];
                    corB = locB.Location;
                    two = new GeoCoordinate(corB.Latitude, corB.Longitude);

                    logger.LogInfo("Finding distance between first and second location with .GetDistanceTo");
                    constant = one.GetDistanceTo(two);

                    if (distance < constant)
                    {
                        logger.LogInfo("Checking distances with IF statement");
                        distance = constant;
                        first = locations[i].Name;
                        second = locations[k].Name;
                    }
                }
            }

            var rounded = Math.Round(distance, 2);

            Console.WriteLine($"The two furthest apart Taco Bells are {first} and {second}. They are a total of {rounded} meters apart.");
        }
    }
}