using InsightAI.Core.Entities;
using InsightAI.Core.Interfaces.Services;
using InsightAI.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsightAI.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private static UsuarioService _usuarioInstance;
        private static readonly object _lock = new object();

        private readonly IUsuarioRepository _usuarioRepository;

        private UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public static UsuarioService GetInstance(IUsuarioRepository usuarioRepository)
        {
            if (_usuarioInstance == null)
            {
                lock (_lock)
                {
                    if (_usuarioInstance == null)
                    {
                        _usuarioInstance = new UsuarioService(usuarioRepository);
                    }
                }
            }
            return _usuarioInstance;
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        public async Task<Usuario> GetUsuarioByEmailAsync(string email)
        {
            return await _usuarioRepository.GetByEmailAsync(email);
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _usuarioRepository.ListAllAsync();
        }

        public async Task<Usuario> AddUsuarioAsync(Usuario usuario)
        {
            return await _usuarioRepository.AddAsync(usuario);
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            await _usuarioRepository.UpdateAsync(usuario);
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario != null)
            {
                await _usuarioRepository.DeleteAsync(usuario);
            }
        }
    }

}
