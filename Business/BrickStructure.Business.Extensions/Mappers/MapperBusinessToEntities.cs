using BrickStructure.Business.Models;
using BrickStructure.Data.Entities;

namespace BrickStructure.Business.Extensions.Mappers
{
    public class MapperBusinessToEntities : AutoMapper.Profile
    {
        public MapperBusinessToEntities()
        {
            AllowNullDestinationValues = true;
            AllowNullCollections = true;

            CreateMap<WeatherModel, WeatherEntity>();
        }
    }
}
