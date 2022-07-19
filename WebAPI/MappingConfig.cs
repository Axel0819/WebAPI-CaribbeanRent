﻿using AutoMapper;
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
                config.CreateMap<Contact, ContactDTO>();
                config.CreateMap<ContactDTO, Contact>();

                //UserCr
                config.CreateMap<UserCr, UserCrDTO>();
                config.CreateMap<UserCrDTO, UserCr>();

                //Service
                config.CreateMap<Service, ServiceDTO>();
                config.CreateMap<ServiceDTO, Service>();
            });

            return mappingConfig;
        }
    }
}
