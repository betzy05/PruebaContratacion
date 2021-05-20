using Datos.Context;
using Datos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocios
{
    public class myHelperClienteTienda
    {
        protected SecContext myContext;
        public myHelperClienteTienda()
        {
            myContext = new SecContext();
        }
        public List<RelClienteTiendum> ConsultarTienda()
        {
            var MyList = myContext.RelClienteTienda.Include(a => a.IdClienteNavigation).Include(a => a.IdTiendaNavigation);
            return MyList.ToList();
        }
        public RelClienteTiendum ConsultTienda(int id)
        {
            RelClienteTiendum relCliente = myContext.RelClienteTienda.Where(a => a.idRel==id).FirstOrDefault();
            //RelClienteTiendum relCliente = myContext.RelClienteTienda.Find(id);
            return relCliente;
        }
        
        public RelClienteTiendum AgregarTiendaClientes(RelClienteTiendum relCliente)
        {
            myContext.RelClienteTienda.Add(relCliente);
            myContext.SaveChanges();
            return relCliente;
        }
        public RelClienteTiendum EditarTiendaClientes(RelClienteTiendum relCliente)
        {
            myContext.Entry(relCliente).State = EntityState.Modified;
            myContext.SaveChanges();
            return relCliente;
        }
        public RelClienteTiendum EliminarTiendaClientes(RelClienteTiendum relCliente)
        {
            myContext.RelClienteTienda.Remove(relCliente);
            myContext.SaveChanges();
            return relCliente;
        }
        public myStoreProcedure ConsultaAlmacenada()
        {
            //var lis = myContext.RelClienteTienda.FromSqlRaw("execute sp_MaxCompras").ToList();
            //var lis = myContext.Database.ExecuteSqlRaw("execute sp_MaxCompras");
            var lis = myContext.MyProcedure.FromSqlRaw("execute sp_MaxCompras").ToList().FirstOrDefault();

            //RelClienteTiendum relCliente = myContext.RelClienteTienda.Find(id);
            return lis;
        }

    }
}
