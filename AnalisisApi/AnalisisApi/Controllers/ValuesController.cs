using System;
using System.Collections.Generic;
using DTOs;
using Managers;
using Managers.IManager;
using Microsoft.AspNetCore.Mvc;

namespace AnalisisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        public IDatosAnalisis datosManager = new DatosAnalisis();
        public IResultado resultadoManager = new Resultado();

        [HttpGet]
        public ActionResult<String> GetDefault()
        {
            return "Bienvenido a AnalisisApi";
        }

        [HttpGet("getResultado/{patologiaId}")]
        [ProducesResponseType(typeof(ResultadoDTO), 200)]
        public ActionResult<ResultadoDTO> GetResultadoByPatologiaId(int patologiaId)
        {
            ResultadoDTO result = resultadoManager.getResultadoByPatologia(patologiaId);

            return result;
        }

        [HttpGet("getAllData")]
        [ProducesResponseType(typeof(ResultadoDTO), 200)]
        public ActionResult<List<DatosCompletosDTO>> GetAllData()
        {
            List<DatosCompletosDTO> result = resultadoManager.GetDatosCompletosDTO();

            return result;
        }

        /// <summary>
        /// Receives the analisis data and evaluates them.
        /// </summary>
        [HttpPost]
        public ActionResult<List<ShortResultDTO>> TestValoresAnalisis(DatosSujetoDTO datosSujeto)
        {
            List<ShortResultDTO> results = datosManager.postDatosAnalisisAndGetPatologias(datosSujeto);

            return results;
        }




    }
}
