using AnalisisDBContext.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public interface IPatologiaRepository : IDisposable
    {
        List<Patologia> GetPatologias();
        Patologia GetPatologiaByID(int patologiaID);
        void InsertPatologia(Patologia patologia);
        void DeletePatologia(int patologiaID);
        void UpdatePatologia(Patologia patologia);
        void Save();
    }
}
