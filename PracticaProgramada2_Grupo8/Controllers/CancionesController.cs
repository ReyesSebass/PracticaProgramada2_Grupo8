using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaProgramada2_Grupo8.Data;
using PracticaProgramada2_Grupo8.Models;

namespace PracticaProgramada2_Grupo8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CancionesController : ControllerBase
    {
        private readonly ConexionBbContext _contextAcceso;


        public CancionesController(ConexionBbContext contextAcceso)
        {
            _contextAcceso = contextAcceso;
        }

        //Mostrar todos los Canciones existentes
        [HttpGet]
        public ActionResult<IEnumerable<CancionModel>> ObtenerCanciones()
        {
            return Ok(_contextAcceso.G8_CANCIONES.ToList());
        }

        // Obtener un Cancion pr ID
        [HttpGet("{_id}")]
        public ActionResult<IEnumerable<CancionModel>> ObtenerCanciones(int _id)
        {
            var datos = _contextAcceso.G8_CANCIONES.Find(_id);

            if (datos == null)
            {
                return NotFound("El dato buscado no existe.");
            }

            return Ok(datos);
        }

        //Agregar un Nuevo Cancion
        [HttpPost]
        public IActionResult AgregarCancion(CancionModel _datos)
        {
            try
            {
                _contextAcceso.G8_CANCIONES.Add(_datos);
                _contextAcceso.SaveChanges();

                return Ok("Cancion insertado exitosamente.");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //Editar/Modificar un Cancion existente
        [HttpPut]
        public IActionResult ModificarCancion(CancionModel _datos)
        {
            try
            {
                if (!ConsultarDatos(_datos.id))
                {
                    return NotFound("El dato buscado no existe.");
                }
                _contextAcceso.Entry(_datos).State = EntityState.Modified;
                _contextAcceso.SaveChanges();

                return Ok("Cancion modificado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //Eliminar un Canciones
        [HttpDelete("{_id}")]
        public ActionResult EliminarCanciones(int _id)
        {
            try
            {
                if (!ConsultarDatos(_id))
                {
                    return NotFound("El dato buscado no existe.");
                }
                var datos = _contextAcceso.G8_CANCIONES.Find(_id);
                _contextAcceso.G8_CANCIONES.Remove(datos);
                _contextAcceso.SaveChanges();

                return Ok($"Se elimino el registro {_id}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Funcion para verificar si exise 
        private bool ConsultarDatos(int _id)
        {
            return _contextAcceso.G8_CANCIONES.Any(x => x.id == _id);
        }
    }
}
