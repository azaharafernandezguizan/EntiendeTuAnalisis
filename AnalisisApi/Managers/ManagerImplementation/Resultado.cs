using AnalisisDBContext.Models;
using BusinessLogic;
using DTOs;
using Managers.IManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Managers
{
    public class Resultado : IResultado
    {
        public IPatologiaRepository patologiaRepository;
        public IRelacionPatologiaAnalisisRepository relacionRepository;

        public Resultado()
        {
            this.patologiaRepository = new PatologiaRepository(new analisisschemaContext());
            this.relacionRepository = new RelacionPatologiaAnalisisRepository(new analisisschemaContext());
        }

        public Resultado(IPatologiaRepository patologiaRepository, IRelacionPatologiaAnalisisRepository relacionRepository)
        {
            this.patologiaRepository = patologiaRepository;
            this.relacionRepository = relacionRepository;
        }

        public ResultadoDTO getResultadoByPatologia(int patologiaID)
        {
            List<Patologia> patologias = patologiaRepository.GetPatologias();

            Patologia patologia = patologias.Where(p => p.PatologiaId == patologiaID).FirstOrDefault();

            ResultadoDTO result = null;
            if(patologia!= null)
            {
                result = new ResultadoDTO();
                result.PatologiaId = patologiaID;
                result.Nombre = patologia.Nombre;
                result.Descripcion = patologia.Descripcion;
                result.Recomendaciones = patologia.Recomendaciones;
                result.Riesgos = patologia.Riesgos;
            }

            return result;
        }

        public List<DatosCompletosDTO> GetDatosCompletosDTO()
        {
            List<DatosCompletosDTO> result = new List<DatosCompletosDTO>();
            List<RelacionPatologiaAnalisis> relaciones = relacionRepository.GetRelaciones();

            foreach(RelacionPatologiaAnalisis relacion in relaciones)
            {
                DatosCompletosDTO currentResult = new DatosCompletosDTO();
                currentResult.ParametroName = relacion.Parametro.Parametro;

                currentResult.IsMin = relacion.IsMin.Value;
                if (currentResult.IsMin)
                {
                    currentResult.minValueFemale = relacion.Parametro.MinMujer;
                    currentResult.minValueMale = relacion.Parametro.MinVaron;
                }
                else
                {
                    currentResult.maxValueFemale = relacion.Parametro.MaxMujer;
                    currentResult.maxValueMale = relacion.Parametro.MaxVaron;
                }

                currentResult.PatologiaName = relacion.Patologia.Nombre;
                currentResult.PatologiaDescription = relacion.Patologia.Descripcion;
                currentResult.Recomendaciones = relacion.Patologia.Recomendaciones;
                currentResult.Riesgos = relacion.Patologia.Riesgos;
                currentResult.Tratamiento = relacion.Patologia.Tratamiento;

                result.Add(currentResult);
            }


            return result;
        }
    }
}
