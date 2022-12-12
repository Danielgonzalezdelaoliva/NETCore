using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiMySQLDB.Models;

namespace WebApiMySQLDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuariosController : ControllerBase
    {
        private readonly ContextCCA _context;

        public UsuariosController(ContextCCA context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CcaUser>>> GetUsuario()
        {
            return await _context.CcaUser.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}" , Name ="ObtenerUsuario")]
        public async Task<ActionResult<CcaUser>> GetUsuario(int id)
        {
            var ccaUser = await _context.CcaUser.FindAsync(id);

            if (ccaUser == null)
            {
                return NotFound();
            }

            return ccaUser;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, CcaUser ccaUser)
        {
            if (id != ccaUser.IdUser)
            {
                return BadRequest();
            }

            _context.Entry(ccaUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CcaUserExists(id))
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
        public async Task<ActionResult<CcaUser>> PostUsuario(CcaUser ccaUser)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }    

            _context.CcaUser.Add(ccaUser);
            await _context.SaveChangesAsync();
            
            //return CreatedAtAction(nameof(GetUsuario), new { id = ccaUser.IdUser }, ccaUser);
            return CreatedAtRoute("ObtenerUsuario", new { id = ccaUser.IdUser }, ccaUser);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CcaUser>> DeleteUsuario(int id)
        {
            var ccaUser = await _context.CcaUser.FindAsync(id);
            if (ccaUser == null)
            {
                return NotFound();
            }

            _context.CcaUser.Remove(ccaUser);
            await _context.SaveChangesAsync();

            return ccaUser;
        }

        private bool CcaUserExists(int id)
        {
            return _context.CcaUser.Any(e => e.IdUser == id);
        }
    }
}
