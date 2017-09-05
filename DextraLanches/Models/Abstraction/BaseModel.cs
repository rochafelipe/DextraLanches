using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DextraLanches.Models.Abstraction
{
    public class BaseModel
    {
        public long ID { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }
    }
}