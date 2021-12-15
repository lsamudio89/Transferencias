using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transferencias.DataContext;
using Transferencias.Models;

namespace Transferencias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CuentasController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetCuentas()
        {
            var lista = await _db.Cuentas.OrderBy(c => c.Banco).ToListAsync();
            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCuentas(int id)
        {
            var obj = await _db.Cuentas.FirstOrDefaultAsync(c => c.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            return Ok(obj);
        }

        [HttpPost]
        public async Task<IActionResult> AddCuentas([FromBody] Cuentas cuentas)
        {
            if (cuentas == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _db.AddAsync(cuentas);
            await _db.SaveChangesAsync();

            return Ok();

            //await _db.Cuentas.Add(cuentas);
            //_db.SaveChanges();

            //return Created( uri: "api/cuentas/" + cuentas.Id , cuentas);
            
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateCuentas(int id, Cuentas cuentas)
        {

            var emp = _db.Cuentas.SingleOrDefault(cuentas => cuentas.Id == id);

            if (emp == null)
            {
                return NotFound("Cuenta con el id : " + id + "no existe");
            }

            _db.Update(emp);
            _db.SaveChangesAsync();
            return Ok("Cuenta Modificada con el id " + id);

        }




    }
}
