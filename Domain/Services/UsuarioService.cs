using Practica_1_P2.Domain.Context;
using Practica_1_P2.Domain.Entities;
using Practica_1_P2.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Practica_1_P2.Domain.Services
{
    public class UsuarioService : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        // Obtener todos los Usuarios
        public async Task<List<Usuario>> GetAllUsuariosAsync()
        {
            // Corregido: Usar ToListAsync directamente
            return await _context.Usuarios.ToListAsync();
        }

        // Obtener Usuario por Id
        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            // Corregido: Eliminar el Include, ya que 'Id' no es una propiedad de navegación
            return await _context.Usuarios.FirstOrDefaultAsync(p => p.Id_Usuario == id);
        }

        // Crear un nuevo Usuario
        public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        // Actualizar un Usuario existente
        public async Task<Usuario> UpdateUsuarioAsync(int id, Usuario usuario)
        {
            var usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(p => p.Id_Usuario == id);
            if (usuarioExistente == null)
            {
                return null;
            }

            // Actualizar campos del Usuario existente
            usuarioExistente.Nombre = usuario.Nombre;
            usuarioExistente.Email = usuario.Email;

            await _context.SaveChangesAsync();
            return usuarioExistente;
        }

        // Eliminar un Usuario
        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
