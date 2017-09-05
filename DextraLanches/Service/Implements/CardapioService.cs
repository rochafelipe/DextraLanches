using DextraLanches.Logic.Implements;
using DextraLanches.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DextraLanches.Service.Implements
{
    public class CardapioService : IService
    {
        public CardapioService()
        {
            if(CardapioLogic == null)
            {
                CardapioLogic = new CardapioLogic();
            }
        }

        private CardapioLogic CardapioLogic;

        public Models.Abstraction.BaseModel Adicionar(Models.Abstraction.BaseModel model)
        {
            return this.CardapioLogic.Adicionar(model);
        }

        public Models.Abstraction.BaseModel Atualizar(Models.Abstraction.BaseModel model)
        {
            throw new NotImplementedException();
        }

        public List<Models.Abstraction.BaseModel> Buscar()
        {
            return this.CardapioLogic.Buscar();
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