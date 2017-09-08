using DextraLanches.Logic.Implements;
using DextraLanches.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DextraLanches.Service.Implements
{
    public class IngredienteService : IService
    {
        private IngredienteLogic IngredienteLogic;

        public IngredienteService()
        {
            this.IngredienteLogic = new IngredienteLogic();
        }

        public Models.Abstraction.BaseModel Adicionar(Models.Abstraction.BaseModel model)
        {
           return  this.IngredienteLogic.Adicionar(model);
        }

        public Models.Abstraction.BaseModel Atualizar(Models.Abstraction.BaseModel model)
        {
            throw new NotImplementedException();
        }

        public List<Models.Abstraction.BaseModel> Buscar()
        {
            return this.IngredienteLogic.Buscar();
        }

        public Models.Abstraction.BaseModel Buscar(long ID)
        {
            return this.IngredienteLogic.Buscar(ID);
        }

        public bool Remover(long ID)
        {
            throw new NotImplementedException();
        }
    }
}