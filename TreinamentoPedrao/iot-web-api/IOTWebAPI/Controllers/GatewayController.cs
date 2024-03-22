using IOTWebAPI.DTOs;
using IOTWebAPI.Entities;
using IOTWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;

namespace IOTWebAPI.Controllers;
[Route("api/[controller]")] 
//define a rota para todas as a��es da controller
//[controller] vai ser substituido pelo nome da controller, que no caso � [gateway]
[ApiController] 
//define que todas as respostas ser�o formatadas automaticamente em .json
public class GatewayController : Controller
{
    private readonly IGatewayService _gatewayService; 
    //declara��o de uma vari�vel privada para armazenar uma instancia de IGatewayService

    public GatewayController(IGatewayService gatewayService) 
    //construtor da classe GatewayController que recebe uma instancia de IGatewayService via inje��o de depend�ncia e atribui � _gatewayService
    {
        _gatewayService = gatewayService;
    }

    [HttpGet] 
    //Atributo que indica que o m�todo abaixo responde a solicita��es HTTP GET.
    [ProducesResponseType(200, Type = typeof(ICollection<GatewayDto>))] 
    //Define o tipo de resposta esperado do m�todo, neste caso, uma cole��o de objetos GatewayDto com um c�digo de status HTTP 200 (OK).
    public IActionResult GetGateways()
    //m�todo que ser� chamado ao acessar /api/Gateway via HTTPGET
    //chama o m�todo GetGateways do servi�o _gatewayService e retorna uma resposta HTTP 200 (OK) com a lista de gateways.
    {
        var gateways = _gatewayService.GetGateways();

        if (!ModelState.IsValid) //verifica se houve erro de valida��o do modelo 
            return BadRequest(ModelState);
        
        return Ok(gateways);
    }
    [HttpGet]
    [Route("{gatewayId:int}")]
    //especifica uma rota para o m�todo GetGateway
    //onde {gatewayId:int} � um segmento de rota que espera um valor inteiro para o par�metro gatewayId.
    [ProducesResponseType(200, Type = typeof(GatewayDto))]
    public IActionResult GetGateway(int gatewayId) //m�todo que retorna uma resposta HTTP pelo id de um gateway espec�fico e seus detalhes
    {
        var gateway = _gatewayService.GetGateway(gatewayId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(gateway);
    }
    
    [HttpPost]
    //Atributo que indica que o m�todo abaixo responde a solicita��es HTTP POST
    [ProducesResponseType(204)] //espera-se No Content
    [ProducesResponseType(400)] //espera-se bad request
    public IActionResult CreateGateway([FromBody] CreateGatewayDto createGatewayDto)
    //Ele cria um novo gateway usando os dados fornecidos no corpo da solicita��o
    //retorna uma resposta HTTP 204 (No Content) se for bem-sucedido ou 400 (Bad Request) se houver erros de valida��o.
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        if (_gatewayService.CreateGateway(createGatewayDto))
            return Ok("Successfully created");
        
        ModelState.AddModelError("", "Something went wrong while savin");
        return StatusCode(500, ModelState);
    }

    [HttpPut("{gatewayId}")] //Atributo que indica que o m�todo abaixo responde a solicita��es HTTP PUT com um par�metro {gatewayId} na rota.
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)] //espera-se Not Found
    public IActionResult UpdateGateway(int gatewayId, [FromBody] UpdateGatewayDto updateGatewayDto)
    //O m�todo que ser� chamado ao enviar uma solicita��o HTTP PUT para /api/Gateway/{gatewayId}.
    //Ele atualiza um gateway existente com o ID fornecido usando os dados fornecidos no corpo da solicita��o
    //retorna uma resposta HTTP 204 (No Content) se for bem-sucedido, 400 (Bad Request) se houver erros de valida��o ou 404 (Not Found) se o gateway n�o for encontrado.
    {
        if (!ModelState.IsValid)
            return BadRequest();

        if (_gatewayService.UpdateGateway(updateGatewayDto, gatewayId))
            return Ok("Successfully updated");

        ModelState.AddModelError("", "Something went wrong while updating");
        return StatusCode(500, ModelState);
    }
    [HttpDelete("{gatewayId}")] //Atributo que indica que o m�todo abaixo responde a solicita��es HTTP DELETE com um par�metro {gatewayId} na rota.
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public IActionResult DeleteGateway(int gatewayId)
    //O m�todo que ser� chamado ao enviar uma solicita��o HTTP DELETE para /api/Gateway/{gatewayId}.
    //Ele exclui um gateway existente com o ID fornecido
    //retorna uma resposta HTTP 204 (No Content) se for bem-sucedido, 400 (Bad Request) se houver erros de valida��o ou 404 (Not Found) se o gateway n�o for encontrado.
    {
        if (_gatewayService.DeleteGateway(gatewayId))
            return Ok("Successfully deleted");
        
        ModelState.AddModelError("", "Something went wrong while deleting");
        return StatusCode(500, ModelState);
    }
}
