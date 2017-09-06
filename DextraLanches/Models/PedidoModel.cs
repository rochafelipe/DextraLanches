using DextraLanches.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DextraLanches.Models
{
    public class PedidoModel : BaseModel
    {

        public PedidoModel()
        {
            this.Lanches = new List<LancheModel>();
        }

        public List<LancheModel> Lanches { get; set; }

    }
}