using Datos.Models;
using Microsoft.AspNetCore.Mvc;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentacion.Controllers
{
    public class RelClienteTiendaController : Controller
    {
        myHelperClienteTienda ClienteTienda = new myHelperClienteTienda();
        public IActionResult Index()
        {

            ViewBag.toLista = ClienteTienda.ConsultaAlmacenada();
            var ListClienteTienda = ClienteTienda.ConsultarTienda();
            return View(ListClienteTienda);
        }       
        public IActionResult Create(RelClienteTiendum relCliente)
        {
            ClienteTienda.AgregarTiendaClientes(relCliente);
            return View();
        }
        public IActionResult Edit(int id)
        {
            RelClienteTiendum relCliente = ClienteTienda.ConsultTienda(id);
            return View(relCliente);
        }
        [HttpPost]
        public IActionResult Edit(RelClienteTiendum relCliente)
        {
            ClienteTienda.EditarTiendaClientes(relCliente);
            return View();
        }
        public IActionResult Delete(int id)
        {
            RelClienteTiendum relCliente= ClienteTienda.ConsultTienda(id);
            return View(relCliente);
        }
        [HttpPost]
        public IActionResult Delete(RelClienteTiendum relCliente)
        {
            ClienteTienda.EliminarTiendaClientes(relCliente);
            return View();
        }      

    }
}
