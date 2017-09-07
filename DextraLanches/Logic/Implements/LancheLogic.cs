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
    public class LancheLogic : ILogic
    {
        private LancheRepository LancheRepository;
        private IngredienteLogic IngredienteLogic;
        private PromocaoLogic PromocaoLogic;
        public LancheLogic()
        {
            this.IngredienteLogic = new IngredienteLogic();
            this.LancheRepository = new LancheRepository();
            this.PromocaoLogic = new PromocaoLogic();
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
            var ListaLanches = new List<BaseModel>();

            foreach(var lanche in this.LancheRepository.Buscar().Select(ConvertEntityToModel).Cast<LancheModel>())
            {
                ListaLanches.Add((LancheModel)this.PromocaoLogic.BuscarPorLanche(lanche));
            }

            return ListaLanches;
        }

        public Models.Abstraction.BaseModel Buscar(long ID)
        {
            return ConvertEntityToModel( this.LancheRepository.Buscar(ID));
        }

        public bool Remover(long ID)
        {
           return  this.LancheRepository.Remover(ID);
        }

        /// <summary>
        /// Método para receber uma lista de ingredientes e montar um lanche.
        /// Este método não aplica a promoção.
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public LancheModel MontarLanche(List<long> Ingredientes)
        {
            List<IngredienteModel> ListaIngredientes = new List<IngredienteModel>();

            for(int i =0; i < Ingredientes.Count; i++)
            {
                ListaIngredientes.Add((IngredienteModel)this.IngredienteLogic.Buscar(Ingredientes[i]));
            }

            LancheModel LancheMontado = new LancheModel();

            LancheMontado.Nome = "Meu Lanche";
            LancheMontado.Descricao = "Lanche montado pelo cliente.";
            LancheMontado.ListaIngredientes = ListaIngredientes;

            LancheMontado = (LancheModel)this.PromocaoLogic.BuscarPorLanche(LancheMontado);

            

            return LancheMontado;

        }

        public BaseEntity ConvertModelToEntity(BaseModel m)
        {
            LancheEntity e = new LancheEntity();

            e.Nome = m.Nome;
            e.Descricao = m.Descricao;
            e.ID = m.ID;
            e.PrecoPromocional = ((LancheModel)m).PrecoPromocional;
            e.PromocaoUtilizada = (PromocaoEntity)this.PromocaoLogic.ConvertModelToEntity(((LancheModel)m).PromocaoUtilizada);
            e.ContemPromocao = ((LancheModel)m).ContemPromocao;

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
            m.ContemPromocao = ((LancheEntity)e).ContemPromocao;
            m.PrecoPromocional = ((LancheEntity)e).PrecoPromocional;
            m.PromocaoUtilizada = ((LancheEntity)e).PromocaoUtilizada != null ? (PromocaoModel)this.PromocaoLogic.ConverteEntityToModel(((LancheEntity)e).PromocaoUtilizada) : m.PromocaoUtilizada;
            foreach (var ingrediente in ((LancheEntity)e).Ingredientes)
            {
                m.ListaIngredientes.Add((IngredienteModel)IngredienteLogic.ConvertEntityToModel(ingrediente));

                m.Ingredientes += ", " + ingrediente.Nome;
            }

            return m;
        }
    }
}