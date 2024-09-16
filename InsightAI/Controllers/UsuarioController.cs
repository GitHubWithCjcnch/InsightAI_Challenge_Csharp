using InsightAI.Core.Entities;
using InsightAI.Core.Interfaces.Repositories;
using InsightAI.Core.Interfaces.Services;
using InsightAI.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InsightAI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioService = UsuarioService.GetInstance(usuarioRepository);
        }

        /// <summary>
        /// Obtém um usuário pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <returns>Dados do usuário</returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um usuário pelo ID", Description = "Retorna os detalhes de um usuário baseado no ID fornecido.")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        /// <summary>
        /// Obtém um usuário pelo e-mail.
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <returns>Dados do usuário</returns>
        [HttpGet("email/{email}")]
        [SwaggerOperation(Summary = "Obtém um usuário pelo e-mail", Description = "Retorna os detalhes de um usuário com base no e-mail fornecido.")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Usuario>> GetByEmail(string email)
        {
            var usuario = await _usuarioService.GetUsuarioByEmailAsync(email);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        /// <summary>
        /// Lista todos os usuários.
        /// </summary>
        /// <returns>Lista de usuários</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os usuários", Description = "Retorna uma lista com todos os usuários cadastrados.")]
        [ProducesResponseType(typeof(IEnumerable<Usuario>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Usuario>>> ListAll()
        {
            var usuarios = await _usuarioService.GetAllUsuariosAsync();
            return Ok(usuarios);
        }

        /// <summary>
        /// Adiciona um novo usuário.
        /// </summary>
        /// <param name="usuario">Objeto com os dados do usuário</param>
        /// <returns>Usuário criado</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona um novo usuário", Description = "Cria um novo usuário com os dados fornecidos.")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Usuario>> Add([FromBody] Usuario usuario)
        {
            var createdUsuario = await _usuarioService.AddUsuarioAsync(usuario);
            return CreatedAtAction(nameof(GetById), new { id = createdUsuario.Id }, createdUsuario);
        }

        /// <summary>
        /// Atualiza os dados de um usuário.
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <param name="usuario">Dados atualizados do usuário</param>
        /// <returns>Resultado da operação</returns>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza os dados de um usuário", Description = "Atualiza as informações de um usuário com base no ID fornecido.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            await _usuarioService.UpdateUsuarioAsync(usuario);
            return NoContent();
        }

        /// <summary>
        /// Exclui um usuário pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <returns>Resultado da operação</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Exclui um usuário pelo ID", Description = "Remove um usuário com base no ID fornecido.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await _usuarioService.DeleteUsuarioAsync(id);
            return NoContent();
        }
    }
}
