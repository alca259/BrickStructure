using BrickStructure.Data.Agents;
using BrickStructure.Data.Repositories;
using Microsoft.Extensions.Logging;

namespace BrickStructure.Client.DataLayer.Agents
{
    public class WeatherExtendedAgent : DefaultAgent<WeatherExtendedEntity>
    {
        public WeatherExtendedAgent(ILogger<WeatherExtendedAgent> logger, ApplicationRepository context) : base(logger, context)
        {
        }
    }
}
