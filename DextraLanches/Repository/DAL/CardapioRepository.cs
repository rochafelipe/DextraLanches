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
            if(Cardapios == null && Cardapios.Count <= 0)
            {
                this.Cardapios = new List<BaseEntity>();
            }
        }

        private List<BaseEntity> Cardapios = new List<BaseEntity>();

        public Entities.BaseEntity Adicionar(Entities.BaseEntity entity)
        {
            this.Cardapios.Add(entity);
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