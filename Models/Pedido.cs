using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Navento.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime? Data { get; set; }
        public int QtdeItens { get; set; }
        public decimal ValorTotal { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public ICollection<PedidoItem> PedidosItems { get; set; }

    }
}
