using PublicServices.Core.DTOs;
using PublicServices.Core.Entities;
using System;
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
        Task<IList<RequestLog>> GetRequestLogs(DateTime? desde, DateTime? hasta);
        Task SaveLog(string serviceName);
    }
}
