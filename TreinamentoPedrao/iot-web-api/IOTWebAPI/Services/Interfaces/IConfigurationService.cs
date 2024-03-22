using IOTWebAPI.DTOs;
using IOTWebAPI.Helpers;
namespace IOTWebAPI.Services.Interfaces;

public interface IConfigurationService
{
    List<ConfigurationDto> GetConfigurations();
    ConfigurationDto? GetConfiguration(int configurationId);
    bool CreateConfiguration(CreateConfigurationDto createConfigurationDto);
    bool UpdateConfiguration(UpdateConfigurationDto updateConfigurationDto, int configurationId);
    bool DeleteConfiguration(int configurationId);
}