using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Navento.Models
{
    public class Produto
    {

        public int Id  { get; set; }
        public string Nome { get; set; }
        public decimal PrecoUnitario { get; set; }

        //public ICollection<PedidoItem> PedidosItems { get; set; }

    }
}
