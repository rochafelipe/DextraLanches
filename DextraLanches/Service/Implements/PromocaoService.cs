using DextraLanches.Logic.Implements;
using DextraLanches.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DextraLanches.Service.Implements
{
    public class PromocaoService : IService
    {
        private PromocaoLogic PromocaoLogic;

        public PromocaoService()
        {
            this.PromocaoLogic = new PromocaoLogic();
        }

        public Models.Abstraction.BaseModel Adicionar(Models.Abstraction.BaseModel model)
        {
            return this.PromocaoLogic.Adicionar(model);
        }

        public Models.Abstraction.BaseModel Atualizar(Models.Abstraction.BaseModel model)
        {
            throw new NotImplementedException();
        }

        public List<Models.Abstraction.BaseModel> Buscar()
        {
            throw new NotImplementedException();
        }

        public Models.Abstraction.BaseModel Buscar(long ID)
        {
            throw new NotImplementedException();
        }

        public bool Remover(long ID)
        {
            throw new NotImplementedException();
        }
    }
}