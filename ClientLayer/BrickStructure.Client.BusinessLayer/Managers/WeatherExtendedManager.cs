using AutoMapper;
using BrickStructure.Business.Managers;
using BrickStructure.Client.BusinessLayer.Models;
using BrickStructure.Client.DataLayer;
using BrickStructure.Client.DataLayer.Agents;
using Microsoft.Extensions.Logging;

namespace BrickStructure.Client.BusinessLayer.Managers
{
    public class WeatherExtendedManager : DefaultManager<WeatherExtendedEntity, WeatherExtendedModel, WeatherExtendedAgent>
    {
        public WeatherExtendedManager(WeatherExtendedAgent source, ILogger<WeatherExtendedManager> log, IMapper mapper/*, ClaimsPrincipal user*/) : base(source, log, mapper/*, user*/)
        {
        }
    }
}
