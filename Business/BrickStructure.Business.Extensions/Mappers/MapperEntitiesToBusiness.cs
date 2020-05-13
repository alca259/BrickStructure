using BrickStructure.Business.Models;
using BrickStructure.Data.Entities;

namespace BrickStructure.Business.Extensions.Mappers
{
    public class MapperEntitiesToBusiness : AutoMapper.Profile
    {
        public MapperEntitiesToBusiness()
        {
            AllowNullDestinationValues = true;
            AllowNullCollections = true;

            CreateMap<WeatherEntity, WeatherModel>();
        }
    }
}
