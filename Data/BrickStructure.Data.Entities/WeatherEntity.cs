using System;

namespace BrickStructure.Data.Entities
{
    public enum EnumWeatherSkyStatus
    {
        Clear = 0,
        PartiallyCloud = 1,
        Cloud = 2,
        Wind = 3,
        Fog = 4,
        Rain = 5,
        Storm = 6,
        ThunderStorm = 7,
        SnowStorm = 8
    }

    public class WeatherEntity
    {
        public int Id { get; set; }
        public string StationCode { get; set; }
        public string Location { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public float Altitude { get; set; }
        public DateTime RegisteredDate { get; set; }
        public float Precipitation { get; set; }
        public float WindSpeed { get; set; }
        public float WindDirection { get; set; }
        public string WindCardinality { get; set; }
        public float Pressure { get; set; }
        public float Humidity { get; set; }
        public float TemperatureFloor { get; set; }
        public float TemperatureAir { get; set; }
        public EnumWeatherSkyStatus SkyStatus { get; set; }
    }
}
