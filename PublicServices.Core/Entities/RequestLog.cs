using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicServices.Core.Entities
{
    public class RequestLog
    {
        public int Id { get; set; }
        public string NombreServicio { get; set; }
        public DateTime FechaUso { get; set; }
    }
}
