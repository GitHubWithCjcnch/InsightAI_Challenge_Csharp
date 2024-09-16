using InsightAI.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsightAI.Core.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuarioByIdAsync(int id);
        Task<Usuario> GetUsuarioByEmailAsync(string email);
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
        Task<Usuario> AddUsuarioAsync(Usuario usuario);
        Task UpdateUsuarioAsync(Usuario usuario);
        Task DeleteUsuarioAsync(int id);
    }
}
