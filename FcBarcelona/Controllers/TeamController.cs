using FcBarcelona.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization; 
using Newtonsoft.Json; 
namespace FcBarcelona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Requiere autenticación para todas las acciones en este controlador
    public class TeamController : ControllerBase
    {
        private readonly TeamContext _context;

        public TeamController(TeamContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Agregar jugador")]
        public async Task<IActionResult> AgregarJugador(Barcelona barcelona)
        {
            await _context.Plantilla.AddAsync(barcelona);
            await _context.SaveChangesAsync();
            await RegistrarAuditoria("Inserción", "dbo.plantilla", null, JsonConvert.SerializeObject(barcelona));
            return Ok();
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult<IEnumerable<Barcelona>>> ListasDeJugadores()
        {
            var jugadores = await _context.Plantilla.ToListAsync();
            return Ok(jugadores);
        }

        [HttpGet]
        [Route("Visualizar")]
        public async Task<IActionResult> VisualizarProducto(int id)
        {
            Barcelona? jugadores = await _context.Plantilla.FindAsync(id);
            if (jugadores == null)
            {
                return NotFound();
            }
            return Ok(jugadores);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> ActualizarProducto(int id, Barcelona barcelona)
        {
            var JugadorActual = await _context.Plantilla.FindAsync(id);
            if (JugadorActual == null) return NotFound();

            var datosAnteriores = JsonConvert.SerializeObject(JugadorActual);
            JugadorActual.Nombre = barcelona.Nombre;
            JugadorActual.edad = barcelona.edad;
            JugadorActual.Posicion = barcelona.Posicion;

            await _context.SaveChangesAsync();
            await RegistrarAuditoria("Actualización", "dbo.plantilla", datosAnteriores, JsonConvert.SerializeObject(JugadorActual));
            return Ok();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public async Task<ActionResult> EliminarJugador(int id)
        {
            var JugadorEliminado = await _context.Plantilla.FindAsync(id);
            if (JugadorEliminado == null) return NotFound();

            var datosAnteriores = JsonConvert.SerializeObject(JugadorEliminado);
            _context.Plantilla.Remove(JugadorEliminado);
            await _context.SaveChangesAsync();
            await RegistrarAuditoria("Eliminación", "dbo.plantilla", datosAnteriores, null );
            return Ok();
        }

        private async Task RegistrarAuditoria(string accion, string tabla, string datosAnteriores, string datosNuevos)
        {
            var auditoria = new Auditoria
            {
                Accion = accion,
                Tabla = tabla,
                DatosAnteriores = datosAnteriores,
                DatosNuevos = datosNuevos,
                Fecha = DateTime.Now,
                Usuario = Environment.UserName,
                PC = Environment.MachineName
            };

            _context.Auditoria.Add(auditoria);
            await _context.SaveChangesAsync();
        }
    }
}