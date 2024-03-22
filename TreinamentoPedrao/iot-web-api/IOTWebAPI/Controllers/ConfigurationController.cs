using Microsoft.AspNetCore.Mvc;
using IOTWebAPI.DTOs;
using IOTWebAPI.Services.Interfaces;

namespace IOTWebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ConfigurationController : Controller
{
    private readonly IConfigurationService _configurationService;
    public ConfigurationController(IConfigurationService configurationService)
    {
        _configurationService = configurationService;
    }

    [HttpGet] //este método será acionado quando uma solicitação GET for feita para o endpoint correspondente a este método
    [ProducesResponseType(200, Type = typeof(ICollection<ConfigurationDto>))]
    public IActionResult GetConfigurations()
    {
        var configurations = _configurationService.GetConfigurations(); 

        if (!ModelState.IsValid) 
            return BadRequest(ModelState); //modelstate vai dizer se eu enviar um dado errado pra API

        return Ok(configurations);
    }

    //[ProducesResponseType(200, Type = typeof(IEnumerable<Configuration>))]:
    //Este atributo é usado para documentar o tipo de resposta que o método irá retornar.
    //Ele especifica que, se a operação for bem-sucedida (código de status HTTP 200),
    //o corpo da resposta conterá uma coleção de objetos do tipo Configuration.
    //O parâmetro Type é usado para especificar o tipo de objeto retornado.
    //200: Este é o código de status HTTP que indica que a solicitação foi bem-sucedida.
    //Type = typeof(IEnumerable<Configuration>): Isso especifica o tipo de retorno esperado.
    //Neste caso, uma coleção(IEnumerable) de objetos do tipo Configuration.
    //O atributo[ProducesResponseType] é útil para documentar a API,
    //pois fornece informações claras sobre o que esperar como resposta de uma solicitação para este endpoint específico.
    //Isso pode ser especialmente útil para clientes que estão consumindo a API e para ferramentas de documentação automática,
    //como o Swagger, que podem usar essas informações para gerar documentação detalhada da API

    [HttpGet]
    [Route("{configurationId:int}")]
    [ProducesResponseType(200, Type = typeof(ConfigurationDto))]
    public IActionResult GetConfiguration(int configurationId) 
    {
        var configuration = _configurationService.GetConfiguration(configurationId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(configuration);
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateConfiguration([FromBody] CreateConfigurationDto createConfigurationDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (_configurationService.CreateConfiguration(createConfigurationDto))
            return Ok("Successfully created");

        ModelState.AddModelError("", "Something went wrong while savin");
        return StatusCode(500, ModelState);
    }

    [HttpPut("{configurationId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateConfiguration(int configurationId, [FromBody] UpdateConfigurationDto updateConfigurationDto)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        if (_configurationService.UpdateConfiguration(updateConfigurationDto, configurationId))
            return Ok("Successfully updated");

        ModelState.AddModelError("", "Something went wrong while updating");
        return StatusCode(500, ModelState);
    }
    [HttpDelete("{configurationId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public IActionResult DeleteConfiguration(int configurationId)
    {
        if (_configurationService.DeleteConfiguration(configurationId))
            return Ok("Successfully deleted");

        ModelState.AddModelError("", "Something went wrong while deleting");
        return StatusCode(500, ModelState);
    }
}
