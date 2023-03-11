using PublicServices.Core.DTOs;
using PublicServices.Core.Entities;
using PublicServices.Core.Enum;
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
                .Get(x => x.Periodo.Month == date.Month && x.Periodo.Year == date.Year);

            if (result == null)
                return null;

            return new GetIndiceInflacionDto
            {
                Indice = result.Indice
            };
        }

        public async Task<GetSaludFinancieraDto> GetSaludFinanciera(string identificador)
        {

            var historial = (await unitOfWork.HistorialCrediticioRepository.GetAll(h => h.Identificador == identificador)).ToList();

            if (historial.Count == 0)
                return null;

                decimal montoTotalAdeudado = 0;

                foreach (var item in historial)
                {
                    montoTotalAdeudado += item.MontoTotal;
                }

                string categoriaFinanciera = "";
                if (montoTotalAdeudado > 0 && montoTotalAdeudado <= (decimal)SaludFinancieraEnum.BASICO) categoriaFinanciera = "BASICO";
                if (montoTotalAdeudado > (decimal)SaludFinancieraEnum.BASICO && montoTotalAdeudado <= (decimal)SaludFinancieraEnum.ESTANDAR) categoriaFinanciera = "ESTANDAR";
                if (montoTotalAdeudado > (decimal)SaludFinancieraEnum.ESTANDAR && montoTotalAdeudado <= (decimal)SaludFinancieraEnum.INTERMEDIO) categoriaFinanciera = "INTERMEDIO";
                if (montoTotalAdeudado > (decimal)SaludFinancieraEnum.INTERMEDIO && montoTotalAdeudado <= (decimal)SaludFinancieraEnum.PREMIUM) categoriaFinanciera = "PREMIUM";
                if (montoTotalAdeudado >= (decimal)SaludFinancieraEnum.PREMIUM) categoriaFinanciera = "GOLD PLUS";


                return new GetSaludFinancieraDto()
                {
                    Indicador = true,
                    Comentario = categoriaFinanciera,
                    MontoTotalAdeudado = montoTotalAdeudado
                };

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

        private IEnumerable<ReglaSaludFinancieraDto> getsaludFinancieraRegla()
        {
            ReglaSaludFinancieraDto[] regla = new ReglaSaludFinancieraDto[]
            {
                new ReglaSaludFinancieraDto(){ Descripcion = "BASICO" , Valor = 5000},
                new ReglaSaludFinancieraDto(){ Descripcion = "ESTANDAR" , Valor = 25000 },
                new ReglaSaludFinancieraDto(){ Descripcion = "INTERMEDIO" , Valor = 75000 },
                new ReglaSaludFinancieraDto(){ Descripcion = "PREMIUM" , Valor = 200000 },
                new ReglaSaludFinancieraDto(){ Descripcion = "GOLD PLUS" , Valor = 200000 }
            };

            return regla;

        }

    }
}
