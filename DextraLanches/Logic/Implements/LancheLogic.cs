﻿using DextraLanches.Logic.Abstraction;
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
    public class LancheLogic : ILogic
    {
        private LancheRepository LancheRepository;
        private IngredienteLogic IngredienteLogic;
        public LancheLogic()
        {
            this.IngredienteLogic = new IngredienteLogic();
            this.LancheRepository = new LancheRepository();
        }

        public Models.Abstraction.BaseModel Adicionar(Models.Abstraction.BaseModel model)
        {
            return ConvertEntityToModel( this.LancheRepository.Adicionar(ConvertModelToEntity(model)));
        }

        public Models.Abstraction.BaseModel Atualizar(Models.Abstraction.BaseModel model)
        {
            throw new NotImplementedException();
        }

        public List<Models.Abstraction.BaseModel> Buscar()
        {
            return this.LancheRepository.Buscar().Select(ConvertEntityToModel).ToList();
        }

        public Models.Abstraction.BaseModel Buscar(long ID)
        {
            return ConvertEntityToModel( this.LancheRepository.Buscar(ID));
        }

        public bool Remover(long ID)
        {
           return  this.LancheRepository.Remover(ID);
        }

        public BaseEntity ConvertModelToEntity(BaseModel m)
        {
            LancheEntity e = new LancheEntity();

            e.Nome = m.Nome;
            e.Descricao = m.Descricao;
            e.ID = m.ID;

            foreach(var ingrediente in ((LancheModel)m).ListaIngredientes)
            {
                e.Ingredientes.Add((IngredienteEntity)IngredienteLogic.ConvertModelToEntity(ingrediente));
            }

            return e;
        }

        public BaseModel ConvertEntityToModel(BaseEntity e)
        {
            LancheModel m = new LancheModel();

            m.Nome = e.Nome;
            m.Descricao = e.Descricao;
            m.ID = e.ID;
            
            foreach (var ingrediente in ((LancheEntity)e).Ingredientes)
            {
                m.ListaIngredientes.Add((IngredienteModel)IngredienteLogic.ConvertEntityToModel(ingrediente));

                m.Ingredientes += ", " + ingrediente.Nome;
            }

            return m;
        }
    }
}