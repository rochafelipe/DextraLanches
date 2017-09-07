using DextraLanches.Repository.Abstraction;
using DextraLanches.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DextraLanches.Repository.DAL
{
    public class LancheRepository : IRepository
    {

        private List<BaseEntity> Lanches;
        private IngredienteRepository IngredienteRepository;
        public LancheRepository()
        {
            this.IngredienteRepository = new DAL.IngredienteRepository();
            Lanches = HttpContext.Current.Session["LanchesBD"] as List<BaseEntity>;

            if (Lanches == null)
                Lanches = new List<BaseEntity>();
        }

        public Entities.BaseEntity Adicionar(Entities.BaseEntity entity)
        {
            this.Lanches.Add(entity);

            HttpContext.Current.Session["LanchesBD"] = Lanches;
            return entity;
        }

        public Entities.BaseEntity Atualizar(Entities.BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<Entities.BaseEntity> Buscar()
        {
           //Adiciona os Lanches do cardápio.
            if(Lanches.Count <=0)
            {
                Lanches.Add(new LancheEntity()
                {
                    Nome = "X-Bacon",
                    Descricao ="X-Bacon",
                    ID = 1,
                    Ingredientes = this.IngredienteRepository.BuscarPorLanche(1).Cast<IngredienteEntity>().ToList()
                });

                 Lanches.Add(new LancheEntity()
                {
                    Nome = "X-Burger",
                    Descricao ="X-Burger",
                    ID = 2,
                    Ingredientes = this.IngredienteRepository.BuscarPorLanche(2).Cast<IngredienteEntity>().ToList()
                });

                 Lanches.Add(new LancheEntity()
                {
                    Nome = "X-Egg",
                    Descricao ="X-Egg",
                    ID = 3,
                    Ingredientes = this.IngredienteRepository.BuscarPorLanche(3).Cast<IngredienteEntity>().ToList(),
                    
                });

                 Lanches.Add(new LancheEntity()
                {
                    Nome = "X-Egg Bacon",
                    Descricao ="X-Egg Bacon",
                    ID = 4,
                    Ingredientes = this.IngredienteRepository.BuscarPorLanche(4).Cast<IngredienteEntity>().ToList()
                });
            }

            return this.Lanches;
        }

        public Entities.BaseEntity Buscar(long ID)
        {
            if (Lanches.Count <= 0)
                this.Buscar();

          
                return Lanches.Where(l => l.ID == ID).FirstOrDefault();

            return null;
        }

        public bool Remover(long ID)
        {
            if (Lanches.Count > 0)
                return Lanches.Remove(this.Buscar(ID));

            return false;
        }
    }
}