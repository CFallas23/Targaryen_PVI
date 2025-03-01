using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Targaryen_PVI.Models;

namespace Targaryen_PVI.Controllers
{
    public class HomeController : Controller
    {
        private readonly AccesoDatos _datos;
        private readonly ILogger<HomeController> _logger;

        // Constructor con ambas dependencias inyectadas correctamente
        public HomeController(AccesoDatos datos, ILogger<HomeController> logger)
        {
            _datos = datos;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Ingresar(Pedidos pedido)
        {
            if (!ModelState.IsValid)
            {
                {
                    return View();                    
                }
            }
            else 
            { 
                try
                {
                    _datos.IngresarPedido(pedido);
                    TempData["SuccessMessage"] = "Tu pedido se guardo con exito.";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "Tu pedido no se guardó. Error: " + ex.Message;
                    return RedirectToAction("Index");
                }
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
