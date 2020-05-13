using BrickStructure.Data.Entities;
using BrickStructure.Data.Repositories;
using Microsoft.Extensions.Logging;

namespace BrickStructure.Data.Agents
{
    public class WeatherAgent : DefaultAgent<WeatherEntity>
    {
        public WeatherAgent(ILogger<WeatherAgent> logger, ApplicationRepository context) : base(logger, context)
        {
        }
    }
}
