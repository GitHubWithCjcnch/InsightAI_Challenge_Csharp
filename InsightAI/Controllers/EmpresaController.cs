using InsightAI.Core.Entities;
using InsightAI.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InsightAI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        /// <summary>
        /// Obtém uma empresa pelo ID.
        /// </summary>
        /// <param name="id">ID da empresa</param>
        /// <returns>Detalhes da empresa</returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém uma empresa pelo ID", Description = "Retorna os detalhes de uma empresa com base no ID fornecido.")]
        [ProducesResponseType(typeof(Empresa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Empresa>> GetById(int id)
        {
            var empresa = await _empresaService.GetByIdAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }
            return Ok(empresa);
        }

        /// <summary>
        /// Lista todas as empresas.
        /// </summary>
        /// <returns>Lista de empresas</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Lista todas as empresas", Description = "Retorna uma lista de todas as empresas cadastradas.")]
        [ProducesResponseType(typeof(IReadOnlyList<Empresa>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<Empresa>>> ListAll()
        {
            var empresas = await _empresaService.ListAllAsync();
            return Ok(empresas);
        }

        /// <summary>
        /// Adiciona uma nova empresa.
        /// </summary>
        /// <param name="empresa">Dados da nova empresa</param>
        /// <returns>Empresa criada</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona uma nova empresa", Description = "Cria uma nova empresa com os dados fornecidos.")]
        [ProducesResponseType(typeof(Empresa), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Empresa>> Add([FromBody] Empresa empresa)
        {
            var createdEmpresa = await _empresaService.AddAsync(empresa);
            return CreatedAtAction(nameof(GetById), new { id = createdEmpresa.Id }, createdEmpresa);
        }

        /// <summary>
        /// Atualiza os dados de uma empresa.
        /// </summary>
        /// <param name="id">ID da empresa</param>
        /// <param name="empresa">Dados atualizados da empresa</param>
        /// <returns>Resultado da operação</returns>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza os dados de uma empresa", Description = "Atualiza as informações de uma empresa com base no ID fornecido.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] Empresa empresa)
        {
            if (id != empresa.Id)
            {
                return BadRequest();
            }

            await _empresaService.UpdateAsync(empresa);
            return NoContent();
        }

        /// <summary>
        /// Exclui uma empresa pelo ID.
        /// </summary>
        /// <param name="id">ID da empresa</param>
        /// <returns>Resultado da operação</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Exclui uma empresa pelo ID", Description = "Remove uma empresa com base no ID fornecido.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await _empresaService.DeleteAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Obtém empresas associadas a um ramo de empresa específico.
        /// </summary>
        /// <param name="ramoEmpresaId">ID do ramo de empresa</param>
        /// <returns>Lista de empresas associadas ao ramo</returns>
        [HttpGet("ramo/{ramoEmpresaId}")]
        [SwaggerOperation(Summary = "Obtém empresas por ramo", Description = "Retorna uma lista de empresas associadas ao ramo de empresa especificado.")]
        [ProducesResponseType(typeof(IReadOnlyList<Empresa>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<Empresa>>> GetByRamoEmpresa(int ramoEmpresaId)
        {
            var empresas = await _empresaService.GetByRamoEmpresaAsync(ramoEmpresaId);
            return Ok(empresas);
        }
    }
}
