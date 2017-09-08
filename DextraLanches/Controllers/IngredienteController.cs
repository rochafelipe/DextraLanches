using DextraLanches.Models;
using DextraLanches.Models;
using DextraLanches.Service.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DextraLanches.Controllers
{
    public class IngredienteController : Controller
    {
        private IngredienteService IngredienteService;
        public IngredienteController()
        {
            this.IngredienteService = new IngredienteService();
        }
        //
        // GET: /Ingrediente/

        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new IngredienteViewModel();
            viewModel.Ingredientes = this.IngredienteService.Buscar().Cast<IngredienteModel>().ToList();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(IngredienteViewModel viewModel)
        {

            this.IngredienteService.Adicionar(viewModel.IngredienteNovo);
            TempData["tagMessage"] = "sucesso";
            TempData["message"] = "Registro salvo com sucesso!";

            viewModel.Ingredientes = this.IngredienteService.Buscar().Cast<IngredienteModel>().ToList();
            viewModel.IngredienteNovo = new Models.IngredienteModel();

            return View(viewModel);

        }
    }
}
