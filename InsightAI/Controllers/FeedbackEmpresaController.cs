using InsightAI.Core.Entities;
using InsightAI.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InsightAI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackEmpresaController : ControllerBase
    {
        private readonly IFeedbackEmpresaService _feedbackEmpresaService;

        public FeedbackEmpresaController(IFeedbackEmpresaService feedbackEmpresaService)
        {
            _feedbackEmpresaService = feedbackEmpresaService;
        }

        /// <summary>
        /// Obtém um feedback de empresa pelo ID.
        /// </summary>
        /// <param name="id">ID do feedback da empresa</param>
        /// <returns>Detalhes do feedback da empresa</returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um feedback de empresa pelo ID", Description = "Retorna os detalhes de um feedback de empresa com base no ID fornecido.")]
        [ProducesResponseType(typeof(FeedbackEmpresa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FeedbackEmpresa>> GetById(int id)
        {
            var feedbackEmpresa = await _feedbackEmpresaService.GetByIdAsync(id);
            if (feedbackEmpresa == null)
            {
                return NotFound();
            }
            return Ok(feedbackEmpresa);
        }

        /// <summary>
        /// Lista todos os feedbacks de empresas.
        /// </summary>
        /// <returns>Lista de feedbacks de empresas</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os feedbacks de empresas", Description = "Retorna uma lista de todos os feedbacks de empresas cadastrados.")]
        [ProducesResponseType(typeof(IReadOnlyList<FeedbackEmpresa>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<FeedbackEmpresa>>> ListAll()
        {
            var feedbacksEmpresas = await _feedbackEmpresaService.ListAllAsync();
            return Ok(feedbacksEmpresas);
        }

        /// <summary>
        /// Adiciona um novo feedback de empresa.
        /// </summary>
        /// <param name="feedbackEmpresa">Objeto com os dados do novo feedback de empresa</param>
        /// <returns>Feedback de empresa criado</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona um novo feedback de empresa", Description = "Cria um novo feedback de empresa com os dados fornecidos.")]
        [ProducesResponseType(typeof(FeedbackEmpresa), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FeedbackEmpresa>> Add([FromBody] FeedbackEmpresa feedbackEmpresa)
        {
            var createdFeedbackEmpresa = await _feedbackEmpresaService.AddAsync(feedbackEmpresa);
            return CreatedAtAction(nameof(GetById), new { id = createdFeedbackEmpresa.Id }, createdFeedbackEmpresa);
        }

        /// <summary>
        /// Atualiza os dados de um feedback de empresa.
        /// </summary>
        /// <param name="id">ID do feedback de empresa</param>
        /// <param name="feedbackEmpresa">Dados atualizados do feedback de empresa</param>
        /// <returns>Resultado da operação</returns>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza os dados de um feedback de empresa", Description = "Atualiza as informações de um feedback de empresa com base no ID fornecido.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] FeedbackEmpresa feedbackEmpresa)
        {
            if (id != feedbackEmpresa.Id)
            {
                return BadRequest();
            }

            await _feedbackEmpresaService.UpdateAsync(feedbackEmpresa);
            return NoContent();
        }

        /// <summary>
        /// Exclui um feedback de empresa pelo ID.
        /// </summary>
        /// <param name="id">ID do feedback de empresa</param>
        /// <returns>Resultado da operação</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Exclui um feedback de empresa pelo ID", Description = "Remove um feedback de empresa com base no ID fornecido.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await _feedbackEmpresaService.DeleteAsync(id);
            return NoContent();
        }
    }
}
