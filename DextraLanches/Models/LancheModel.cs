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
        }

        public List<IngredienteModel> ListaIngredientes { get; set; }
        public string Ingredientes { get; set; }

        public long IngredienteSelecionado { get; set; }

        public decimal Preco
        {
            get
            {
                return ListaIngredientes.Sum(i => i.Preco);
            }
        }

        public List<PromocaoModel> Promocoes { get; set; }
    }
}