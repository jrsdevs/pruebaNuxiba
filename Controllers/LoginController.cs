using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nuxibaService.Contexto;
using nuxibaService.Model;
using System.Net;

namespace nuxibaService.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly NuxibaContext _context;

        public LoginController(NuxibaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ccloglogin>>> logins()
        {
            return await _context.ccloglogins.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Ccloglogin>> insertaLogin(Ccloglogin clog)
        {
            try
            {
                if (!_context.users.Any(u => u.User_id == clog.User_id))
                {
                    return BadRequest("El userId no existe");
                }
                else
                {
                    if (clog.fecha > DateTime.Now)
                    {
                        return BadRequest("La fecha ingresada no puede ser mayor a la fecha y hora actual");
                    }
                    else
                    {
                        var ultimoLogin = _context.ccloglogins.Where(cl => cl.User_id == clog.User_id).OrderByDescending(f => f.fecha).FirstOrDefault();

                        if (ultimoLogin != null)
                        {

                            if (ultimoLogin.TipoMov == clog.TipoMov)
                            {
                                return BadRequest("Error, no pueden exisitir dos tipos de movimiento consecutivos");
                            }
                            else
                            {
                                if (ultimoLogin.fecha >= DateTime.Now)
                                {
                                    return BadRequest("La fecha del nuevo inicio de sesión no puede ser menor al ultimo registro de sesión");
                                }
                                else
                                {
                                    _context.ccloglogins.Add(clog);
                                    await _context.SaveChangesAsync();
                                    return Ok("Login creado de manera exitosa");
                                }
                            }
                        }
                        else
                        {
                            _context.ccloglogins.Add(clog);
                            await _context.SaveChangesAsync();
                            return Ok("Login creado de manera exitosa");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error en el proceso: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> actualizarLogin(int id, Ccloglogin clog)
        {
            try
            {
                _context.ccloglogins.Update(clog);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error al actualizar el login: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> eliminarLogin(int id)
        {
            try
            {
                Ccloglogin log = _context.ccloglogins.ToList().Where(f => f.LogId == id).FirstOrDefault();
                _context.ccloglogins.Remove(log);
                await _context.SaveChangesAsync();
                return Ok("Login eliminado");
            }
            catch (Exception ex)
            {
                return Ok("Error al elimnar login: " + ex.Message);
            }
        }


    }
}
