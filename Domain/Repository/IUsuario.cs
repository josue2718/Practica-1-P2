using Practica_1_P2.Domain.Entities;

namespace Practica_1_P2.Domain.Repository
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllUsuariosAsync();
        Task<Usuario> GetUsuarioByIdAsync(int id);
        Task<Usuario> CreateUsuarioAsync(Usuario usuario);
        Task<Usuario> UpdateUsuarioAsync(int id, Usuario usuario);
        Task<bool> DeleteUsuarioAsync(int id);
    }
}
