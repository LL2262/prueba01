using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;

namespace prueba_empleados_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuestosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PuestosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Puestos
        [HttpGet]
        public IEnumerable<Puesto> GetPuestos()
        {
            return _context.Puestos;
        }

        // GET: api/Puestos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPuesto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var puesto = await _context.Puestos.FindAsync(id);

            if (puesto == null)
            {
                return NotFound();
            }

            return Ok(puesto);
        }

        // POST: api/Puestos/EditPuesto
        [HttpPut("[action]")]
        public async Task<IActionResult> EditPuesto([FromBody] Puesto puesto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (puesto.PuestoID <= 0)
            {
                return BadRequest();
            }

            var puestoEdit = await _context.Puestos.FirstOrDefaultAsync(p => p.PuestoID == puesto.PuestoID);

            if (puestoEdit == null)
            {
                return NotFound();
            }

            puestoEdit.nombre = puesto.nombre;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Puestos
        [HttpPost]
        public async Task<IActionResult> PostPuesto([FromBody] Puesto puesto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Puestos.Add(puesto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPuesto", new { id = puesto.PuestoID }, puesto);
        }

        // DELETE: api/Puestos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePuesto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var puesto = await _context.Puestos.FindAsync(id);
            if (puesto == null)
            {
                return NotFound();
            }

            _context.Puestos.Remove(puesto);
            await _context.SaveChangesAsync();

            return Ok(puesto);
        }

        private bool PuestoExists(int id)
        {
            return _context.Puestos.Any(e => e.PuestoID == id);
        }
    }
}