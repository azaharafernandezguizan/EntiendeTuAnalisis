using AnalisisDBContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{

    public class RelacionPatologiaAnalisisRepository : IRelacionPatologiaAnalisisRepository, IDisposable
    {
        private analisisschemaContext context;

        public RelacionPatologiaAnalisisRepository(analisisschemaContext context)
        {
            this.context = context;
        }

        public List<RelacionPatologiaAnalisis> GetRelaciones()
        {
            return context.RelacionPatologiaAnalisis
                .Include("Patologia").Include("Parametro").ToList();
        }

        public RelacionPatologiaAnalisis GetRelacionByID(int id)
        {
            return context.RelacionPatologiaAnalisis.Find(id);
        }

        public void InsertRelacion(RelacionPatologiaAnalisis relacion)
        {
            context.RelacionPatologiaAnalisis.Add(relacion);
        }

        public void DeleteRelacion(int relacionID)
        {
            RelacionPatologiaAnalisis patologia = context.RelacionPatologiaAnalisis.Find(relacionID);
            context.RelacionPatologiaAnalisis.Remove(patologia);
        }

        public void UpdateRelacion(RelacionPatologiaAnalisis relacion)
        {
            context.Entry(relacion).State = EntityState.Modified;
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
