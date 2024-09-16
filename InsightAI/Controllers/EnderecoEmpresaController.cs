using InsightAI.Core.Entities;
using InsightAI.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InsightAI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoEmpresaController : ControllerBase
    {
        private readonly IEnderecoEmpresaService _enderecoEmpresaService;

        public EnderecoEmpresaController(IEnderecoEmpresaService enderecoEmpresaService)
        {
            _enderecoEmpresaService = enderecoEmpresaService;
        }

        /// <summary>
        /// Obtém um endereço de empresa pelo ID.
        /// </summary>
        /// <param name="id">ID do endereço da empresa</param>
        /// <returns>Detalhes do endereço da empresa</returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um endereço de empresa pelo ID", Description = "Retorna os detalhes de um endereço de empresa com base no ID fornecido.")]
        [ProducesResponseType(typeof(EnderecoEmpresa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EnderecoEmpresa>> GetById(int id)
        {
            var enderecoEmpresa = await _enderecoEmpresaService.GetByIdAsync(id);
            if (enderecoEmpresa == null)
            {
                return NotFound();
            }
            return Ok(enderecoEmpresa);
        }

        /// <summary>
        /// Lista todos os endereços de empresas.
        /// </summary>
        /// <returns>Lista de endereços de empresas</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os endereços de empresas", Description = "Retorna uma lista de todos os endereços de empresas cadastrados.")]
        [ProducesResponseType(typeof(IReadOnlyList<EnderecoEmpresa>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<EnderecoEmpresa>>> ListAll()
        {
            var enderecosEmpresas = await _enderecoEmpresaService.ListAllAsync();
            return Ok(enderecosEmpresas);
        }

        /// <summary>
        /// Adiciona um novo endereço de empresa.
        /// </summary>
        /// <param name="enderecoEmpresa">Dados do novo endereço de empresa</param>
        /// <returns>Endereço de empresa criado</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona um novo endereço de empresa", Description = "Cria um novo endereço de empresa com os dados fornecidos.")]
        [ProducesResponseType(typeof(EnderecoEmpresa), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EnderecoEmpresa>> Add([FromBody] EnderecoEmpresa enderecoEmpresa)
        {
            var createdEnderecoEmpresa = await _enderecoEmpresaService.AddAsync(enderecoEmpresa);
            return CreatedAtAction(nameof(GetById), new { id = createdEnderecoEmpresa.Id }, createdEnderecoEmpresa);
        }

        /// <summary>
        /// Atualiza os dados de um endereço de empresa.
        /// </summary>
        /// <param name="id">ID do endereço de empresa</param>
        /// <param name="enderecoEmpresa">Dados atualizados do endereço de empresa</param>
        /// <returns>Resultado da operação</returns>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza os dados de um endereço de empresa", Description = "Atualiza as informações de um endereço de empresa com base no ID fornecido.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] EnderecoEmpresa enderecoEmpresa)
        {
            if (id != enderecoEmpresa.Id)
            {
                return BadRequest();
            }

            await _enderecoEmpresaService.UpdateAsync(enderecoEmpresa);
            return NoContent();
        }

        /// <summary>
        /// Exclui um endereço de empresa pelo ID.
        /// </summary>
        /// <param name="id">ID do endereço de empresa</param>
        /// <returns>Resultado da operação</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Exclui um endereço de empresa pelo ID", Description = "Remove um endereço de empresa com base no ID fornecido.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await _enderecoEmpresaService.DeleteAsync(id);
            return NoContent();
        }
    }
}
