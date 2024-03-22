using IOTWebAPI.Data;
using IOTWebAPI.Entities;
using IOTWebAPI.Repositories.Interfaces;

namespace IOTWebAPI.Repositories.Implementations;

public class GatewayRepository : IGatewayRepository //GatewayRepository herda os m�todos da interface IGatewayRepository
{
    private readonly DataContext _dataContext;
    //declara��o de uma vari�vel privada para armazenar uma inst�ncia do DataContext

    public GatewayRepository(DataContext dataContext) 
    {
        _dataContext = dataContext;
    }
    //construtor que recebe uma inst�ncia da classe DataContext e armazena na vari�vel _dataContext


    public List<Gateway> GetGateways()
    {
        return _dataContext.Gateways.ToList();
    }
    //implementa��o do m�todo GetGateways da interface IGatewayRepository
    //retorna uma lista de todos os gateways presentes no DataContext
    //ToList transforma uma sequ�ncia de elementos em uma lista


    public Gateway? GetGateway(int gatewayId)
    {
        return _dataContext.Gateways.FirstOrDefault(g => g.GatewayID == gatewayId);
    }
    //implementa��o do m�todo GetGateway da interface IGatewayRepository
    //retorna um gateway g cujo o GatewayID seja igual ao gatewayId se ele satisfazer a condi��o
    //caso contrario retorna null


    public bool GatewayExists(int gatewayId)
    {
        return _dataContext.Gateways.Any(g => g.GatewayID == gatewayId);
    }
    //implementa��o do m�todo GatewayExists da interface IGatewayRepository
    //p/ qualquer gateway g cujo GatewayID seja igual gatewayId, se satisfazer a condi�ao
    //retorna true se existir ou false se n�o existir nenhum gateway com esse id

    public bool CreateGateway(Gateway gateway)
    {
        _dataContext.Add(gateway);
        return Save();
    }
    //implementa��o do m�todo CreateGateway da interface IGatewayRepository
    //adiciona um novo gateway no DataContext e salva as altera��es
    //retorna true se deu certo e false se deu errado


    public bool UpdateGateway(Gateway gateway)
    {
        _dataContext.Update(gateway);
        return Save();
    }
    //implementa��o do m�todo UpdateGateway da interface IGatewayRepository
    //atualiza um gateway existente no DataContext e salva as altera��es
    //retorna true se der certo ou false se der errado

    public bool DeleteGateway(Gateway gateway)
    {
        _dataContext.Remove(gateway);
        return Save();
    }
    //implementa��o do m�todo DeleteGateway da interface IGatewayRepository
    //exclui um gateway existente no DataContext e salva as altera��es
    //retorna true se der certo ou false se der errado

    public bool Save()
    {
        return _dataContext.SaveChanges() > 0;
    }
    //implementa��o do m�todo Save da interface IGatewayRepository
    //salva todas as altera��es feitas no DataContext
    //retorna verdadeiro se pelo menos uma altera��o for salva com sucesso
}