using InsightAI.Core.Entities;
using InsightAI.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InsightAI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnaliseController : ControllerBase
    {
        private readonly IAnaliseService _analiseService;

        public AnaliseController(IAnaliseService analiseService)
        {
            _analiseService = analiseService;
        }

        /// <summary>
        /// Obtém uma análise pelo ID.
        /// </summary>
        /// <param name="id">ID da análise</param>
        /// <returns>Detalhes da análise</returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém uma análise pelo ID", Description = "Retorna os detalhes de uma análise com base no ID fornecido.")]
        [ProducesResponseType(typeof(Analise), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Analise>> GetById(int id)
        {
            var analise = await _analiseService.GetByIdAsync(id);
            if (analise == null)
            {
                return NotFound();
            }
            return Ok(analise);
        }

        /// <summary>
        /// Lista todas as análises.
        /// </summary>
        /// <returns>Lista de análises</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Lista todas as análises", Description = "Retorna uma lista de todas as análises cadastradas.")]
        [ProducesResponseType(typeof(IReadOnlyList<Analise>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<Analise>>> ListAll()
        {
            var analises = await _analiseService.ListAllAsync();
            return Ok(analises);
        }

        /// <summary>
        /// Adiciona uma nova análise.
        /// </summary>
        /// <param name="analise">Dados da nova análise</param>
        /// <returns>Análise criada</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona uma nova análise", Description = "Cria uma nova análise com os dados fornecidos.")]
        [ProducesResponseType(typeof(Analise), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Analise>> Add([FromBody] Analise analise)
        {
            var createdAnalise = await _analiseService.AddAsync(analise);
            return CreatedAtAction(nameof(GetById), new { id = createdAnalise.Id }, createdAnalise);
        }

        /// <summary>
        /// Atualiza os dados de uma análise.
        /// </summary>
        /// <param name="id">ID da análise</param>
        /// <param name="analise">Dados atualizados da análise</param>
        /// <returns>Resultado da operação</returns>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza os dados de uma análise", Description = "Atualiza as informações de uma análise com base no ID fornecido.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] Analise analise)
        {
            if (id != analise.Id)
            {
                return BadRequest();
            }

            await _analiseService.UpdateAsync(analise);
            return NoContent();
        }

        /// <summary>
        /// Exclui uma análise pelo ID.
        /// </summary>
        /// <param name="id">ID da análise</param>
        /// <returns>Resultado da operação</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Exclui uma análise pelo ID", Description = "Remove uma análise com base no ID fornecido.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await _analiseService.DeleteAsync(id);
            return NoContent();
        }
    }
}
