using IOTWebAPI.DTOs;
using IOTWebAPI.Helpers;
namespace IOTWebAPI.Services.Interfaces;

public interface IGatewayService
{
    List<GatewayDto> GetGateways(); //O m�todo retorna uma lista de gatewayDto
    GatewayDto? GetGateway(int gatewayId); //O m�todo retorna gateway se ele existir 
    bool CreateGateway(CreateGatewayDto createGatewayDto); //O m�todo tenta criar um gateway e retorna true se der certo e false se n�o
    bool UpdateGateway(UpdateGatewayDto updateGatewayDto, int gatewayId); //O m�todo tenta atualizar um gateway com base no id e se der certo retorna true ou false se nao der
    bool DeleteGateway(int gatewayId); //O m�todo tenta deletar um gateway, se der certo retorna true e se der errado retorna false
}