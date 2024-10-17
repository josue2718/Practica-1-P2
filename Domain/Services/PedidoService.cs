using Practica_1_P2.Domain.Context;
using Practica_1_P2.Domain.Entities;
using Practica_1_P2.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practica_1_P2.Domain.Services
{
    public class PedidoService : IPedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoService(AppDbContext context)
        {
            _context = context;
        }

        // Obtener todos los pedidos
        public async Task<List<Pedido>> GetAllPedidosAsync()
        {
            // Corregido: Usar ToListAsync directamente
            return await _context.Pedidos.ToListAsync();
        }

        // Obtener pedido por Id
        public async Task<Pedido> GetPedidoByIdAsync(int id)
        {
            // Corregido: Eliminar el Include, ya que 'Id' no es una propiedad de navegación
            return await _context.Pedidos.FirstOrDefaultAsync(p => p.Id_Pedido == id);
        }

        // Crear un nuevo pedido
        public async Task<Pedido> CreatePedidoAsync(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        // Actualizar un pedido existente
        public async Task<Pedido> UpdatePedidoAsync(int id, Pedido pedido)
        {
            var pedidoExistente = await _context.Pedidos.FirstOrDefaultAsync(p => p.Id_Pedido == id);
            if (pedidoExistente == null)
            {
                return null;
            }

            // Actualizar campos del pedido existente
            pedidoExistente.UsuarioID = pedido.UsuarioID;
       

            await _context.SaveChangesAsync();
            return pedidoExistente;
        }

        // Eliminar un pedido
        public async Task<bool> DeletePedidoAsync(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return false;
            }

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return true;
        }
    }


}