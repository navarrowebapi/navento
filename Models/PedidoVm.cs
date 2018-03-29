using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.OData.Query.SemanticAst;

namespace Navento.Models
{
    public class PedidoVm
    {
        public int UsuarioId { get; set; }
        public int[] ProdutoIds { get; set; }
        public List<Produto> Produtos { get; set; }


    }
}
