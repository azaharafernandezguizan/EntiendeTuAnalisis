using DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.IManager
{
    public interface IDatosAnalisis
    {
        List<ShortResultDTO> postDatosAnalisisAndGetPatologias(DatosSujetoDTO datosSujeto);
    }
}
