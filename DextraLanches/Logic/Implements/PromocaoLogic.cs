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
                this.PromocaoLight(LancheModel);
                this.PromocaoMuitaCarne(LancheModel);
                this.PromocaoMuitoQueijo(LancheModel);
            }

            if (LancheModel.Promocoes.Count > 0)
            {
                var promo = LancheModel.Promocoes.Max(p => p.ID);
                LancheModel.ContemPromocao = true;

                switch (promo)
                {
                    case 1:
                        LancheModel.PrecoPromocional = this.CalcularDescontoLight(LancheModel);
                        LancheModel.PromocaoUtilizada = LancheModel.Promocoes.Where(p => p.ID == 1).First();
                        break;
                    case 2:
                        LancheModel.PrecoPromocional = this.CalcularDescontoMuitaCarne(LancheModel);
                        LancheModel.PromocaoUtilizada = LancheModel.Promocoes.Where(p => p.ID == 2).First();

                        break;
                    case 3:
                        LancheModel.PrecoPromocional = this.CalcularDescontoMuitoQueijo(LancheModel);
                        LancheModel.PromocaoUtilizada = LancheModel.Promocoes.Where(p => p.ID == 3).First();
                        break;
                }

            }

            return LancheModel;
        }

        public void PromocaoLight(LancheModel lanche )
        {

            var alfaceModel = this.IngredienteLogic.Buscar(1);
            var baconModel = this.IngredienteLogic.Buscar(2);
            if (lanche.ListaIngredientes.Any(i => i.ID == alfaceModel.ID) && !lanche.ListaIngredientes.Any(i => i.ID == baconModel.ID))
            {
                lanche.Promocoes.Add((PromocaoModel)ConverteEntityToModel(this.PromocaoRepository.Buscar(1)));
            } 
            else
            {
                //return null;
            }
        }

        public void PromocaoMuitaCarne(LancheModel lanche)
        {
            var carneModel = this.IngredienteLogic.Buscar(3);

            var QuantidadeCarne = lanche.ListaIngredientes.Where(i => i.ID == carneModel.ID).Count();

            if (QuantidadeCarne >= 3)
            {
                lanche.Promocoes.Add((PromocaoModel)ConverteEntityToModel( this.PromocaoRepository.Buscar(2)));
            }
            else
            {
                //return null;
            }
        }

        public void PromocaoMuitoQueijo(LancheModel lanche)
        {

            var queijoModel = this.IngredienteLogic.Buscar(5);

            var QuantidadeCarne = lanche.ListaIngredientes.Where(i => i.ID == queijoModel.ID).Count();

            if (QuantidadeCarne >= 3)
            {
                lanche.Promocoes.Add((PromocaoModel)ConverteEntityToModel(this.PromocaoRepository.Buscar(3)));
            }
            else
            {
                //return null;
            }
        }

        public decimal CalcularDescontoLight(LancheModel lanche)
        {
            return lanche.Preco - ((10 * lanche.Preco) / 100);
        }

        public decimal CalcularDescontoMuitaCarne(LancheModel lanche)
        {
            var fatorDesconto = Math.Floor((double)lanche.ListaIngredientes.Where(i => i.ID == 3).Count() / 3);

            var precoCarne = ((IngredienteModel)this.IngredienteLogic.Buscar(3)).Preco;

            return lanche.Preco - ((decimal)fatorDesconto * precoCarne);
        }

        public decimal CalcularDescontoMuitoQueijo(LancheModel lanche)
        {
            var fatorDesconto = Math.Floor((double)lanche.ListaIngredientes.Where(i => i.ID == 3).Count() / 3);

            var precoQueijo = ((IngredienteModel)this.IngredienteLogic.Buscar(5)).Preco;

            return lanche.Preco - ((decimal)fatorDesconto * precoQueijo);
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