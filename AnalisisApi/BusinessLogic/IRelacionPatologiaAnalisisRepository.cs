using AnalisisDBContext.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public interface IRelacionPatologiaAnalisisRepository : IDisposable
    {
        List<RelacionPatologiaAnalisis> GetRelaciones();
        RelacionPatologiaAnalisis GetRelacionByID(int relacionID);
        void InsertRelacion(RelacionPatologiaAnalisis relacion);
        void DeleteRelacion(int relacionID);
        void UpdateRelacion(RelacionPatologiaAnalisis relacion);
        void Save();
    }
}
