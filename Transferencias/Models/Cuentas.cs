using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Transferencias.Models
{
    public class Cuentas
    {
        [Key]
        public int Id { get; set; }

        public string Banco { get; set; }

        public int Nro_cuenta { get; set; }

        public int Saldo { get; set; }
    }
}
