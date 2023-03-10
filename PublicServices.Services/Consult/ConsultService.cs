using PublicServices.Core.DTOs;
using PublicServices.Core.Entities;
using PublicServices.DataAccess.Interfaces;
using PublicServices.Services.Consult.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicServices.Services.Consult
{
    public class ConsultService: IConsultService
    {
        private readonly IUnitOfWork unitOfWork;
        public ConsultService(IUnitOfWork UnitOfWork)
        {
            unitOfWork = UnitOfWork;            
        }

        public async Task<IList<HistorialCrediticioDto>> GetHistorialCrediticio(string identificador)
        {
            return (await unitOfWork.HistorialCrediticioRepository.
                GetAll(x => x.Identificador == identificador))
                .Select(y => new HistorialCrediticioDto
                {
                    ConceptoDeuda = y.ConceptoDeuda,
                    Fecha = y.Fecha,
                    MontoTotalAdeudado = y.MontoTotal,
                    RncAcreedor = y.RNC_Acreedor
                })
                .ToList();
        }

        public async Task<GetIndiceInflacionDto> GetIndiceInflacion(string periodo)
        {
            DateTime date = DateTime.Now;

            if (!DateTime.TryParseExact(periodo, "yyyyMM", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                throw new Exception("Parametro periodo invalido");

            var result = await unitOfWork.IndiceInflacionRepository
                .Get(x => x.Periodo.Month == date.Month && x.Periodo.Day == date.Day);

            if (result == null)
                return null;

            return new GetIndiceInflacionDto
            {
                Indice = result.Indice
            };
        }

        public Task<GetSaludFinancieraDto> GetSaludFinanciera(string identificador)
        {
            throw new NotImplementedException();
        }

        public async Task<GetTasaCambiariaDto> GetTasaCambiaria(string codigoMoneda)
        {

            var result = await unitOfWork.TasaCambiariaRepository
                .Get(x => x.Moneda.Abreviatura == codigoMoneda, $"{nameof(TasaCambiaria.Moneda)}");

            if (result == null)
                return null;

            return new GetTasaCambiariaDto
            {
                Tasa = result.Monto
            };
        }
    }
}
