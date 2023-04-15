using Microsoft.AspNetCore.Mvc;
using PublicServices.Core.DTOs;
using PublicServices.Core.Entities;
using PublicServices.Services.Consult.Interfaces;

namespace PublicServices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultController : ControllerBase
    {
        private readonly IConsultService consultService;
        public ConsultController(IConsultService ConsultService)
        {
            consultService = ConsultService;
        }

        [HttpGet("tasa-cambiaria/{codigoMoneda}")]
        public async Task<ActionResult<GetTasaCambiariaDto>> TasaCambiaria(string codigoMoneda)
        {
            try
            {
                await consultService.SaveLog("tasa-cambiaria");

                var result = await consultService.GetTasaCambiaria(codigoMoneda);

                if (result == null)
                    return NotFound("Registro no encontrado");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); 
            }
        }

        [HttpGet("indice-inflacion/{periodo}")]
        public async Task<ActionResult<GetIndiceInflacionDto>> IndiceInflacion(string periodo)
        {
            try
            {
               await consultService.SaveLog("indice-inflacion");

                var result = await consultService.GetIndiceInflacion(periodo);

                if (result == null)
                    return NotFound("Registro no encontrado");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("salud-financiera/{identificador}")]
        public async Task<ActionResult<GetSaludFinancieraDto>> SaludFinanciera(string identificador)
        {
            try
            {
                await consultService.SaveLog("salud-financiera");

                var result = await consultService.GetSaludFinanciera(identificador);

                if (result == null)
                    return NotFound("Registro no encontrado");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("historial-crediticio/{identificador}")]
        public async Task<ActionResult<List<HistorialCrediticioDto>>> HistorialCrediticio(string identificador)
        {
            try
            {
                await consultService.SaveLog("historial-crediticio");

                var result = await consultService.GetHistorialCrediticio(identificador);

                if (result.Count == 0)
                    return NotFound("Registros no encontrados");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("request-log")]
        public async Task<ActionResult<List<RequestLog>>> RequestLog(DateTime? desde, DateTime? hasta)
        {
            try
            {
                var result = await consultService.GetRequestLogs(desde, hasta);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
