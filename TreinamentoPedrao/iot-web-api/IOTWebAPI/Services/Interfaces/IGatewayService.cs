using IOTWebAPI.DTOs;
using IOTWebAPI.Helpers;
namespace IOTWebAPI.Services.Interfaces;

public interface IGatewayService
{
    List<GatewayDto> GetGateways(); //O método retorna uma lista de gatewayDto
    GatewayDto? GetGateway(int gatewayId); //O método retorna gateway se ele existir 
    bool CreateGateway(CreateGatewayDto createGatewayDto); //O método tenta criar um gateway e retorna true se der certo e false se não
    bool UpdateGateway(UpdateGatewayDto updateGatewayDto, int gatewayId); //O método tenta atualizar um gateway com base no id e se der certo retorna true ou false se nao der
    bool DeleteGateway(int gatewayId); //O método tenta deletar um gateway, se der certo retorna true e se der errado retorna false
}