using DextraLanches.Repository.Abstraction;
using DextraLanches.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DextraLanches.Repository.DAL
{
    public class IngredienteRepository : IRepository
    {
        private List<BaseEntity> Ingredientes;

        public IngredienteRepository()
        {
            Ingredientes = HttpContext.Current.Session["IngredientesBD"] as List<BaseEntity>;
            if (Ingredientes == null)
                Ingredientes = new List<BaseEntity>();
        }

        public Entities.BaseEntity Adicionar(Entities.BaseEntity entity)
        {
            Ingredientes.Add(entity);
            HttpContext.Current.Session["IngredientesBD"] = Ingredientes;

            return entity;
        }

        public Entities.BaseEntity Atualizar(Entities.BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<Entities.BaseEntity> Buscar()
        {
            //Inicia com ingredientes padrão
            if(Ingredientes.Count <= 0)
            {
                Ingredientes.Add(new IngredienteEntity()
                {
                    Nome = "Alface",
                    Descricao = "Alface",
                    ID = 1,
                    Preco = 0.40M
                });
                Ingredientes.Add(new IngredienteEntity()
                {
                    Nome = "Bacon",
                    Descricao = "Bacon",
                    ID = 2,
                    Preco = 2.00M
                });
                Ingredientes.Add(new IngredienteEntity()
                {
                    Nome = "Hambúrguer de carne",
                    Descricao = "Hambúrguer de carne",
                    ID = 3,
                    Preco = 3.00M
                });
                Ingredientes.Add(new IngredienteEntity()
                {
                    Nome = "Ovo",
                    Descricao = "Ovo",
                    ID = 4,
                    Preco = 0.80M
                });
                Ingredientes.Add(new IngredienteEntity()
                {
                    Nome = "Queijo",
                    Descricao = "Queijo",
                    ID = 5,
                    Preco = 1.50M
                });
            }

            return Ingredientes;
        }

        public Entities.BaseEntity Buscar(long ID)
        {
            if (Ingredientes.Count <= 0)
                this.Buscar();

            if(Ingredientes == null)
            {
                return null;
            }else
            {
                return Ingredientes.Where(i => i.ID == ID).First();
            }
        }

        public List<BaseEntity> BuscarPorLanche(long IDLanche)
        {
            if (this.Ingredientes.Count == 0)
                this.Buscar();

            List<BaseEntity> Retorno = new List<BaseEntity>();

            switch(IDLanche)
            {
                case 1:
                    Retorno = Ingredientes.Where(i => i.ID == 2 || i.ID == 3 || i.ID == 5).ToList();
                    break;
                case 2:
                    Retorno = Ingredientes.Where(i => i.ID == 3 || i.ID == 5).ToList();

                    break;
                case 3:
                    Retorno = Ingredientes.Where(i => i.ID == 3 || i.ID == 4 || i.ID == 5).ToList();

                    break;
                case 4:
                    Retorno = Ingredientes.Where(i => i.ID == 2 || i.ID == 3 || i.ID == 4 || i.ID == 5).ToList();

                    break;
            }

            return Retorno;
        }

        public bool Remover(long ID)
        {
            if (Ingredientes == null)
            {
                return false;
            }
            else
            {
                if(Ingredientes.Count > 0)
                return Ingredientes.Remove(this.Buscar(ID));
            }

            return false;
        }
    }
}