using InsightAI.Core.Entities;
using InsightAI.Core.Interfaces.Repositories;
using InsightAI.Core.Interfaces.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
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
