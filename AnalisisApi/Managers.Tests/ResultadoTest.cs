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
    public class ResultadoTest
    {
        private Mock<IPatologiaRepository> mockPatologiaAnalisisRepository;
        private Mock<IRelacionPatologiaAnalisisRepository> mockRelacionRepository;
        private List<Patologia> patologiaResult;
        private List<RelacionPatologiaAnalisis> relacionResult;

        [Test]
        public void testResultado_notNull()
        {
            //Arrange
            int patologiaID = 1;
            prepareMockRepositories();

            //Act
            Resultado resultadoManager = new Resultado(mockPatologiaAnalisisRepository.Object, mockRelacionRepository.Object);
            ResultadoDTO result = resultadoManager.getResultadoByPatologia(patologiaID);

            //Assert
            Assert.IsTrue(result != null, "El resultado es nulo");
        }

        [Test]
        public void testResultado_isOK()
        {
            //Arrange
            int patologiaID = 1;
            prepareMockRepositories();

            //Act
            Resultado resultadoManager = new Resultado(mockPatologiaAnalisisRepository.Object, mockRelacionRepository.Object);
            ResultadoDTO result = resultadoManager.getResultadoByPatologia(patologiaID);

            //Assert
            Assert.AreEqual("Enfermedad cardíaca", result.Nombre, "El resultado no es el esperado");
        }

        [Test]
        public void testGetAllData_notNull()
        {
            //Arrange
            prepareMockRepositories();

            //Act
            Resultado resultadoManager = new Resultado(mockPatologiaAnalisisRepository.Object, mockRelacionRepository.Object);
            List<DatosCompletosDTO> result = resultadoManager.GetDatosCompletosDTO();

            //Assert
            Assert.IsTrue(result != null, "El resultado es nulo");
        }

        [Test]
        public void testGetAllData_isOK()
        {
            //Arrange
            prepareMockRepositories();

            //Act
            Resultado resultadoManager = new Resultado(mockPatologiaAnalisisRepository.Object, mockRelacionRepository.Object);
            List<DatosCompletosDTO> result = resultadoManager.GetDatosCompletosDTO();

            //Assert
            Assert.IsTrue(result.Count > 0, "La lista contiene 0 elementos");
            Assert.AreEqual("colesterol", result[0].ParametroName, "El resultado no es el esperado");
        }

        #region privateMethods

        private void fillPatologiaResultMock()
        {
            patologiaResult = new List<Patologia>();

            Patologia currentPatologia = new Patologia();
            currentPatologia.Nombre = "Enfermedad cardíaca";
            currentPatologia.Descripcion = "El elevado colesterol casa obstrucción de los vasos sanguíneos y paros cardiacos";
            currentPatologia.PatologiaId = 1;
            currentPatologia.Riesgos = "infarto";
            currentPatologia.Tratamiento = "medicamentos para diluir la sangre";
            currentPatologia.Recomendaciones = "acuda a su médico, haga ejercicio y coma más sano";

            patologiaResult.Add(currentPatologia);
        }

        private void fillRelacionMock()
        {
            relacionResult = new List<RelacionPatologiaAnalisis>();

            RelacionPatologiaAnalisis relacion = new RelacionPatologiaAnalisis();
            relacion.IsMin = true;
            relacion.Parametro = new ValoresAnalisis();
            relacion.Parametro.Parametro = "colesterol";
            relacion.Parametro.Id = 1;
            relacion.Parametro.MinMujer = 5;
            relacion.Parametro.MinVaron = 8;
            relacion.Patologia = new Patologia();
            relacion.Patologia.PatologiaId = 1;
            relacion.Patologia.Nombre = "Insuficiencia cardiaca";
            relacion.Patologia.Descripcion = "El colesterol obstruye los vasos sanguíneos";
            relacion.Patologia.Recomendaciones = "Mantenga una dieta equilibrada y haga ejercicio";
            relacion.Patologia.Tratamiento = "pastillas y dieta";
            relacion.Patologia.Riesgos = "Infarto de miocardio";
            relacion.RelacionId = 1;
            relacion.ParametroId = 1;
            relacion.PatologiaId = 1;

            relacionResult.Add(relacion);
        }

        private void prepareMockRepositories()
        {
            mockPatologiaAnalisisRepository = new Mock<IPatologiaRepository>();
            fillPatologiaResultMock();
            mockPatologiaAnalisisRepository.Setup(mr => mr.GetPatologias()).Returns(patologiaResult);

            mockRelacionRepository = new Mock<IRelacionPatologiaAnalisisRepository>();
            fillRelacionMock();
            mockRelacionRepository.Setup(rr => rr.GetRelaciones()).Returns(relacionResult);
        }

        #endregion
    }
}
