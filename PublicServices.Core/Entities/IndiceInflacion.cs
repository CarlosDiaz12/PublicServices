using System;
using System.Collections.Generic;
using System.Text;

namespace PublicServices.Core.Entities
{
    public class IndiceInflacion
    {
        public int Id { get; set; }
        public DateTime Periodo { get; set; }
        public decimal Indice { get; set; }
    }
}
