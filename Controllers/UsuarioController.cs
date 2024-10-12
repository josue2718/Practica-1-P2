using Microsoft.AspNetCore.Mvc;
using Practica_1_P2.Domain.Entities;
using Practica_1_P2.Domain.Repository;

namespace Practica_1_P2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioService;

        public UsuarioController(IUsuarioRepository usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetUsuarios()
        {
            var Usuarios = await _usuarioService.GetAllUsuariosAsync();
            return Ok(Usuarios);
        }

        // GET: api/Usuario/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // POST: api/Usuario
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            var nuevoUsuario = await _usuarioService.CreateUsuarioAsync(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = nuevoUsuario.Id_Usuario }, nuevoUsuario);
        }

        // PUT: api/Usuario}/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> PutUsuario(int id, Usuario usuario)
        {
            var usuarioActualizado = await _usuarioService.UpdateUsuarioAsync(id, usuario);

            if (usuarioActualizado == null)
            {
                return NotFound();
            }

            return Ok(usuarioActualizado);
        }

        // DELETE: api/Usuario/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var result = await _usuarioService.DeleteUsuarioAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
