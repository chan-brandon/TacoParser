using System;
using System.Linq;

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

            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                logger.LogInfo("array.Length is less than 3");
                return null;
            }

            if (cells.Any(x => x.Contains("null")))
            {
                logger.LogInfo("array contains a null");
                return null;
            }

            double latitude = double.Parse(cells[0]);
            double longitude = double.Parse(cells[1]);
            var locationName = cells[2];
            logger.LogInfo("assigning latitude and longitude from Parsed cells");

            Point points = new Point();
            points.Latitude = latitude;
            points.Longitude = longitude;
            logger.LogInfo("assigning latitude and longitude to Point instance");

            TacoBell tacoBell = new TacoBell();
            tacoBell.Name = locationName;
            tacoBell.Location = points;
            logger.LogInfo("created new TacoBell instance and assigned values with Point class and TacoBell properties");

            if (latitude != double.Parse(cells[0]) || longitude != double.Parse(cells[1]) || locationName != cells[2])
            {
                logger.LogWarning("value is not the same at one of latitude, longitude, locationName");
            }

            return tacoBell;
        }
    }
}