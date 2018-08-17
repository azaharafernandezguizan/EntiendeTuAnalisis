using System;
using System.Collections.Generic;

namespace AnalisisDBContext.Models
{
    public partial class ValoresAnalisis
    {
        public ValoresAnalisis()
        {
            RelacionPatologiaAnalisis = new HashSet<RelacionPatologiaAnalisis>();
        }

        public int Id { get; set; }
        public string Parametro { get; set; }
        public double? MaxMujer { get; set; }
        public double? MinMujer { get; set; }
        public double? MaxVaron { get; set; }
        public double? MinVaron { get; set; }

        public ICollection<RelacionPatologiaAnalisis> RelacionPatologiaAnalisis { get; set; }
    }
}
