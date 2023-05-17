using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Resultado_Function.Models
{
    internal class ListResultadoModel
    {
        public BigInteger ID { get; set; }
        public BigInteger idUser { get; set; }
        public BigInteger tiempo { get; set; }
        public float? velocidad { get; set; }
        public float? distancia { get; set; }
        public DateTime? fechaActual { get; set; }

        


    }
}
