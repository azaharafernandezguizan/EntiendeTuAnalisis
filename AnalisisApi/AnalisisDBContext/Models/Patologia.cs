using System;
using System.Collections.Generic;

namespace AnalisisDBContext.Models
{
    public partial class Patologia
    {
        public Patologia()
        {
            RelacionPatologiaAnalisis = new HashSet<RelacionPatologiaAnalisis>();
        }

        public int PatologiaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tratamiento { get; set; }
        public string Riesgos { get; set; }
        public string Recomendaciones { get; set; }

        public ICollection<RelacionPatologiaAnalisis> RelacionPatologiaAnalisis { get; set; }
    }
}
