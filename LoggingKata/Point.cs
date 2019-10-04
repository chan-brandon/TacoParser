namespace LoggingKata
{
    public struct Point
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public Point(double longi, double lati)
        {
            Longitude = longi;
            Latitude = lati;
        }
    }

}