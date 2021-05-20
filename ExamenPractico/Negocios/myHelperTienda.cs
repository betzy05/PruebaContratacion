using Datos.Context;
using Datos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocios
{
    public class myHelperTienda
    {
        protected SecContext myContext;
        public myHelperTienda()
        {
            myContext = new SecContext();
        }

        public List<Tiendum> ConsultarTiendas()
        {
            var MyList = myContext.Tienda.ToList();
            return MyList;
        }
        public Tiendum ConsultarTienda(int id)
        {
            Tiendum tienda = myContext.Tienda.Find(id);
            return tienda;
        }
        public Tiendum AgregarTienda(Tiendum tienda)
        {
            myContext.Tienda.Add(tienda);
            myContext.SaveChanges();
            return tienda;
        }
        public Tiendum EditarTienda(Tiendum tienda)
        {
            myContext.Entry(tienda).State = EntityState.Modified;
            myContext.SaveChanges();
            return tienda;
        }
        public Tiendum EliminarTienda(Tiendum tienda)
        {
            myContext.Tienda.Remove(tienda);
            myContext.SaveChanges();
            return tienda;
        }


    }
}

