using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DextraLanches.Models
{
    public class IngredienteViewModel
    {
        public IngredienteViewModel()
        {
            this.Ingredientes = new List<IngredienteModel>();
        }

        public IngredienteModel IngredienteNovo { get; set; }

        public List<IngredienteModel> Ingredientes { get; set; }

    }
}