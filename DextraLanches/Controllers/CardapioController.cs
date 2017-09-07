using DextraLanches.Models;
using DextraLanches.Models.Abstraction;
using DextraLanches.Service.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DextraLanches.Controllers
{
    public class CardapioController : Controller
    {

        public CardapioController(){
            if (CardapioService == null)
                CardapioService = new CardapioService();

            this.LancheService = new LancheService();
            this.IngredienteService = new IngredienteService();
            this.PedidoService = new PedidoService();
            
        }
        //
        // GET: /Cardapio/
        private CardapioService CardapioService;
        private LancheService LancheService;
        private IngredienteService IngredienteService;
        private PedidoService PedidoService;

        [HttpGet]
        public ActionResult Index()
        {

            var viewModel = new CardapioViewModel();
            viewModel.ListaCardapios =  CardapioService.Buscar().Cast<CardapioModel>().ToList();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(CardapioViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            this.CardapioService.Adicionar(viewModel.CardapioNovo);

            TempData["tagMessage"] = "sucesso";
            TempData["message"] = "Registro salvo com sucesso!";

            viewModel.ListaCardapios = this.CardapioService.Buscar().Cast<CardapioModel>().ToList();

            return View(viewModel);
        }

        public ActionResult CardapioCliente()
        {

            var viewModel = new LancheViewModel();

            viewModel.ListaLanches = this.LancheService.Buscar().Cast<LancheModel>().ToList();
            viewModel.IngredientesDisponiveis = this.IngredienteService.Buscar().Cast<IngredienteModel>().ToList();
            return View(viewModel);
        }

        public ActionResult Comprar(long id)
        {
            var lanche = this.LancheService.Buscar(id);
            var pedido = new PedidoModel();
            pedido.Lanches.Add((LancheModel)lanche);
            this.PedidoService.Adicionar(pedido);

            TempData["tagMessage"] = "sucesso";
            TempData["message"] = "Pedido salvo, continue comprando ou Confirme seu pedido!";

            return RedirectToAction("Index", "Pedido");
        }

        public JsonResult buscarIngrediente(string ID)
        {
            JsonResult resultado = new JsonResult();

            resultado.Data = this.IngredienteService.Buscar(long.Parse(ID));
            resultado.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return resultado;
        }

        public JsonResult finalizarPedido(string Pedido)
        {
            JsonResult resultado = new JsonResult();

            char[] charSep = new char[] {'|'};
            var IngredientesSplit = Pedido.Split(charSep, StringSplitOptions.RemoveEmptyEntries);
            var IngredientesIDs = new List<long>();

            foreach (var ingrediente in IngredientesSplit)
            {
                IngredientesIDs.Add(long.Parse(ingrediente));
            }

            //Montar o lanche a partir dos ingredientes.
            var lancheMontado = this.LancheService.MontarLanche(IngredientesIDs);

            //Cria um pedido
            var pedido = new PedidoModel();

            pedido.Lanches.Add(lancheMontado);

            TempData["tagMessage"] = "sucesso";
            TempData["message"] = "Pedido salvo, continue comprando ou Confirme seu pedido!";
            this.PedidoService.Adicionar(pedido);

            resultado.Data = "Sucesso";
            resultado.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return resultado;
        }

    }
}
