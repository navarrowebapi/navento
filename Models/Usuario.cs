using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Navento.Models
{
    public class Usuario
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        //PNão é necessário PedidoId, pois o relacionamento já está realizado pelo lado de Pedido.
        //public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }


    }
}
