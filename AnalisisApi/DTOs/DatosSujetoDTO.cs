using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class DatosSujetoDTO
    {
        public DatosSujetoDTO()
        {

        }

        public List<DatosAnalisisDTO> DatosObtenidos { get; set; }
        public bool IsMale { get; set; }
    }
}
