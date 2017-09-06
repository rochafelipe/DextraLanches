using DextraLanches.Repository.Abstraction;
using DextraLanches.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DextraLanches.Repository.DAL
{
    public class PromocaoRepository : IRepository
    {

        public PromocaoRepository()
        {
            this.Promocoes = HttpContext.Current.Session["PedidosBD"] as List<BaseEntity>;

            if (this.Promocoes == null)
                this.Promocoes = new List<BaseEntity>();
        }

        private List<BaseEntity> Promocoes { get; set; }

        public Entities.BaseEntity Adicionar(Entities.BaseEntity entity)
        {
            this.Promocoes.Add(entity);
            HttpContext.Current.Session["PedidosBD"] = this.Promocoes;

            return entity;
        }

        public Entities.BaseEntity Atualizar(Entities.BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<Entities.BaseEntity> Buscar()
        {
            //Adiciona as promoções padrão.
            if(this.Promocoes.Count <= 0)
            {
                this.Promocoes.Add(new PromocaoEntity()
                {
                    Nome = "Light",
                    Descricao = "Se o lanche tem alface e não tem bacon, ganha 10% de desconto.",
                    RegraNegocio = "Se o lanche tem alface e não tem bacon, ganha 10% de desconto.",
                    ID = 1
                });

                this.Promocoes.Add(new PromocaoEntity()
                {
                    Nome = "Muita carne",
                    Descricao = "A cada 3 porções de carne o cliente só paga 2. Se o lanche tiver 6 porções, ocliente pagará 4. Assim por diante...",
                    RegraNegocio = "A cada 3 porções de carne o cliente só paga 2. Se o lanche tiver 6 porções, ocliente pagará 4. Assim por diante...",
                    ID = 2
                });

                this.Promocoes.Add(new PromocaoEntity()
                {
                    Nome = "Muito queijo",
                    Descricao = "A cada 3 porções de queijo o cliente só paga 2. Se o lanche tiver 6 porções, ocliente pagará 4. Assim por diante...",
                    RegraNegocio = "A cada 3 porções de queijo o cliente só paga 2. Se o lanche tiver 6 porções, ocliente pagará 4. Assim por diante...",
                    ID = 3
                });

                //this.Promocoes.Add(new PromocaoEntity()
                //{
                //    Nome = "Inflação",
                //    Descricao = "Os valores dos ingredientes são alterados com frequência e não gastaríamos que isso influenciasse nos testes automatizados.",
                //    RegraNegocio = "Os valores dos ingredientes são alterados com frequência e não gastaríamos que isso influenciasse nos testes automatizados.",
                //    ID = 1
                //});
            }

            return Promocoes;
        }

        public Entities.BaseEntity Buscar(long ID)
        {
            return this.Promocoes.Where(p => p.ID == ID).FirstOrDefault();
        }

        public bool Remover(long ID)
        {
            throw new NotImplementedException();
        }
    }
}