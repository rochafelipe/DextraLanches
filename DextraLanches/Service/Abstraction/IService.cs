using DextraLanches.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DextraLanches.Service.Abstraction
{
    public interface IService
    {

        BaseModel Adicionar(BaseModel model);

        BaseModel Atualizar(BaseModel model);

        List<BaseModel> Buscar();

        BaseModel Buscar(long ID);

        bool Remover(long ID);

    }
}