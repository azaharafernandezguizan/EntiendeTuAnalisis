using AnalisisDBContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
   public class ValoresAnalisisRepository : IValoresAnalisisRepository, IDisposable
    {
        private analisisschemaContext context;

        public ValoresAnalisisRepository(analisisschemaContext context)
        {
            this.context = context;
        }

        public List<ValoresAnalisis> GetValores()
        {
            return context.ValoresAnalisis.ToList();
        }

        public ValoresAnalisis GetValorByID(int id)
        {
            return context.ValoresAnalisis.Find(id);
        }

        public void InsertValor(ValoresAnalisis valor)
        {
            context.ValoresAnalisis.Add(valor);
        }

        public void DeleteValor(int valorID)
        {
            ValoresAnalisis valor = context.ValoresAnalisis.Find(valorID);
            context.ValoresAnalisis.Remove(valor);
        }

        public void UpdateValor(ValoresAnalisis valor)
        {
            context.Entry(valor).State = EntityState.Modified;
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
