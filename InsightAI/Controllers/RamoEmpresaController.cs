using InsightAI.Core.Entities;
using InsightAI.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InsightAI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamoEmpresaController : ControllerBase
    {
        private readonly IRamoEmpresaService _ramoEmpresaService;

        public RamoEmpresaController(IRamoEmpresaService ramoEmpresaService)
        {
            _ramoEmpresaService = ramoEmpresaService;
        }

        /// <summary>
        /// Obtém um ramo de empresa pelo ID.
        /// </summary>
        /// <param name="id">ID do ramo de empresa</param>
        /// <returns>Detalhes do ramo de empresa</returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um ramo de empresa pelo ID", Description = "Retorna os detalhes de um ramo de empresa com base no ID fornecido.")]
        [ProducesResponseType(typeof(RamoEmpresa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RamoEmpresa>> GetById(int id)
        {
            var ramoEmpresa = await _ramoEmpresaService.GetByIdAsync(id);
            if (ramoEmpresa == null)
            {
                return NotFound();
            }
            return Ok(ramoEmpresa);
        }

        /// <summary>
        /// Lista todos os ramos de empresa.
        /// </summary>
        /// <returns>Lista de ramos de empresa</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os ramos de empresa", Description = "Retorna uma lista de todos os ramos de empresa cadastrados.")]
        [ProducesResponseType(typeof(IReadOnlyList<RamoEmpresa>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<RamoEmpresa>>> ListAll()
        {
            var ramoEmpresas = await _ramoEmpresaService.ListAllAsync();
            return Ok(ramoEmpresas);
        }

        /// <summary>
        /// Adiciona um novo ramo de empresa.
        /// </summary>
        /// <param name="ramoEmpresa">Objeto com os dados do novo ramo de empresa</param>
        /// <returns>Ramo de empresa criado</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona um novo ramo de empresa", Description = "Cria um novo ramo de empresa com os dados fornecidos.")]
        [ProducesResponseType(typeof(RamoEmpresa), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RamoEmpresa>> Add([FromBody] RamoEmpresa ramoEmpresa)
        {
            var createdRamoEmpresa = await _ramoEmpresaService.AddAsync(ramoEmpresa);
            return CreatedAtAction(nameof(GetById), new { id = createdRamoEmpresa.Id }, createdRamoEmpresa);
        }

        /// <summary>
        /// Atualiza os dados de um ramo de empresa.
        /// </summary>
        /// <param name="id">ID do ramo de empresa</param>
        /// <param name="ramoEmpresa">Dados atualizados do ramo de empresa</param>
        /// <returns>Resultado da operação</returns>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza os dados de um ramo de empresa", Description = "Atualiza as informações de um ramo de empresa com base no ID fornecido.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] RamoEmpresa ramoEmpresa)
        {
            if (id != ramoEmpresa.Id)
            {
                return BadRequest();
            }

            await _ramoEmpresaService.UpdateAsync(ramoEmpresa);
            return NoContent();
        }

        /// <summary>
        /// Exclui um ramo de empresa pelo ID.
        /// </summary>
        /// <param name="id">ID do ramo de empresa</param>
        /// <returns>Resultado da operação</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Exclui um ramo de empresa pelo ID", Description = "Remove um ramo de empresa com base no ID fornecido.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await _ramoEmpresaService.DeleteAsync(id);
            return NoContent();
        }
    }
}
