using IOTWebAPI.Data;
using IOTWebAPI.Entities;
using IOTWebAPI.Repositories.Interfaces;

namespace IOTWebAPI.Repositories.Implementations;

public class ConfigurationRepository : IConfigurationRepository //classe ConfigurationRepository está implementando todos os métodos da classe abstrata IConfigurationRepository
{
    private readonly DataContext _dataContext;
    //declaração de uma variável privada para armazenar uma instância do contexto do banco de dados

    public ConfigurationRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    //construtor da classe CopnfigurationRepository que recebe uma instância do contexto do banco de dados e armazena na variável _dataContext


    public List<Configuration> GetConfigurations()
    {
        return _dataContext.Configurations.ToList();
    }
    //implementação do método GetConfigurations da interface IConfigurationRepository
    //retorna uma lista de todos os configurations presentes no banco de dados


    public Configuration? GetConfiguration(int configurationId)
    {
        return _dataContext.Configurations.FirstOrDefault(g => g.ConfigurationID == configurationId);
    }
    //implementação do método GetConfiguration(int configurationId) da interface IConfigurationRepository
    //retorna um único configuration com Id especificicado, se existir


    public bool ConfigurationExists(int configurationId)
    {
        return _dataContext.Configurations.Any(g => g.ConfigurationID == configurationId);
    }
    //implementação do método ConfigurationExists(int configurationId) da interface IConfigurationRepository
    //verifica se um configuration com id especificado existe no banco de dados


    public bool CreateConfiguration(Configuration configuration)
    {
        _dataContext.Add(configuration);
        return Save();
    }
    //implementação do método CreateConfiguration da interface IConfigurationRepository
    //adiciona um novo configuration no contexto do banco de dados e salva as alterações


    public bool UpdateConfiguration(Configuration configuration)
    {
        _dataContext.Update(configuration);
        return Save();
    }
    //implementação do método UpdateGateway da interface IConfigurationRepository
    //atualiza um configuration existente no contexto do banco de dados e salva as alterações


    public bool DeleteConfiguration(Configuration configuration)
    {
        _dataContext.Remove(configuration);
        return Save();
    }
    //implementação do método DeleteConfiguration da interface IConfigurationRepository
    //exclui um configuration existente no contexto do banco de dados e salva as alterações


    public bool Save()
    {
        return _dataContext.SaveChanges() > 0;
    }
    //implementação do método Save da interface IConfigurationRepository
    //salva todas as alterações feitas no contexto do banco de dados
    //retorna verdadeiro se pelo menos uma alteração for salva com sucesso
}