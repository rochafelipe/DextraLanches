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
    public class IngredienteLogic : ILogic
    {
        private IngredienteRepository IngredienteRepository;

        public IngredienteLogic()
        {
            this.IngredienteRepository = new IngredienteRepository();
        }

        public Models.Abstraction.BaseModel Adicionar(Models.Abstraction.BaseModel model)
        {
            throw new NotImplementedException();
        }

        public Models.Abstraction.BaseModel Atualizar(Models.Abstraction.BaseModel model)
        {
            throw new NotImplementedException();
        }

        public List<Models.Abstraction.BaseModel> Buscar()
        {
            return this.IngredienteRepository.Buscar().Select(ConvertEntityToModel).ToList();
        }

        public Models.Abstraction.BaseModel Buscar(long ID)
        {
            return ConvertEntityToModel( this.IngredienteRepository.Buscar(ID));
        }

        public bool Remover(long ID)
        {
            throw new NotImplementedException();
        }

        public BaseEntity ConvertModelToEntity(BaseModel m)
        {
            IngredienteEntity e = new IngredienteEntity();

            e.Nome = m.Nome;
            e.Descricao = m.Descricao;
            e.ID = m.ID;
            e.Preco = ((IngredienteModel)m).Preco;
            return e;
        }

        public BaseModel ConvertEntityToModel(BaseEntity e)
        {
            IngredienteModel m = new IngredienteModel();

            m.Descricao = e.Descricao;
            m.Nome = e.Nome;
            m.ID = e.ID;
            m.Preco = ((IngredienteEntity)e).Preco;
            return m;
        }
    }
}