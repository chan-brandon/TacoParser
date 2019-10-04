using System;
namespace LoggingKata
{
    public class TacoBell : ITrackable
    {
        public string Name { get; set; }
        public Point Location { get; set; }

        public TacoBell(Point locat, string name)
        {
            if (name == null)
            {
                Name = null;
            }
            Location = locat;
            Name = name;
        }

        public TacoBell()
        {

        }
    }
}
