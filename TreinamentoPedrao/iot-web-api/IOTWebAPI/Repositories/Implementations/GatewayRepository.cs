using IOTWebAPI.Data;
using IOTWebAPI.Entities;
using IOTWebAPI.Repositories.Interfaces;

namespace IOTWebAPI.Repositories.Implementations;

public class GatewayRepository : IGatewayRepository //GatewayRepository herda os métodos da interface IGatewayRepository
{
    private readonly DataContext _dataContext;
    //declaração de uma variável privada para armazenar uma instância do DataContext

    public GatewayRepository(DataContext dataContext) 
    {
        _dataContext = dataContext;
    }
    //construtor que recebe uma instância da classe DataContext e armazena na variável _dataContext


    public List<Gateway> GetGateways()
    {
        return _dataContext.Gateways.ToList();
    }
    //implementação do método GetGateways da interface IGatewayRepository
    //retorna uma lista de todos os gateways presentes no DataContext
    //ToList transforma uma sequência de elementos em uma lista


    public Gateway? GetGateway(int gatewayId)
    {
        return _dataContext.Gateways.FirstOrDefault(g => g.GatewayID == gatewayId);
    }
    //implementação do método GetGateway da interface IGatewayRepository
    //retorna um gateway g cujo o GatewayID seja igual ao gatewayId se ele satisfazer a condição
    //caso contrario retorna null


    public bool GatewayExists(int gatewayId)
    {
        return _dataContext.Gateways.Any(g => g.GatewayID == gatewayId);
    }
    //implementação do método GatewayExists da interface IGatewayRepository
    //p/ qualquer gateway g cujo GatewayID seja igual gatewayId, se satisfazer a condiçao
    //retorna true se existir ou false se não existir nenhum gateway com esse id

    public bool CreateGateway(Gateway gateway)
    {
        _dataContext.Add(gateway);
        return Save();
    }
    //implementação do método CreateGateway da interface IGatewayRepository
    //adiciona um novo gateway no DataContext e salva as alterações
    //retorna true se deu certo e false se deu errado


    public bool UpdateGateway(Gateway gateway)
    {
        _dataContext.Update(gateway);
        return Save();
    }
    //implementação do método UpdateGateway da interface IGatewayRepository
    //atualiza um gateway existente no DataContext e salva as alterações
    //retorna true se der certo ou false se der errado

    public bool DeleteGateway(Gateway gateway)
    {
        _dataContext.Remove(gateway);
        return Save();
    }
    //implementação do método DeleteGateway da interface IGatewayRepository
    //exclui um gateway existente no DataContext e salva as alterações
    //retorna true se der certo ou false se der errado

    public bool Save()
    {
        return _dataContext.SaveChanges() > 0;
    }
    //implementação do método Save da interface IGatewayRepository
    //salva todas as alterações feitas no DataContext
    //retorna verdadeiro se pelo menos uma alteração for salva com sucesso
}