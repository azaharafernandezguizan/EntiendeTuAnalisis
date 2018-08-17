using DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.IManager
{
    public interface IResultado
    {
        ResultadoDTO getResultadoByPatologia(int patologiaID);

        List<DatosCompletosDTO> GetDatosCompletosDTO();
    }
}
