using BrickStructure.Data.Entities;

namespace BrickStructure.Business.Models
{
    public class WeatherModel : WeatherEntity
    {
        public string SkyStatusDescription => SkyStatus.ToString();
    }
}
