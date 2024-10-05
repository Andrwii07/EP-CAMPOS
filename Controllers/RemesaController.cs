using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EP_CAMPOS.Models;
using EP_CAMPOS.Data;
using EP_CAMPOS.ViewModels;

namespace EP_CAMPOS.Controllers
{
    public class RemesaController : Controller
    {
        private readonly ILogger<RemesaController> _logger;
        private readonly ApplicationDbContext _context;

        public RemesaController(ILogger<RemesaController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
           var misremesa = from o in _context.DataRemesa select o;
            _logger.LogDebug("remesa {misremesa}", misremesa);
            var viewModels = new RemesaViewModels
            {
                FormRemesa = new Remesa(),
                ListRemesa = misremesa
            };
            _logger.LogDebug("viewModels {viewModels}", viewModels);

            return View(viewModels);
        }

        [HttpPost]
        public IActionResult Crear(RemesaViewModels viewModels)
        {
            _logger.LogDebug("Ingreso a Crear Remesa");

            var remesa = new Remesa
            {
                NombreR = viewModels.FormRemesa.NombreR,
                NombreD = viewModels.FormRemesa.NombreD,
                Origen = viewModels.FormRemesa.Origen,
                Destino = viewModels.FormRemesa.Destino,
                Monto = viewModels.FormRemesa.Monto,
                TipoM = viewModels.FormRemesa.TipoM,
                Tasa = viewModels.FormRemesa.Tasa,
                MontoF = viewModels.FormRemesa.MontoF,
                EstadoT = viewModels.FormRemesa.EstadoT,
            };

            _context.Add(remesa);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Lista(){
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}