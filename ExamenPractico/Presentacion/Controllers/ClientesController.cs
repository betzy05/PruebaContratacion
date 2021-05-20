using Datos.Models;
using Microsoft.AspNetCore.Mvc;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentacion.Controllers
{
    public class ClientesController : Controller
    {
        myHelperData myHelper = new myHelperData();
        public IActionResult Index()
        {          
            var ListCli = myHelper.ConsultarClientes();
            return View(ListCli);
        }
  
        public IActionResult Create(Cliente clientes)
        {         
            myHelper.AgregarCliente(clientes);
            return View();
        }
        //public IActionResult Detalles(int id)
        //
        //    myHelper.ConsulCliente(id);
        //    return View();
        //}
        public IActionResult Edit(int id)
        {
            Cliente cliente= myHelper.ConsulCliente(id);         
            return View(cliente);
        }
        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {       
            myHelper.EditarCliente(cliente);
            return View();
        }
        public IActionResult Delete(int id)
        {
            Cliente cliente = myHelper.ConsulCliente(id);
            return View(cliente);
        }
        [HttpPost]
        public IActionResult Delete(Cliente clientes)
        {     
            myHelper.EliminarClientes(clientes);
            return View();
        }

    }
}
