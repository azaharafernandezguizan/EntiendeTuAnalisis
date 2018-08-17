using AnalisisDBContext.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
     
    public interface IValoresAnalisisRepository : IDisposable
    {
        List<ValoresAnalisis> GetValores();
        ValoresAnalisis GetValorByID(int valorID);
        void InsertValor(ValoresAnalisis valor);
        void DeleteValor(int valorID);
        void UpdateValor(ValoresAnalisis valor);
        void Save();
    }
}
