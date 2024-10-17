using Practica_1_P2.Domain.Context;
using Practica_1_P2.Domain.Entities;
using Practica_1_P2.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practica_1_P2.Domain.Services
{
    public class PedidoProductosService : IPedidoProdRepository
    {
        private readonly AppDbContext _context;

        public PedidoProductosService(AppDbContext context)
        {
            _context = context;
        }

        // Obtener todos los pedidos de productos
        public async Task<List<PedidoProductos>> GetAllPedidoProdsAsync()
        {
            return await _context.PedidoProductos.ToListAsync();
        }

        // Obtener pedido de producto por Id
        public async Task<PedidoProductos> GetPedidoProdByIdAsync(int id)
        {
            return await _context.PedidoProductos.FirstOrDefaultAsync(pp => pp.Id_PedidoProducto == id);
        }

        // Crear un nuevo pedido de producto
        public async Task<PedidoProductos> CreatePedidoProdAsync(PedidoProductos pedidoProducto)
        {
            _context.PedidoProductos.Add(pedidoProducto);
            await _context.SaveChangesAsync();
            return pedidoProducto;
        }

        // Actualizar un pedido de producto existente
        public async Task<PedidoProductos> UpdatePedidoProdAsync(int id, PedidoProductos pedidoProducto)
        {
            var pedidoProductoExistente = await _context.PedidoProductos.FirstOrDefaultAsync(pp => pp.Id_PedidoProducto == id);
            if (pedidoProductoExistente == null)
            {
                return null;
            }

            // Actualizar campos del pedido de producto existente
            pedidoProductoExistente.PedidoId = pedidoProducto.PedidoId;
            pedidoProductoExistente.ProductoId = pedidoProducto.ProductoId;
            pedidoProductoExistente.Cantidad = pedidoProducto.Cantidad;

            await _context.SaveChangesAsync();
            return pedidoProductoExistente;
        }

        // Eliminar un pedido de producto
        public async Task<bool> DeletePedidoProdAsync(int id)
        {
            var pedidoProducto = await _context.PedidoProductos.FindAsync(id);
            if (pedidoProducto == null)
            {
                return false;
            }

            _context.PedidoProductos.Remove(pedidoProducto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
