using AutoMapper;
using IOTWebAPI.DTOs;
using IOTWebAPI.Entities;

namespace IOTWebAPI.Helpers;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig() //esta transferindo dados de um objeto fonte para outro destino
    {
        CreateMap<Gateway, GatewayDto>();
        CreateMap<CreateGatewayDto, Gateway>();
        CreateMap<UpdateGatewayDto, Gateway>();
        CreateMap<Configuration, ConfigurationDto>();
        CreateMap<CreateConfigurationDto, ConfigurationDto>();
        CreateMap<UpdateConfigurationDto, ConfigurationDto>();
    }
}