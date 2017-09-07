using DextraLanches.Models;
using DextraLanches.Service.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DextraLanches.Controllers
{
    public class PedidoController : Controller
    {
        private PedidoService PedidoService;

        public PedidoController()
        {
            this.PedidoService = new PedidoService();
        }


        //
        // GET: /Pedido/

        public ActionResult Index()
        {

            var viewModel = new PedidoViewModel();

            viewModel.Pedidos = this.PedidoService.Buscar().Cast<PedidoModel>().ToList();

            return View(viewModel);
        }

        public ActionResult RemoverItem(long id)
        {

            this.PedidoService.Remover(id);
            TempData["tagMessage"] = "sucesso";
            TempData["message"] = "Registro salvo com sucesso!";
            return RedirectToAction("Index");

        }

    }
}
