using Practica_1_P2.Domain.Entities;

namespace Practica_1_P2.Domain.Repository
{
    public interface IPedidoRepository
    {
        Task<List<Pedido>> GetAllPedidosAsync();
        Task<Pedido> GetPedidoByIdAsync(int id);
        Task<Pedido> CreatePedidoAsync(Pedido pedido);
        Task<Pedido> UpdatePedidoAsync(int id, Pedido pedido);
        Task<bool> DeletePedidoAsync(int id);
    }
}
