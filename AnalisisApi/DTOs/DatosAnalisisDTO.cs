using System;
using System.Collections.Generic;

namespace DTOs
{
    public class DatosAnalisisDTO
    {
        public DatosAnalisisDTO()
        {

        }

        public int ParametroId { get; set; }
        public string ParametroName { get; set; }
        public double ParametroValue { get; set; }
        public bool isLow { get; set; }
        public bool isHigh { get; set; }
        public int PatologiaId { get; set; }
    }
}
