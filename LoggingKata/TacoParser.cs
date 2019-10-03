﻿using System;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                logger.LogInfo("array.Length is less than 3");
                return null;
            }

            // grab the latitude from your array at index 0
            // grab the longitude from your array at index 1
            // grab the name from your array at index 2

            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`

            double latitude = double.Parse(cells[0]);
            double longitude = double.Parse(cells[1]);
            var locationName = cells[2];

            Console.WriteLine(latitude);
            Console.WriteLine(longitude);
            Console.WriteLine(locationName);

            // You'll need to create a TacoBell class
            // that conforms to ITrackable

            Point points = new Point();
            points.Latitude = latitude;
            points.Longitude = longitude;

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly

            TacoBell tacoBell = new TacoBell();
            tacoBell.Name = locationName;
            tacoBell.Location = points;

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            return tacoBell;

            // Do not fail if one record parsing fails, return null
            //if ()
            //{
            //    return null;
            //}
        }
    }
}





//TacoBell tacoBell = new TacoBell();
//tacoBell.Name = locationName;
////tacoBell.Location = latitude, longitude;