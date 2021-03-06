﻿using DextraLanches.Logic.Implements;
using DextraLanches.Models;
using DextraLanches.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DextraLanches.Service.Implements
{
    public class LancheService : IService
    {

        private LancheLogic LancheLogic;

        public LancheService()
        {
            this.LancheLogic = new LancheLogic();
        }

        public Models.Abstraction.BaseModel Adicionar(Models.Abstraction.BaseModel model)
        {
            return this.LancheLogic.Adicionar(model);
        }

        public Models.Abstraction.BaseModel Atualizar(Models.Abstraction.BaseModel model)
        {
            throw new NotImplementedException();
        }

        public List<Models.Abstraction.BaseModel> Buscar()
        {
            return this.LancheLogic.Buscar();
        }

        public Models.Abstraction.BaseModel Buscar(long ID)
        {
           return this.LancheLogic.Buscar(ID);
        }

        public bool Remover(long ID)
        {
            throw new NotImplementedException();
        }

        public LancheModel MontarLanche(List<long> Ingredientes)
        {
            return this.LancheLogic.MontarLanche(Ingredientes);
        }

    }
}