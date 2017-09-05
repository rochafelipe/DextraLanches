using DextraLanches.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DextraLanches.Repository.Abstraction
{
    public interface IRepository
    {

         BaseEntity Adicionar(BaseEntity entity);

         BaseEntity Atualizar(BaseEntity entity);

         List<BaseEntity> Buscar();

         BaseEntity Buscar(long ID);

         bool Remover(long ID);

    }
}
