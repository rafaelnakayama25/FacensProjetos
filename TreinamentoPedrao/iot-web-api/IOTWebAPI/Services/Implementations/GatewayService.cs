using AutoMapper;
using IOTWebAPI.DTOs;
using IOTWebAPI.Entities;
using IOTWebAPI.Repositories.Interfaces;
using IOTWebAPI.Services.Interfaces;

namespace IOTWebAPI.Services.Implementations;

public class GatewayService : IGatewayService
{   
    private readonly IMapper _mapper; //declara��o de uma variavel privada para armazenar uma instancia IMapper
    private readonly IGatewayRepository _gatewayRepository; //declara��o de uma variavel privada para armazenar uma instancia IGatewayRepository

    public GatewayService(IGatewayRepository gatewayRepository, IMapper mapper) 
    {
        _mapper = mapper;
        _gatewayRepository = gatewayRepository;
    }
    //construtor que recebe uma instancia da classe IGatewayRepository e armazena em _gatewayRepository
    //e outra instancia da classe IMapper e armazena em _mapper 
    public List<GatewayDto> GetGateways()
    {
        return _mapper.Map<List<GatewayDto>>(_gatewayRepository.GetGateways());
    }
    //m�todo que acessa a interface IGatewayRepository e retorna uma lista de gatewaysDto
    //Map serve para converter os objetos Gateways em GatewaysDto
    public GatewayDto? GetGateway(int gatewayId)
    {
        if (_gatewayRepository.GatewayExists(gatewayId))
            return _mapper.Map<GatewayDto>(_gatewayRepository.GetGateway(gatewayId));
        return null;
    }   
    //m�todo que verifica e retorna se o gatewayDto convertido pelo map existe
    //se existir, retorna o gatewayDto, se n�o, retorna null
    public bool CreateGateway(CreateGatewayDto createGatewayDto)
    {
        var gateway = _mapper.Map<Gateway>(createGatewayDto);
        return _gatewayRepository.CreateGateway(gateway);
    }
    //m�todo que tenta criar um gatewayDto convertido pelo map e retorna se deu certo com true ou false

    public bool UpdateGateway(UpdateGatewayDto updateGatewayDto, int gatewayId)
    {   
        var existingGateway = _gatewayRepository.GetGateway(gatewayId);
        if (existingGateway == null)
            return false;
        
        _mapper.Map(updateGatewayDto, existingGateway);
        
        return _gatewayRepository.UpdateGateway(existingGateway);
    }
    //m�todo que verifica se o gateway existe (true) ou n�o (false) e tenta realizar uma atualiza��o
    //o map � utilizado para mapear os dados do updateGateway para o existingGateway
    public bool DeleteGateway(int gatewayId)
    {
        var gateway = _gatewayRepository.GetGateway(gatewayId);
        if (gateway == null)
            return false;
        
        return _gatewayRepository.DeleteGateway(gateway);
    }
    //m�todo de deletar um gateway (n�o precisa ser convertido pelo mapper pois vai ser deletado)
    //retorna vdd ou falso 
}