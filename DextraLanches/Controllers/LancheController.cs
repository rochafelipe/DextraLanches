using DextraLanches.Models;
using DextraLanches.Service.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DextraLanches.Controllers
{
    public class LancheController : Controller
    {
        //
        // GET: /Lanche/
        private LancheService LancheService;
        private IngredienteService IngredienteService;

        public LancheController()
        {
            this.IngredienteService = new IngredienteService();
            this.LancheService = new LancheService();
        }

        public ActionResult Index()
        {

            var viewModel = new LancheViewModel();

            viewModel.ListaLanches = this.LancheService.Buscar().Cast<LancheModel>().ToList();
            viewModel.IngredientesDisponiveis = this.IngredienteService.Buscar().Cast<IngredienteModel>().ToList();
            return View(viewModel);
        }

    }
}
