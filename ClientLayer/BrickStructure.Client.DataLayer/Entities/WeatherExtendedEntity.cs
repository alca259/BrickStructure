using BrickStructure.Data.Entities;

namespace BrickStructure.Client.DataLayer
{
    public class WeatherExtendedEntity
    {
        public int Id { get; set; }
        public string SkyDescription { get; set; }
        public bool IsReal { get; set; }

        public WeatherEntity CoreEntity { get; set; }
    }
}
