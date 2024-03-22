using IOTWebAPI.Entities;

namespace IOTWebAPI.Repositories.Interfaces;

public interface IGatewayRepository
{
    List<Gateway> GetGateways(); //GetGateways retorna uma lista de objetos Gateway
    Gateway? GetGateway(int gatewayId); //GetGateway retorna um objeto Gateway ou nulo
    bool GatewayExists(int gatewayId); //GatewayExists retorna se o gateway existe ou não
    bool CreateGateway(Gateway gateway); //CreateGateway tenta criar um gateway e retorna se deu certo ou não
    bool UpdateGateway(Gateway gateway); //UpdateGateway tenta atualizar o gateway e retorna se deu certo ou não
    bool DeleteGateway(Gateway gateway); //DeleteGateway tenta excluir um gateway e retorna se deu certo ou não
    bool Save(); //Save tenta salvar todas as alterações pendentes feitas nos gateways e retorna se deu certo ou não.
}