using DextraLanches.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DextraLanches.Models
{
    public class LancheModel : BaseModel
    {
        public LancheModel()
        {
            this.ListaIngredientes = new List<IngredienteModel>();
            this.Promocoes = new List<PromocaoModel>();
            this.PromocaoUtilizada = new PromocaoModel();
        }

        public List<IngredienteModel> ListaIngredientes { get; set; }
        public string Ingredientes { get; set; }

        public long IngredienteSelecionado { get; set; }

        //Representa a lista de ingredientes pedidos
        public string Pedido { get; set; }
       
        public decimal PrecoPromocional{get;set;}

        public decimal Preco
        {
            get
            {
                return this.ListaIngredientes.Sum(i => i.Preco);
            }
        }

        public List<PromocaoModel> Promocoes { get; set; }

        public PromocaoModel PromocaoUtilizada { get; set; }

        public bool ContemPromocao { get; set; }
    }
}