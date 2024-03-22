using AutoMapper;
using IOTWebAPI.DTOs;
using IOTWebAPI.Entities;
using IOTWebAPI.Repositories.Interfaces;
using IOTWebAPI.Services.Interfaces;

namespace IOTWebAPI.Services.Implementations;

public class ConfigurationService : IConfigurationService
{
    private readonly IMapper _mapper;
    private readonly IConfigurationRepository _configurationRepository;

    public ConfigurationService(IConfigurationRepository configurationRepository, IMapper mapper)
    {
        _mapper = mapper;
        _configurationRepository = configurationRepository;
    }
    public List<ConfigurationDto> GetConfigurations()
    {
        return _mapper.Map<List<ConfigurationDto>>(_configurationRepository.GetConfigurations()); 
    }

    public ConfigurationDto? GetConfiguration(int configurationId) 
    {
        if (_configurationRepository.ConfigurationExists(configurationId))
            return _mapper.Map<ConfigurationDto>(_configurationRepository.GetConfiguration(configurationId));
        return null;
    }
    public bool CreateConfiguration(CreateConfigurationDto createConfigurationDto)
    {
        var configuration = _mapper.Map<Configuration>(createConfigurationDto);
        return _configurationRepository.CreateConfiguration(configuration);
    }

    public bool UpdateConfiguration(UpdateConfigurationDto updateConfigurationDto, int configurationId)
    {
        var existingConfiguration = _configurationRepository.GetConfiguration(configurationId);
        if (existingConfiguration == null)
            return false;

        _mapper.Map(updateConfigurationDto, existingConfiguration);

        return _configurationRepository.UpdateConfiguration(existingConfiguration);
    }

    public bool DeleteConfiguration(int configurationId)
    {
        var configuration = _configurationRepository.GetConfiguration(configurationId);
        if (configuration == null)
            return false;

        return _configurationRepository.DeleteConfiguration(configuration);
    }
}

