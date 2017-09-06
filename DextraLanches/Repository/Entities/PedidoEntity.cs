using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DextraLanches.Repository.Entities
{
    public class PedidoEntity : BaseEntity
    {
        public PedidoEntity()
        {
            this.Lanches = new List<LancheEntity>();
        }

        public List<LancheEntity> Lanches { get; set; }

    }
}