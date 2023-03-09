using System;
using System.Collections.Generic;
using System.Text;

namespace PublicServices.Core.Entities
{
    public class TasaCambiaria
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public int MonedaId { get; set; }
        public Moneda Moneda { get; set; }
        public DateTime Fecha { get; set; }
    }
}
