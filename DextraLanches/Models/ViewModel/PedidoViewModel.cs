using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DextraLanches.Models
{
    public class PedidoViewModel
    {
        public PedidoViewModel()
        {
            this.Pedidos = new List<PedidoModel>();
        }


        public List<PedidoModel> Pedidos { get; set; }

    }
}