using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DextraLanches.Models
{
    public class LancheViewModel
    {

        public LancheViewModel()
        {
            this.ListaLanches = new List<LancheModel>();
            this.IngredientesDisponiveis = new List<IngredienteModel>();
            this.NovoLanche = new LancheModel();
        }

        public LancheModel NovoLanche { get; set; }

        public List<LancheModel> ListaLanches { get; set; }

        public List<IngredienteModel> IngredientesDisponiveis { get; set; }

    }
}