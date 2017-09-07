using DextraLanches.Logic.Abstraction;
using DextraLanches.Models;
using DextraLanches.Models.Abstraction;
using DextraLanches.Repository.DAL;
using DextraLanches.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DextraLanches.Logic.Implements
{
    public class PedidoLogic : ILogic
    {
        private PedidoRepository PedidoRepository;
        private LancheLogic LancheLogic;
        public PedidoLogic()
        {
            this.PedidoRepository = new PedidoRepository();
            this.LancheLogic = new LancheLogic();
        }

        public Models.Abstraction.BaseModel Adicionar(Models.Abstraction.BaseModel model)
        {
            return ConvertEntityToModel( this.PedidoRepository.Adicionar(ConvertModelToBase(model)));
        }

        public Models.Abstraction.BaseModel Atualizar(Models.Abstraction.BaseModel model)
        {
            throw new NotImplementedException();
        }

        public List<Models.Abstraction.BaseModel> Buscar()
        {
            return this.PedidoRepository.Buscar().Select(ConvertEntityToModel).ToList();
        }

        public Models.Abstraction.BaseModel Buscar(long ID)
        {
            throw new NotImplementedException();
        }

        public bool Remover(long ID)
        {
           return  this.PedidoRepository.Remover(ID);
        }

        public BaseEntity ConvertModelToBase(BaseModel m)
        {
            PedidoEntity e = new PedidoEntity();

            e.ID = m.ID;
            e.Descricao = m.Descricao;
            e.Nome = m.Nome;

            foreach(var lanche in ((PedidoModel)m).Lanches)
            {
                e.Lanches.Add((LancheEntity) this.LancheLogic.ConvertModelToEntity( lanche));
            }

            return e;
        }

        public BaseModel ConvertEntityToModel(BaseEntity e)
        {
            PedidoModel m = new PedidoModel();

            m.ID = e.ID;
            m.Descricao = e.Descricao;
            m.Nome = e.Nome;

            foreach (var lanche in ((PedidoEntity)e).Lanches)
            {
                m.Lanches.Add((LancheModel)this.LancheLogic.ConvertEntityToModel(lanche));
            }

            return m;
        }

    }
}