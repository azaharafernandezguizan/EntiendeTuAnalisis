using AnalisisDBContext.Models;
using BusinessLogic;
using DTOs;
using Managers.IManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Managers
{
    public class DatosAnalisis : IDatosAnalisis
    {
        IValoresAnalisisRepository valoresRepository = new ValoresAnalisisRepository(new analisisschemaContext());
        IRelacionPatologiaAnalisisRepository relacionRepository = new RelacionPatologiaAnalisisRepository(new analisisschemaContext());
        IPatologiaRepository patologiaRepository = new PatologiaRepository(new analisisschemaContext());

        public DatosAnalisis()
        {
            valoresRepository = new ValoresAnalisisRepository(new analisisschemaContext());
            relacionRepository = new RelacionPatologiaAnalisisRepository(new analisisschemaContext());
            patologiaRepository = new PatologiaRepository(new analisisschemaContext());
        }

        public DatosAnalisis(IValoresAnalisisRepository valoresRepository,
            IRelacionPatologiaAnalisisRepository relacionRepository, IPatologiaRepository patologiaRepository)
        {
            this.valoresRepository = valoresRepository;
            this.relacionRepository = relacionRepository;
            this.patologiaRepository = patologiaRepository;
        }

        public List<ShortResultDTO> postDatosAnalisisAndGetPatologias(DatosSujetoDTO datosSujeto)
        {
            List<ValoresAnalisis> valores = valoresRepository.GetValores();

            List<RelacionPatologiaAnalisis> relaciones = relacionRepository.GetRelaciones();

            datosSujeto.DatosObtenidos = datosSujeto.IsMale ? testMaleParameters(datosSujeto.DatosObtenidos, valores, relaciones) : testFemaleParameters(datosSujeto.DatosObtenidos, valores, relaciones);

            List<ShortResultDTO> shortResults = new List<ShortResultDTO>();

            foreach(DatosAnalisisDTO dato in datosSujeto.DatosObtenidos)
            {
                ShortResultDTO result = new ShortResultDTO();

                Patologia patologia = patologiaRepository.GetPatologiaByID(dato.PatologiaId);
                if (patologia != null)
                {
                    result.PatologiaId = patologia.PatologiaId;
                    result.PatologiaName = patologia.Nombre;
                }
                
                shortResults.Add(result);
            }

            return shortResults;
        }
       
        private List<DatosAnalisisDTO> testFemaleParameters(List<DatosAnalisisDTO> datos, List<ValoresAnalisis> valores, List<RelacionPatologiaAnalisis> relaciones)
        {
            foreach (DatosAnalisisDTO dato in datos)
            {
                var valorAnalisisDato = valores.Where(p => p.Parametro == dato.ParametroName).FirstOrDefault();
                bool isPatology = false;

                if (dato.ParametroValue > valorAnalisisDato.MaxMujer)
                {
                    dato.isHigh = true;
                    isPatology = true;
                }
                else if (dato.ParametroValue < valorAnalisisDato.MinMujer)
                {
                    dato.isLow = true;
                    isPatology = true;
                }

                if (isPatology)
                {
                    dato.PatologiaId = relaciones.Where(r => r.ParametroId == valorAnalisisDato.Id && r.IsMin == dato.isLow).FirstOrDefault().PatologiaId;
                }
            }

            return datos;
        }


        private List<DatosAnalisisDTO> testMaleParameters(List<DatosAnalisisDTO> datos, List<ValoresAnalisis> valores, List<RelacionPatologiaAnalisis> relaciones)
        {
            foreach (DatosAnalisisDTO dato in datos)
            {
                var valorAnalisisDato = valores.Where(p => p.Parametro == dato.ParametroName).FirstOrDefault();
                bool isPatology = false;

                if (dato.ParametroValue > valorAnalisisDato.MaxVaron)
                {
                    dato.isHigh = true;
                    isPatology = true;
                }
                else if (dato.ParametroValue < valorAnalisisDato.MinVaron)
                {
                    dato.isLow = true;
                    isPatology = true;
                }

                if (isPatology)
                {
                    dato.PatologiaId = relaciones.Where(r => r.ParametroId == valorAnalisisDato.Id && r.IsMin == dato.isLow).FirstOrDefault().PatologiaId;
                }

            }

            return datos;
        }
    }
}
