using BrickStructure.Client.BusinessLayer.Models;
using BrickStructure.Client.DataLayer;

namespace BrickStructure.Business.Extensions.Mappers
{
    public class MapperEntitiesToBusiness : AutoMapper.Profile
    {
        public MapperEntitiesToBusiness()
        {
            AllowNullDestinationValues = true;
            AllowNullCollections = true;

            CreateMap<WeatherExtendedEntity, WeatherExtendedModel>();
        }
    }
}
