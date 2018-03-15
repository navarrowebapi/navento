using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Navento.Models
{
    public class PedidosVM
    {
        public int Id { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal Total { get; set; }
        public ICollection<Produto> Produtos { get; set; }

        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
    }
}
