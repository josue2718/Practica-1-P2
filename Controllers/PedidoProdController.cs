using Microsoft.AspNetCore.Mvc;
using Practica_1_P2.Domain.Entities;
using Practica_1_P2.Domain.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practica_1_P2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoProdController : ControllerBase
    {
        private readonly IPedidoProdRepository _pedidoProdService;

        public PedidoProdController(IPedidoProdRepository pedidoProdService)
        {
            _pedidoProdService = pedidoProdService;
        }

        // GET: api/PedidoProd
        [HttpGet]
        public async Task<ActionResult<List<PedidoProductos>>> GetPedidoProds()
        {
            var pedidoProds = await _pedidoProdService.GetAllPedidoProdsAsync();
            return Ok(pedidoProds);
        }

        // GET: api/PedidoProd/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoProductos>> GetPedidoProd(int id)
        {
            var pedidoProd = await _pedidoProdService.GetPedidoProdByIdAsync(id);

            if (pedidoProd == null)
            {
                return NotFound();
            }

            return Ok(pedidoProd);
        }

        // POST: api/PedidoProd
        [HttpPost]
        public async Task<ActionResult<PedidoProductos>> PostPedidoProd(PedidoProductos pedidoProd)
        {
            var nuevoPedidoProd = await _pedidoProdService.CreatePedidoProdAsync(pedidoProd);
            return CreatedAtAction(nameof(GetPedidoProd), new { id = nuevoPedidoProd.Id_PedidoProducto }, nuevoPedidoProd);
        }

        // PUT: api/PedidoProd/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<PedidoProductos>> PutPedidoProd(int id, PedidoProductos pedidoProd)
        {
            var pedidoProdActualizado = await _pedidoProdService.UpdatePedidoProdAsync(id, pedidoProd);

            if (pedidoProdActualizado == null)
            {
                return NotFound();
            }

            return Ok(pedidoProdActualizado);
        }

        // DELETE: api/PedidoProd/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedidoProd(int id)
        {
            var result = await _pedidoProdService.DeletePedidoProdAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
