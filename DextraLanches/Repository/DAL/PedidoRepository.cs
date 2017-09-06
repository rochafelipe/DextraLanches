using DextraLanches.Repository.Abstraction;
using DextraLanches.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DextraLanches.Repository.DAL
{
    public class PedidoRepository : IRepository
    {

        private List<BaseEntity> Pedidos { get; set; }

        public PedidoRepository()
        {
            this.Pedidos = HttpContext.Current.Session["PedidosBD"] as List<BaseEntity>;

            if (Pedidos == null)
                Pedidos = new List<BaseEntity>();
        }

        public Entities.BaseEntity Adicionar(Entities.BaseEntity entity)
        {
            Pedidos.Add(entity);

            HttpContext.Current.Session["PedidosBD"] = Pedidos;

            return entity;
        }

        public Entities.BaseEntity Atualizar(Entities.BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<Entities.BaseEntity> Buscar()
        {
            return Pedidos;
        }

        public Entities.BaseEntity Buscar(long ID)
        {
            throw new NotImplementedException();
        }

        public bool Remover(long ID)
        {
            throw new NotImplementedException();
        }
    }
}