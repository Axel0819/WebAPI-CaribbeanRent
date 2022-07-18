using AutoMapper;
using WebAPI.Models.DTO;
using WebAPI.Models;

namespace WebAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                // RommiePost
                config.CreateMap<RoomiePostDTO, RoomiePost>();
                config.CreateMap<RoomiePost, RoomiePostDTO>();


                //RoomiePostService
                config.CreateMap<RoomiePostService, RoomiePostServiceDTO>();
                config.CreateMap<RoomiePostServiceDTO, RoomiePostService>();

                // InfoUser
                config.CreateMap<InfoUser, InfoUserDTO>();
                config.CreateMap<InfoUserDTO, InfoUser>();

                //Contact
            });

            return mappingConfig;
        }
    }
}
