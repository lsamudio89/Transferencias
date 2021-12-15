using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transferencias.Controllers;
using Transferencias.Models;

namespace Transferencias.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cuentas> Cuentas { get; set; }

        public DbSet<TransferenciasBancarias> TransferenciasBancarias { get; set; }

        //public List<Controllers.Transferencias> TransferenciasBancarias { get; internal set; }
    }
}
