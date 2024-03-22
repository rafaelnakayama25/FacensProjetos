using IOTWebAPI.Entities;

namespace IOTWebAPI.Repositories.Interfaces
{
    public interface IConfigurationRepository 
    {
        List<Configuration> GetConfigurations(); //GetConfigurations retorna uma lista de configurações
        Configuration? GetConfiguration(int configurationId); //GetConfiguration retorna uma configuração ou nulo
        bool ConfigurationExists(int configurationId); //Valida se a configuração existe 
        bool CreateConfiguration(Configuration configuration); //Tenta criar uma configuração e retorna se deu certo ou não
        bool UpdateConfiguration(Configuration configuration); //Tenta atualizar uma configuração e retorna se deu certo ou não
        bool DeleteConfiguration(Configuration configurationId); //Tenta deletar uma configuração e retorna se deu certo ou não
        bool Save(); //Tenta salvar todas as alterações pendentes e retorna se deu certo ou não
    }
}
