using Microsoft.AspNetCore.Mvc;
using Practica_1_P2.Domain.Entities;
using Practica_1_P2.Domain.Repository;

namespace Practica_1_P2.Controllers
{
    

        [Route("api/[controller]")]
        [ApiController]
        public class PedidoController : ControllerBase
        {
            private readonly IPedidoRepository _pedidoService;

            public PedidoController(IPedidoRepository pedidoService)
            {
                _pedidoService = pedidoService;
            }

            // GET: api/Pedido
            [HttpGet]
            public async Task<ActionResult<List<Pedido>>> GetPedidos()
            {
                var pedidos = await _pedidoService.GetAllPedidosAsync();
                return Ok(pedidos);
            }

            // GET: api/Pedido/{id}
            [HttpGet("{id}")]
            public async Task<ActionResult<Pedido>> GetPedido(int id)
            {
                var pedido = await _pedidoService.GetPedidoByIdAsync(id);

                if (pedido == null)
                {
                    return NotFound();
                }

                return Ok(pedido);
            }

            // POST: api/Pedido
            [HttpPost]
            public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
            {
                var nuevoPedido = await _pedidoService.CreatePedidoAsync(pedido);
                return CreatedAtAction(nameof(GetPedido), new { id = nuevoPedido.Id_Pedido }, nuevoPedido);
            }

            // PUT: api/Pedido/{id}
            [HttpPut("{id}")]
            public async Task<ActionResult<Pedido>> PutPedido(int id, Pedido pedido)
            {
                var pedidoActualizado = await _pedidoService.UpdatePedidoAsync(id, pedido);

                if (pedidoActualizado == null)
                {
                    return NotFound();
                }

                return Ok(pedidoActualizado);
            }

            // DELETE: api/Pedido/{id}
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeletePedido(int id)
            {
                var result = await _pedidoService.DeletePedidoAsync(id);

                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }
        }



    
}
