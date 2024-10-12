using Practica_1_P2.Domain.Entities;

namespace Practica_1_P2.Domain.Repository
{
    public interface IProductoRepository
    {
        Task<List<Producto>> GetAllProductoAsync();
        Task<Producto> GetProductoByIdAsync(int id);
        Task<Producto> CreateProductoAsync(Producto producto);
        Task<Producto> UpdateProductoAsync(int id, Producto producto);
        Task<bool> DeleteProductoAsync(int id);
    }
}
