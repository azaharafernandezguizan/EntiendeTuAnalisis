using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class ResultadoDTO
    {
        public ResultadoDTO()
        {

        }
        public int PatologiaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tratamiento { get; set; }
        public string Riesgos { get; set; }
        public string Recomendaciones { get; set; }
    }
}
