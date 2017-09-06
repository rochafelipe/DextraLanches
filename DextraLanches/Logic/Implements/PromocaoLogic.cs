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
    public class PromocaoLogic : ILogic
    {
        public PromocaoLogic()
        {
            this.PromocaoRepository = new PromocaoRepository();
            this.IngredienteLogic = new IngredienteLogic();
        }

        private PromocaoRepository PromocaoRepository;
        private IngredienteLogic IngredienteLogic;

        public Models.Abstraction.BaseModel Adicionar(Models.Abstraction.BaseModel model)
        {
            return ConverteEntityToModel(this.PromocaoRepository.Adicionar(ConvertModelToEntity(model)));
        }

        public Models.Abstraction.BaseModel Atualizar(Models.Abstraction.BaseModel model)
        {
            throw new NotImplementedException();
        }

        public List<Models.Abstraction.BaseModel> Buscar()
        {
            return this.PromocaoRepository.Buscar().Select(ConverteEntityToModel).ToList();
        }

        public Models.Abstraction.BaseModel Buscar(long ID)
        {
            return ConverteEntityToModel(this.PromocaoRepository.Buscar(ID));
        }

        /// <summary>
        /// Método para receber um lanche e verificar as promoções para este lanche.
        /// </summary>
        /// <param name="LancheModel"></param>
        /// <returns></returns>
        public Models.Abstraction.BaseModel BuscarPorLanche(LancheModel LancheModel)
        {
            if(LancheModel.ListaIngredientes.Count > 0)
            {
               // LancheModel.Promocoes.Add( ConverteEntityToModel( this.PromocaoLight(LancheModel.ListaIngredientes)));
            }

            return LancheModel;
        }

        public PromocaoEntity PromocaoLight(List<IngredienteModel> Ingredientes )
        {

            var alfaceModel = this.IngredienteLogic.Buscar(1);
            var baconMoel = this.IngredienteLogic.Buscar(2);
            if (Ingredientes.Contains(alfaceModel) && !Ingredientes.Contains(baconMoel))
            {
                return (PromocaoEntity)this.PromocaoRepository.Buscar(1);
            }
            else
            {
                return null;
            }
        }

        public PromocaoEntity PromocaoMuitaCarne(List<IngredienteModel> Ingredientes)
        {
            var carneModel = this.IngredienteLogic.Buscar(3);

            var QuantidadeCarne = Ingredientes.Where(i => i.ID == carneModel.ID).Count();

            if (QuantidadeCarne >= 3)
            {
                return (PromocaoEntity)this.PromocaoRepository.Buscar(2);
            }
            else
            {
                return null;
            }
        }

        public PromocaoEntity PromocaoMuitoQueijo(List<IngredienteModel> Ingredientes)
        {

            var queijoModel = this.IngredienteLogic.Buscar(5);

            var QuantidadeQueijo = Ingredientes.Where(i => i.ID == queijoModel.ID).Count();

            if (QuantidadeQueijo >= 3)
            {
                return (PromocaoEntity)this.PromocaoRepository.Buscar(3);
            }
            else
            {
                return null;
            }
        }


        public bool Remover(long ID)
        {
            throw new NotImplementedException();
        }


        public BaseEntity ConvertModelToEntity(BaseModel m)
        {
            PromocaoEntity e = new PromocaoEntity();

            e.Descricao = m.Descricao;
            e.Nome = m.Nome;
            e.RegraNegocio = ((PromocaoModel)m).RegraNegocio;
            e.ID = m.ID;

            return e;
        }


        public BaseModel ConverteEntityToModel(BaseEntity e)
        {
            PromocaoModel m = new PromocaoModel();

            m.Descricao = e.Descricao;
            m.Nome = e.Nome;
            m.ID = e.ID;
            m.RegraNegocio = ((PromocaoEntity)e).RegraNegocio;

            return m;
        }
    }
}