using AnalisisDBContext.Models;
using BusinessLogic;
using DTOs;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.Tests
{
    [TestFixture]
    public class DatosAnalisisTest {

        private DatosSujetoDTO datosIntroducidosMock;
        private List<ValoresAnalisis> valores; 
        private List<RelacionPatologiaAnalisis> relaciones; 
        private Patologia patologiaResult; 
        private Mock<IValoresAnalisisRepository> mockValoresAnalisisRepository;
        private Mock<IRelacionPatologiaAnalisisRepository> mockRelacionPatologiaAnalisisRepository;
        private Mock<IPatologiaRepository> mockPatologiaAnalisisRepository;

        [Test]
        public void testPostDatosAnalisisAndGetPatologias_IsNotNull()
        {
            //Arrange
            fillDatosIntroducidosMock();
            prepareMockRepositories();

            //Act
            DatosAnalisis datosAnalisisManager = new DatosAnalisis(mockValoresAnalisisRepository.Object,
                mockRelacionPatologiaAnalisisRepository.Object, mockPatologiaAnalisisRepository.Object);
            List<ShortResultDTO> result = datosAnalisisManager.postDatosAnalisisAndGetPatologias(datosIntroducidosMock);

            //Assert
            Assert.AreEqual(2, result.Count, "El método devuelve un número diferente de resultados al esperado");

        }

        [Test]
        public void testPostDatosAnalisisAndGetPatologias_IsOK()
        {
            //Arrange
            fillDatosIntroducidosMock();
            prepareMockRepositories();

            //Act
            DatosAnalisis datosAnalisisManager = new DatosAnalisis(mockValoresAnalisisRepository.Object,
                mockRelacionPatologiaAnalisisRepository.Object, mockPatologiaAnalisisRepository.Object);
            List<ShortResultDTO> result = datosAnalisisManager.postDatosAnalisisAndGetPatologias(datosIntroducidosMock);
            List<String> obtainedPatologia = new List<string>();
            foreach(ShortResultDTO currentResult in result)
            {
                if (currentResult.PatologiaId > 0)
                {
                    obtainedPatologia.Add(currentResult.PatologiaName);
                }
            }

            //Assert
            Assert.AreEqual(1, obtainedPatologia.Count, "El método devuelve un número diferente de resultados al esperado");
            Assert.AreEqual("Enfermedad cardíaca", obtainedPatologia[0], "El método no devuelve la patología esperada");


        }

        #region privateMethods

        private void fillDatosIntroducidosMock()
        {
            datosIntroducidosMock = new DatosSujetoDTO();
            datosIntroducidosMock.IsMale = false;
            datosIntroducidosMock.DatosObtenidos = new List<DatosAnalisisDTO>();

            DatosAnalisisDTO datoGlucosa = new DatosAnalisisDTO();
            datoGlucosa.ParametroId = 1;
            datoGlucosa.ParametroName = "Glucosa";
            datoGlucosa.ParametroValue = 25;
            datosIntroducidosMock.DatosObtenidos.Add(datoGlucosa);

            DatosAnalisisDTO datoColesterol = new DatosAnalisisDTO();
            datoColesterol.ParametroId = 2;
            datoColesterol.ParametroName = "Colesterol";
            datoColesterol.ParametroValue = 180;
            datosIntroducidosMock.DatosObtenidos.Add(datoColesterol);
        }

        private void fillVAloresAnalisisRepository()
        {
            valores = new List<ValoresAnalisis>();
            ValoresAnalisis valorGlucosa = new ValoresAnalisis();
            valorGlucosa.Id = 1;
            valorGlucosa.MaxMujer = 28;
            valorGlucosa.MinMujer = 5;
            valorGlucosa.MaxVaron = 25;
            valorGlucosa.MinVaron = 10;
            valorGlucosa.Parametro = "Glucosa";
            valores.Add(valorGlucosa);

            ValoresAnalisis valorColesterol = new ValoresAnalisis();
            valorColesterol.Id = 2;
            valorColesterol.MaxMujer = 150;
            valorColesterol.MinMujer = 115;
            valorColesterol.MaxVaron = 165;
            valorColesterol.MinVaron = 100;
            valorColesterol.Parametro = "Colesterol";
            valores.Add(valorColesterol);
        }

        private void fillRelacionesPatologiasMock()
        {
            relaciones = new List<RelacionPatologiaAnalisis>();
            RelacionPatologiaAnalisis relacion = new RelacionPatologiaAnalisis();
            relacion.IsMin = false;
            relacion.ParametroId = 2;
            relacion.PatologiaId = 1;
            relacion.RelacionId = 1;

            relaciones.Add(relacion);
        }

        private void fillPatologiaResultMock()
        {
            patologiaResult = new Patologia();
            patologiaResult.Nombre = "Enfermedad cardíaca";
            patologiaResult.Descripcion = "El elevado colesterol casa obstrucción de los vasos sanguíneos y paros cardiacos";
            patologiaResult.PatologiaId = 1;
            patologiaResult.Riesgos = "infarto";
            patologiaResult.Tratamiento = "medicamentos para diluir la sangre";
            patologiaResult.Recomendaciones = "acuda a su médico, haga ejercicio y coma más sano";
        }

        private void prepareMockRepositories()
        {
            mockValoresAnalisisRepository = new Mock<IValoresAnalisisRepository>();
            fillVAloresAnalisisRepository();
            mockValoresAnalisisRepository.Setup(mr => mr.GetValores()).Returns(valores);

            mockRelacionPatologiaAnalisisRepository = new Mock<IRelacionPatologiaAnalisisRepository>();
            fillRelacionesPatologiasMock();
            mockRelacionPatologiaAnalisisRepository.Setup(mr => mr.GetRelaciones()).Returns(relaciones);

            mockPatologiaAnalisisRepository = new Mock<IPatologiaRepository>();
            fillPatologiaResultMock();
            mockPatologiaAnalisisRepository.Setup(mr => mr.GetPatologiaByID(
                It.Is<int>(i=>i ==1))).Returns(patologiaResult);
        }

        #endregion
    }
}
