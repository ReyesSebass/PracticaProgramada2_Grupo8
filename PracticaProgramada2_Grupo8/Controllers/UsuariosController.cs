using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaProgramada2_Grupo8.Data;
using PracticaProgramada2_Grupo8.Models;

namespace PracticaProgramada2_Grupo8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ConexionBbContext _contextAcceso;


        public UsuariosController(ConexionBbContext contextAcceso)
        {
            _contextAcceso = contextAcceso;
        }

        //Mostrar todos los usuarios existentes
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioModel>> ObtenerUsuarios()
        {
            return Ok(_contextAcceso.G8_USUARIOS.ToList());
        }

        // Obtener un usuario pr ID
        [HttpGet("{_id}")]
        public ActionResult<IEnumerable<UsuarioModel>> ObtenerUsuarios(int _id)
        {
            var datos = _contextAcceso.G8_USUARIOS.Find(_id);

            if (datos == null)
            {
                return NotFound("El dato buscado no existe.");
            }

            return Ok(datos);
        }

        //Agregar un Nuevo Usuario
        [HttpPost]
        public IActionResult AgregarUsuario(UsuarioModel _datos)
        {
            try
            {
                _contextAcceso.G8_USUARIOS.Add(_datos);
                _contextAcceso.SaveChanges();

                return Ok("Usuario insertado exitosamente.");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //Editar/Modificar un usuario existente
        [HttpPut]
        public IActionResult ModificarUsuario(UsuarioModel _datos)
        {
            try
            {
                if (!ConsultarDatos(_datos.id))
                {
                    return NotFound("El dato buscado no existe.");
                }
                _contextAcceso.Entry(_datos).State = EntityState.Modified;
                _contextAcceso.SaveChanges();

                return Ok("Usuario modificado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //Eliminar un usuarios
        [HttpDelete("{_id}")]
        public ActionResult EliminarUsuarios(int _id)
        {
            try
            {
                if (!ConsultarDatos(_id))
                {
                    return NotFound("El dato buscado no existe.");
                }
                var datos = _contextAcceso.G8_USUARIOS.Find(_id);
                _contextAcceso.G8_USUARIOS.Remove(datos);
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
            return _contextAcceso.G8_USUARIOS.Any(x => x.id == _id);
        }
    }
}
