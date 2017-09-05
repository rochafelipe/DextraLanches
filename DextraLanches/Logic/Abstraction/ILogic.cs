using DextraLanches.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DextraLanches.Logic.Abstraction
{
    public interface ILogic
    {
        BaseModel Adicionar(BaseModel model);

        BaseModel Atualizar(BaseModel model);

        List<BaseModel> Buscar();

        BaseModel Buscar(long ID);

        bool Remover(long ID);

    }
}
