using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicServices.Core.DTOs
{
    public class GetSaludFinancieraDto
    {
        public bool Indicador { get; set; }
        public string Comentario { get; set; }
        public decimal MontoTotalAdeudado { get; set; }
    }
}
