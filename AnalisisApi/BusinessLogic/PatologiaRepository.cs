using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnalisisDBContext.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic
{
    public class PatologiaRepository : IPatologiaRepository, IDisposable
    {
        private analisisschemaContext context;

        public PatologiaRepository(analisisschemaContext context)
        {
            this.context = context;
        }

        public List<Patologia> GetPatologias()
        {
            return context.Patologia.ToList();
        }

        public Patologia GetPatologiaByID(int id)
        {
            return context.Patologia.Find(id);
        }

        public void InsertPatologia(Patologia patologia)
        {
            context.Patologia.Add(patologia);
        }

        public void DeletePatologia(int patologiaID)
        {
            Patologia patologia = context.Patologia.Find(patologiaID);
            context.Patologia.Remove(patologia);
        }

        public void UpdatePatologia(Patologia patologia)
        {
            context.Entry(patologia).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
    }
}