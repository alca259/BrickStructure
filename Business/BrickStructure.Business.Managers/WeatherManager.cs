using AutoMapper;
using BrickStructure.Business.Models;
using BrickStructure.Data.Agents;
using BrickStructure.Data.Entities;
using Microsoft.Extensions.Logging;

namespace BrickStructure.Business.Managers
{
    public class WeatherManager : DefaultManager<WeatherEntity, WeatherModel, WeatherAgent>
    {
        public WeatherManager(WeatherAgent source, ILogger<WeatherManager> log, IMapper mapper/*, ClaimsPrincipal user*/) : base(source, log, mapper/*, user*/)
        {
        }
    }
}
