using DextraLanches.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DextraLanches.Models
{
    public class IngredienteModel : BaseModel
    {
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal Preco { get; set; }

    }
}