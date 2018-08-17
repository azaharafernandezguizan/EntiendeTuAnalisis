using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class DatosCompletosDTO
    {
        public DatosCompletosDTO()
        {

        }
        
        public string ParametroName { get; set; }
        public double? minValueMale { get; set; }
        public double? maxValueMale { get; set; }
        public double? minValueFemale { get; set; }
        public double? maxValueFemale { get; set; }
        public bool IsMin { get; set; }
        public string PatologiaName { get; set; }
        public string PatologiaDescription { get; set; }
        public string Tratamiento { get; set; }
        public string Riesgos { get; set; }
        public string Recomendaciones { get; set; }
    }
}
