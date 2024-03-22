using IOTWebAPI.DTOs;
using IOTWebAPI.Entities;
using IOTWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;

namespace IOTWebAPI.Controllers;
[Route("api/[controller]")] 
//define a rota para todas as ações da controller
//[controller] vai ser substituido pelo nome da controller, que no caso é [gateway]
[ApiController] 
//define que todas as respostas serão formatadas automaticamente em .json
public class GatewayController : Controller
{
    private readonly IGatewayService _gatewayService; 
    //declaração de uma variável privada para armazenar uma instancia de IGatewayService

    public GatewayController(IGatewayService gatewayService) 
    //construtor da classe GatewayController que recebe uma instancia de IGatewayService via injeção de dependência e atribui à _gatewayService
    {
        _gatewayService = gatewayService;
    }

    [HttpGet] 
    //Atributo que indica que o método abaixo responde a solicitações HTTP GET.
    [ProducesResponseType(200, Type = typeof(ICollection<GatewayDto>))] 
    //Define o tipo de resposta esperado do método, neste caso, uma coleção de objetos GatewayDto com um código de status HTTP 200 (OK).
    public IActionResult GetGateways()
    //método que será chamado ao acessar /api/Gateway via HTTPGET
    //chama o método GetGateways do serviço _gatewayService e retorna uma resposta HTTP 200 (OK) com a lista de gateways.
    {
        var gateways = _gatewayService.GetGateways();

        if (!ModelState.IsValid) //verifica se houve erro de validação do modelo 
            return BadRequest(ModelState);
        
        return Ok(gateways);
    }
    [HttpGet]
    [Route("{gatewayId:int}")]
    //especifica uma rota para o método GetGateway
    //onde {gatewayId:int} é um segmento de rota que espera um valor inteiro para o parâmetro gatewayId.
    [ProducesResponseType(200, Type = typeof(GatewayDto))]
    public IActionResult GetGateway(int gatewayId) //método que retorna uma resposta HTTP pelo id de um gateway específico e seus detalhes
    {
        var gateway = _gatewayService.GetGateway(gatewayId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(gateway);
    }
    
    [HttpPost]
    //Atributo que indica que o método abaixo responde a solicitações HTTP POST
    [ProducesResponseType(204)] //espera-se No Content
    [ProducesResponseType(400)] //espera-se bad request
    public IActionResult CreateGateway([FromBody] CreateGatewayDto createGatewayDto)
    //Ele cria um novo gateway usando os dados fornecidos no corpo da solicitação
    //retorna uma resposta HTTP 204 (No Content) se for bem-sucedido ou 400 (Bad Request) se houver erros de validação.
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        if (_gatewayService.CreateGateway(createGatewayDto))
            return Ok("Successfully created");
        
        ModelState.AddModelError("", "Something went wrong while savin");
        return StatusCode(500, ModelState);
    }

    [HttpPut("{gatewayId}")] //Atributo que indica que o método abaixo responde a solicitações HTTP PUT com um parâmetro {gatewayId} na rota.
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)] //espera-se Not Found
    public IActionResult UpdateGateway(int gatewayId, [FromBody] UpdateGatewayDto updateGatewayDto)
    //O método que será chamado ao enviar uma solicitação HTTP PUT para /api/Gateway/{gatewayId}.
    //Ele atualiza um gateway existente com o ID fornecido usando os dados fornecidos no corpo da solicitação
    //retorna uma resposta HTTP 204 (No Content) se for bem-sucedido, 400 (Bad Request) se houver erros de validação ou 404 (Not Found) se o gateway não for encontrado.
    {
        if (!ModelState.IsValid)
            return BadRequest();

        if (_gatewayService.UpdateGateway(updateGatewayDto, gatewayId))
            return Ok("Successfully updated");

        ModelState.AddModelError("", "Something went wrong while updating");
        return StatusCode(500, ModelState);
    }
    [HttpDelete("{gatewayId}")] //Atributo que indica que o método abaixo responde a solicitações HTTP DELETE com um parâmetro {gatewayId} na rota.
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public IActionResult DeleteGateway(int gatewayId)
    //O método que será chamado ao enviar uma solicitação HTTP DELETE para /api/Gateway/{gatewayId}.
    //Ele exclui um gateway existente com o ID fornecido
    //retorna uma resposta HTTP 204 (No Content) se for bem-sucedido, 400 (Bad Request) se houver erros de validação ou 404 (Not Found) se o gateway não for encontrado.
    {
        if (_gatewayService.DeleteGateway(gatewayId))
            return Ok("Successfully deleted");
        
        ModelState.AddModelError("", "Something went wrong while deleting");
        return StatusCode(500, ModelState);
    }
}
