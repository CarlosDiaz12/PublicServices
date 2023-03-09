using System;
using System.Collections.Generic;
using System.Text;

namespace PublicServices.Core.Entities
{
    public class HistorialCrediticio
    {
        public int Id { get; set; }
        public string Identificador { get; set; }
        public string ConceptoDeuda { get; set; }
        public DateTime Fecha { get; set; }
        public string RNC_Acreedor { get; set; }
        public decimal MontoTotal { get; set; }

    }
}
