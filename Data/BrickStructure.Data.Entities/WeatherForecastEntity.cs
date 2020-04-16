using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrickStructure.Data.Entities
{
    public class WeatherForecastEntity
    {
        public ulong Id { get; set; }

        public DateTime Date { get; set; }

        public double TemperatureC { get; set; }

        [NotMapped]
        public double TemperatureF => 32 + (TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
