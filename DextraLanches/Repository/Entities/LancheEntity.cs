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
            this.PromocaoUtilizada = new PromocaoEntity();
        }
        public List<IngredienteEntity> Ingredientes { get; set; }

        public decimal PrecoPromocional{get;set;}

        public decimal Preco
        {
            get
            {
                return this.Ingredientes.Sum(i => i.Preco);
            }
        }

        public PromocaoEntity PromocaoUtilizada { get; set; }

        public bool ContemPromocao { get; set; }
    }
}