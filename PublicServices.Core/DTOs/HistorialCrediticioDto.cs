using System;

namespace PublicServices.Core.DTOs
{
    public class HistorialCrediticioDto
    {
        public string RncAcreedor { get; set; }
        public string ConceptoDeuda { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoTotalAdeudado { get; set; }
    }
}
