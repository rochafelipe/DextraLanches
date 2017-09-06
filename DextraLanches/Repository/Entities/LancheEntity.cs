using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DextraLanches.Repository.Entities
{
    public class LancheEntity : BaseEntity
    {
        public LancheEntity()
        {
            this.Ingredientes = new List<IngredienteEntity>();
        }
        public List<IngredienteEntity> Ingredientes { get; set; }

        public decimal Preco
        {
            get
            {
                return Ingredientes.Sum(i => i.Preco);
            }

        }
    }
}