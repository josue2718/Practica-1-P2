using Microsoft.EntityFrameworkCore;
using Practica_1_P2.Domain.Context;
using Practica_1_P2.Domain.Entities;
using Practica_1_P2.Domain.Repository;

namespace Practica_1_P2.Domain.Services
{
    public class ProductoService : IProductoRepository
    {
        private readonly AppDbContext _context;

        public ProductoService(AppDbContext context)
        {
            _context = context;
        }

        // Obtener todos los Productos
        public async Task<List<Producto>> GetAllProductoAsync()
        {
            // Corregido: Usar ToListAsync directamente
            return await _context.Productos.ToListAsync();
        }

        // Obtener Producto por Id
        public async Task<Producto> GetProductoByIdAsync(int id)
        {
            // Corregido: Eliminar el Include, ya que 'Id' no es una propiedad de navegación
            return await _context.Productos.FirstOrDefaultAsync(p => p.Id_Producto == id);
        }

        // Crear un nuevo Producto
        public async Task<Producto> CreateProductoAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        // Actualizar un Producto existente
        public async Task<Producto> UpdateProductoAsync(int id, Producto producto)
        {
            var productoExistente = await _context.Productos.FirstOrDefaultAsync(p => p.Id_Producto == id);
            if (productoExistente == null)
            {
                return null;
            }

            // Actualizar campos del Producto existente
            productoExistente.Nombre = producto.Nombre;
            productoExistente.Precio = producto.Precio;

            await _context.SaveChangesAsync();
            return productoExistente;
        }

        // Eliminar un Producto
        public async Task<bool> DeleteProductoAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return false;
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
