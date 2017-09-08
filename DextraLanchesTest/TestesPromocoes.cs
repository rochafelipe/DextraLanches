using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DextraLanches.Logic.Implements;
using DextraLanches.Models;
using System.Collections.Generic;
using System.Linq;
namespace DextraLanchesTest
{
    [TestClass]
    public class TestesPromocoes
    {
        [TestMethod]
        public void PromocaoLight()
        {

            var expected = 10;
            var result = 100;
            
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void PromocaoMuitoQueijo ()
        {

            var expected = 10;
            var result = 100;

            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void PromocaoMuitaCarne()
        {
            //Alface 1
            //Bacon 2
            //Hamburguer 3
            //ovo 4
            //Queijo 5
            var expected = 6;
            var valorCarne = 3;
            PromocaoLogic PromocaoLogic = new PromocaoLogic();
            IngredienteLogic IngredienteLogic = new DextraLanches.Logic.Implements.IngredienteLogic();
            LancheModel model = new LancheModel();
            List<IngredienteModel> ingredientes = new List<IngredienteModel>();
            ingredientes = IngredienteLogic.Buscar().Cast<IngredienteModel>().ToList();

            model.ListaIngredientes.Add(new IngredienteModel()
                {
                    Nome = "Hambúrguer de carne",
                    Descricao = "Hambúrguer de carne",
                    ID = 3,
                    Preco = 3.00M
                });
            model.ListaIngredientes.Add(new IngredienteModel()
            {
                Nome = "Hambúrguer de carne",
                Descricao = "Hambúrguer de carne",
                ID = 3,
                Preco = 3.00M
            });
            model.ListaIngredientes.Add(new IngredienteModel()
            {
                Nome = "Hambúrguer de carne",
                Descricao = "Hambúrguer de carne",
                ID = 3,
                Preco = 3.00M
            });
      
            model = (LancheModel)PromocaoLogic.BuscarPorLanche(model);

            var result = PromocaoLogic.TCalcularDescontoMuitaCarne((LancheModel)model, valorCarne);
            


            Assert.AreEqual(expected, result);

        }

      
    }
}
