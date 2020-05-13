using BrickStructure.Client.DataLayer;

namespace BrickStructure.Client.BusinessLayer.Models
{
    public class WeatherExtendedModel : WeatherExtendedEntity
    {
        public string IsRealString => IsReal.ToString();
    }
}
