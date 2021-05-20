using Datos.Models;
using Microsoft.AspNetCore.Mvc;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentacion.Controllers
{
    public class TiendaController : Controller
    {
        myHelperTienda myHelperTienda = new myHelperTienda();

        public IActionResult Index()
        {
            var ListTienda = myHelperTienda.ConsultarTiendas();
            return View(ListTienda);
        }
        public IActionResult Create(Tiendum tienda)
        {
            myHelperTienda.AgregarTienda(tienda);
            return View();
        }      
        public IActionResult Edit(int id)
        {
            Tiendum tienda = myHelperTienda.ConsultarTienda(id);
            return View(tienda);
        }
        [HttpPost]
        public IActionResult Edit(Tiendum tienda)
        {
            myHelperTienda.EditarTienda(tienda);
            return View();
        }
        public IActionResult Delete(int id)
        {
            Tiendum tienda = myHelperTienda.ConsultarTienda(id);
            return View(tienda);
        }
        [HttpPost]
        public IActionResult Delete(Tiendum tienda)
        {
            myHelperTienda.EditarTienda(tienda);
            return View();
        }
    }
}
