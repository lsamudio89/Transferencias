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
    public class TransferenciasBancariasController : ControllerBase
    {
        private readonly AppDbContext _db;

        public TransferenciasBancariasController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransferenciasBancarias()
        {
            //var lista = await _db.Cuentas.OrderBy(c => c.Banco).ToListAsync();
            var lista = await _db.TransferenciasBancarias.OrderBy(c => c.BancoOrigen).ToListAsync();
            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTransferencias(int id)
        {
            var obj = await _db.TransferenciasBancarias.FirstOrDefaultAsync(c => c.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            return Ok(obj);
        }

        [HttpPost]
        public IActionResult AddTransferencia(TransferenciasBancarias transferencias)
        {
            var cuenta = _db.Cuentas.SingleOrDefault(cuenta => cuenta.Nro_cuenta == transferencias.CuentaOrigen);
            if (cuenta.Saldo <= 0)
            {
                return NotFound("Error al realizar la transferencia, motivo: Insuficiencia de fondos");
            }
            if (transferencias.BancoOrigen == transferencias.BancoDestino)
            {
                return NotFound("Los Bancos no deben ser iguales");
            }
            _db.TransferenciasBancarias.Add(transferencias);
            _db.SaveChanges();
            return Created("api/transferencia/" + transferencias.Id, transferencias);
        }

        [HttpPut("{Id}")]
        public IActionResult Update(int Id, TransferenciasBancarias transferencias)
        {
            _db.Update(transferencias);
            _db.SaveChanges();
            return Ok("La transferencia: " + Id + " se actualizo correctamente");
        }




    }
}