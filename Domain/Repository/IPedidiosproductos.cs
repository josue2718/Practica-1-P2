using Practica_1_P2.Domain.Entities;


namespace Practica_1_P2.Domain.Repository
{
    public interface IPedidoProdRepository
    {
        Task<List<PedidoProductos>> GetAllPedidoProdsAsync(); // Cambiado a PedidoProductos
        Task<PedidoProductos> GetPedidoProdByIdAsync(int id); // Cambiado a PedidoProductos
        Task<PedidoProductos> CreatePedidoProdAsync(PedidoProductos pedido); // Cambiado a PedidoProductos
        Task<PedidoProductos> UpdatePedidoProdAsync(int id, PedidoProductos pedido); // Cambiado a PedidoProductos
        Task<bool> DeletePedidoProdAsync(int id); // Este se queda igual
    }
}
