using PublicServices.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PublicServices.Services.Consult.Interfaces
{
    public interface IConsultService
    {
        Task<GetTasaCambiariaDto> GetTasaCambiaria(string codigoMoneda);
        Task<GetIndiceInflacionDto> GetIndiceInflacion(string periodo);
        Task<GetSaludFinancieraDto> GetSaludFinanciera(string identificador);
        Task<IList<HistorialCrediticioDto>> GetHistorialCrediticio(string identificador);
    }
}
