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
        }
        //
        // GET: /Cardapio/
        private CardapioService CardapioService;

        public ActionResult Index()
        {
            this.CardapioService.Adicionar(new CardapioModel() {
             Nome = "A",
             Descricao="AA",
             ID = 1
            });

            this.CardapioService.Adicionar(new CardapioModel()
            {
                Nome = "B",
                Descricao = "BB",
                ID = 2
            });
            
            //model.Add(new CardapioModel()
            //{
            //    Nome = "Cardápio Dia",
            //    Descricao = "Cardápio válido das 10 ás 16:00hs"
            //});
            //model.Add(new CardapioModel()
            //{
            //    Nome = "Cardápio Noite",
            //    Descricao = "Cardápio válido das 18 ás 22:00hs"
            //});
            var model = CardapioService.Buscar().Cast<CardapioModel>().ToList();
            return View(model);
        }

    }
}
