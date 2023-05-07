using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resultado_Function.Models
{
    internal class ListResultadoModel
    {
        public int Id { get; set; }
        public decimal? Velocidad { get; set; }
        public decimal? Cadencia { get; set; }

        public int IdUsuario { get; set; }


    }
}
