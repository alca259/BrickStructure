using BrickStructure.Client.BusinessLayer.Models;
using BrickStructure.Client.DataLayer;

namespace BrickStructure.Business.Extensions.Mappers
{
    public class MapperBusinessToEntities : AutoMapper.Profile
    {
        public MapperBusinessToEntities()
        {
            AllowNullDestinationValues = true;
            AllowNullCollections = true;

            CreateMap<WeatherExtendedModel, WeatherExtendedEntity>();
        }
    }
}
