using Microsoft.AspNetCore.Mvc;
using Practica_1_P2.Domain.Entities;
using Practica_1_P2.Domain.Repository;

namespace Practica_1_P2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoService;

        public ProductoController(IProductoRepository productoService)
        {
            _productoService = productoService;
        }

        // GET: api/Producto
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos()
        {
            var productos = await _productoService.GetAllProductoAsync();
            return Ok(productos);
        }

        // GET: api/Producto/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _productoService.GetProductoByIdAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        // POST: api/Producto
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            var nuevoProducto = await _productoService.CreateProductoAsync(producto);
            return CreatedAtAction(nameof(GetProducto), new { id = nuevoProducto.Id_Producto }, nuevoProducto);
        }

        // PUT: api/Producto}/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Producto>> PutProducto(int id, Producto Producto)
        {
            var ProductoActualizado = await _productoService.UpdateProductoAsync(id, Producto);

            if (ProductoActualizado == null)
            {
                return NotFound();
            }

            return Ok(ProductoActualizado);
        }

        // DELETE: api/Producto/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var result = await _productoService.DeleteProductoAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
