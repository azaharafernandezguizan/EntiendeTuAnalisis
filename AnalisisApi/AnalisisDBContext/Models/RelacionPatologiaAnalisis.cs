using System;
using System.Collections.Generic;

namespace AnalisisDBContext.Models
{
    public partial class RelacionPatologiaAnalisis
    {
        public int RelacionId { get; set; }
        public int PatologiaId { get; set; }
        public int ParametroId { get; set; }
        public bool? IsMin { get; set; }

        public ValoresAnalisis Parametro { get; set; }
        public Patologia Patologia { get; set; }
    }
}
