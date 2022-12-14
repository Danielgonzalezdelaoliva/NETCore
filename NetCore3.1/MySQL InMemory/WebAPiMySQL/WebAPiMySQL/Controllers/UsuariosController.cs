using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPiMySQL.Models;

namespace WebAPiMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ContextCCA _context;

        public UsuariosController(ContextCCA context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cca_user>>> GetUsuario()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<cca_user>> GetUsuario(int id)
        {
            var cca_user = await _context.Usuarios.FindAsync(id);

            if (cca_user == null)
            {
                return NotFound();
            }

            return cca_user;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, cca_user cca_user)
        {
            if (id != cca_user.IdUser)
            {
                return BadRequest();
            }

            _context.Entry(cca_user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cca_userExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<cca_user>> PostUsuario(cca_user cca_user)
        {
            _context.Usuarios.Add(cca_user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = cca_user.IdUser }, cca_user);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<cca_user>> DeleteUsuario(int id)
        {
            var cca_user = await _context.Usuarios.FindAsync(id);
            if (cca_user == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(cca_user);
            await _context.SaveChangesAsync();

            return cca_user;
        }

        private bool cca_userExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUser == id);
        }
    }
}
