using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transferencias.DataContext;
using Transferencias.Models;

namespace Transferencias.DataContext.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                //Agregando datos a tabla cuentas

                if (_context.Cuentas.Any())
                {
                    return;
                }

                _context.Cuentas.AddRange(
                                          new Cuentas { Banco = "Continental", Nro_cuenta = 123456, Saldo = 5000 },
                                          new Cuentas { Banco = "Familiar", Nro_cuenta = 000123, Saldo = 1000000 },
                                          new Cuentas { Banco = "Continental", Nro_cuenta = 001124, Saldo = 1500000 }
                                          );

                _context.SaveChanges();
            }

        }

    }
}
