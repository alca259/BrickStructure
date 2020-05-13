using BrickStructure.Business.Models;
using BrickStructure.Data.Contracts;
using BrickStructure.Data.Entities;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace BrickStructure.Business.Managers
{
    public class WeatherManager : DefaultManager<WeatherEntity, WeatherModel, IAgent<WeatherEntity>>
    {
        public WeatherManager(IAgent<WeatherEntity> source, ILogger log, ClaimsPrincipal user) : base(source, log, user)
        {
        }
    }
}
