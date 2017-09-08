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

        [HttpGet]
        public ActionResult Index()
        {

            var viewModel = new LancheViewModel();

            viewModel.ListaLanches = this.LancheService.Buscar().Cast<LancheModel>().ToList();
            viewModel.IngredientesDisponiveis = this.IngredienteService.Buscar().Cast<IngredienteModel>().ToList();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(LancheViewModel viewModel)
        {
            var ret = viewModel;

             char[] charSep = new char[] {'|'};
            var IngredientesSplit = viewModel.NovoLanche.Pedido.Split(charSep, StringSplitOptions.RemoveEmptyEntries);
            var IngredientesIDs = new List<long>();

            foreach (var ingrediente in IngredientesSplit)
            {
                IngredientesIDs.Add(long.Parse(ingrediente));
            }

            //Montar o lanche a partir dos ingredientes.
            var lancheMontado = this.LancheService.MontarLanche(IngredientesIDs);

            lancheMontado.Nome = viewModel.NovoLanche.Nome;
            lancheMontado.Descricao = viewModel.NovoLanche.Descricao;

            this.LancheService.Adicionar(lancheMontado);

            TempData["tagMessage"] = "sucesso";
            TempData["message"] = "Registro salvo com sucesso.";

            return RedirectToAction("Index");
        }

    }
}
