using Datos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Negocios;
using System.Diagnostics;

namespace Presentacion.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            myHelperData myData = new myHelperData();
            var ListCli = myData.ConsultarClientes();
            return View();
        }
        public IActionResult Create()
        {
           
            return View();
        }


        public IActionResult Privacy(Cliente cliente)
        {
            myHelperData myHelper = new myHelperData();
            myHelper.AgregarCliente(cliente);
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
