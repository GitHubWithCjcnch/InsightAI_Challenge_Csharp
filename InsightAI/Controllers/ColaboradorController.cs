using InsightAI.Core.Entities;
using InsightAI.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InsightAI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly IColaboradorService _colaboradorService;

        public ColaboradorController(IColaboradorService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }

        /// <summary>
        /// Obtém um colaborador pelo ID.
        /// </summary>
        /// <param name="id">ID do colaborador</param>
        /// <returns>Detalhes do colaborador</returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um colaborador pelo ID", Description = "Retorna os detalhes de um colaborador com base no ID fornecido.")]
        [ProducesResponseType(typeof(Colaborador), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Colaborador>> GetById(int id)
        {
            var colaborador = await _colaboradorService.GetByIdAsync(id);
            if (colaborador == null)
            {
                return NotFound();
            }
            return Ok(colaborador);
        }

        /// <summary>
        /// Lista todos os colaboradores.
        /// </summary>
        /// <returns>Lista de colaboradores</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os colaboradores", Description = "Retorna uma lista de todos os colaboradores cadastrados.")]
        [ProducesResponseType(typeof(IReadOnlyList<Colaborador>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<Colaborador>>> ListAll()
        {
            var colaboradores = await _colaboradorService.ListAllAsync();
            return Ok(colaboradores);
        }

        /// <summary>
        /// Adiciona um novo colaborador.
        /// </summary>
        /// <param name="colaborador">Dados do novo colaborador</param>
        /// <returns>Colaborador criado</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona um novo colaborador", Description = "Cria um novo colaborador com os dados fornecidos.")]
        [ProducesResponseType(typeof(Colaborador), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Colaborador>> Add([FromBody] Colaborador colaborador)
        {
            var createdColaborador = await _colaboradorService.AddAsync(colaborador);
            return CreatedAtAction(nameof(GetById), new { id = createdColaborador.Id }, createdColaborador);
        }

        /// <summary>
        /// Atualiza os dados de um colaborador.
        /// </summary>
        /// <param name="id">ID do colaborador</param>
        /// <param name="colaborador">Dados atualizados do colaborador</param>
        /// <returns>Resultado da operação</returns>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza os dados de um colaborador", Description = "Atualiza as informações de um colaborador com base no ID fornecido.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] Colaborador colaborador)
        {
            if (id != colaborador.Id)
            {
                return BadRequest();
            }

            await _colaboradorService.UpdateAsync(colaborador);
            return NoContent();
        }

        /// <summary>
        /// Exclui um colaborador pelo ID.
        /// </summary>
        /// <param name="id">ID do colaborador</param>
        /// <returns>Resultado da operação</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Exclui um colaborador pelo ID", Description = "Remove um colaborador com base no ID fornecido.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await _colaboradorService.DeleteAsync(id);
            return NoContent();
        }
    }
}
