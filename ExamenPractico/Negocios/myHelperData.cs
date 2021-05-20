using Datos.Context;
using Datos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocios
{
    public class myHelperData
    {
        protected SecContext myContext;
        public myHelperData()
        {
            myContext = new SecContext();
        }

        public List<Cliente> ConsultarClientes() {
            var MyList = myContext.Clientes.ToList();
            return MyList;
        }
        public Cliente ConsulCliente(int id)
        {
            Cliente clientes = myContext.Clientes.Find(id);
            return clientes;
        }
        public Cliente AgregarCliente(Cliente clientes)
        {
            myContext.Clientes.Add(clientes);
            myContext.SaveChanges();
            return clientes;
        }
        public Cliente EditarCliente(Cliente cliente)
        {
            myContext.Entry(cliente).State = EntityState.Modified;         
            myContext.SaveChanges();
            return cliente;
        }
        public Cliente EliminarClientes(Cliente cliente)
        {
            myContext.Clientes.Remove(cliente);
            myContext.SaveChanges();
            return cliente;
        }


    }

}

