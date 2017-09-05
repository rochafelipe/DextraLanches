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
    public class CardapioLogic : ILogic
    {

        public CardapioRepository Repository;

        public CardapioLogic()
        {
            if(this.Repository == null)
                this.Repository = new CardapioRepository();
        }

        public Models.Abstraction.BaseModel Adicionar(Models.Abstraction.BaseModel model)
        {
            return ConverteEntityToModel((CardapioEntity)this.Repository.Adicionar(ConverteModelToEntity((CardapioModel)model)));
        }

        public Models.Abstraction.BaseModel Atualizar(Models.Abstraction.BaseModel model)
        {
            throw new NotImplementedException();
        }

        public List<Models.Abstraction.BaseModel> Buscar()
        {
            return this.Repository.Buscar().Select(ConverteEntityToModel).ToList();
        }

        public Models.Abstraction.BaseModel Buscar(long ID)
        {
            throw new NotImplementedException();
        }

        public bool Remover(long ID)
        {
            throw new NotImplementedException();
        }

        public BaseEntity ConverteModelToEntity(BaseModel model)
        {
            CardapioEntity e = new CardapioEntity();

            e.Descricao = model.Descricao;
            e.ID = model.ID;
            e.Nome = model.Nome;

            return e;
        }

        public BaseModel ConverteEntityToModel(BaseEntity e)
        {
            CardapioModel m = new CardapioModel();

            m.Descricao = e.Descricao;
            m.ID = e.ID;
            m.Nome = e.Nome;

            return m;
        }
    }
}