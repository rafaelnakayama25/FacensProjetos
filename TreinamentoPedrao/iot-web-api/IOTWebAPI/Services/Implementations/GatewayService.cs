using AutoMapper;
using IOTWebAPI.DTOs;
using IOTWebAPI.Entities;
using IOTWebAPI.Repositories.Interfaces;
using IOTWebAPI.Services.Interfaces;

namespace IOTWebAPI.Services.Implementations;

public class GatewayService : IGatewayService
{   
    private readonly IMapper _mapper; //declaração de uma variavel privada para armazenar uma instancia IMapper
    private readonly IGatewayRepository _gatewayRepository; //declaração de uma variavel privada para armazenar uma instancia IGatewayRepository

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
    //método que acessa a interface IGatewayRepository e retorna uma lista de gatewaysDto
    //Map serve para converter os objetos Gateways em GatewaysDto
    public GatewayDto? GetGateway(int gatewayId)
    {
        if (_gatewayRepository.GatewayExists(gatewayId))
            return _mapper.Map<GatewayDto>(_gatewayRepository.GetGateway(gatewayId));
        return null;
    }   
    //método que verifica e retorna se o gatewayDto convertido pelo map existe
    //se existir, retorna o gatewayDto, se não, retorna null
    public bool CreateGateway(CreateGatewayDto createGatewayDto)
    {
        var gateway = _mapper.Map<Gateway>(createGatewayDto);
        return _gatewayRepository.CreateGateway(gateway);
    }
    //método que tenta criar um gatewayDto convertido pelo map e retorna se deu certo com true ou false

    public bool UpdateGateway(UpdateGatewayDto updateGatewayDto, int gatewayId)
    {   
        var existingGateway = _gatewayRepository.GetGateway(gatewayId);
        if (existingGateway == null)
            return false;
        
        _mapper.Map(updateGatewayDto, existingGateway);
        
        return _gatewayRepository.UpdateGateway(existingGateway);
    }
    //método que verifica se o gateway existe (true) ou não (false) e tenta realizar uma atualização
    //o map é utilizado para mapear os dados do updateGateway para o existingGateway
    public bool DeleteGateway(int gatewayId)
    {
        var gateway = _gatewayRepository.GetGateway(gatewayId);
        if (gateway == null)
            return false;
        
        return _gatewayRepository.DeleteGateway(gateway);
    }
    //método de deletar um gateway (não precisa ser convertido pelo mapper pois vai ser deletado)
    //retorna vdd ou falso 
}