using DextraLanches.Repository.Abstraction;
using DextraLanches.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DextraLanches.Repository.DAL
{
    public class CardapioRepository : IRepository
    {
        public CardapioRepository()
        {
            Cardapios = HttpContext.Current.Session["CardapiosBD"] as List<BaseEntity>;
            
            if(Cardapios == null)
            {
                this.Cardapios = new List<BaseEntity>();
            }
        }

        private List<BaseEntity> Cardapios = new List<BaseEntity>();

        public Entities.BaseEntity Adicionar(Entities.BaseEntity entity)
        {
            if(entity.ID == 0)
            {
                entity.ID = 1;
            }
            else
            {
                entity.ID = this.Buscar().Max(m => m.ID)+1;
            }

            this.Cardapios.Add(entity);
            HttpContext.Current.Session["CardapiosBD"] = this.Cardapios;
            return entity;
        }

        public Entities.BaseEntity Atualizar(Entities.BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<Entities.BaseEntity> Buscar()
        {
            return this.Cardapios;
        }

        public Entities.BaseEntity Buscar(long ID)
        {
            throw new NotImplementedException();
        }

        public bool Remover(long ID)
        {
            return this.Cardapios.Remove(Cardapios.Where(c => c.ID == ID).First());
        }
    }
}