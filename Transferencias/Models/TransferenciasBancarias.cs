using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Transferencias.Models
{
    public class TransferenciasBancarias
    {

        [Key]
        public int Id { get; set; }
        public int CuentaOrigen { get; set; }
        public string BancoOrigen { get; set; }
        public int CuentaDestino { get; set; }
        public string BancoDestino { get; set; }
        public DateTime FechaOperacion { get; set; }
        public float MontoOperacion { get; set; }
        public string EstadoTransferencias { get; set; }

    }
}
