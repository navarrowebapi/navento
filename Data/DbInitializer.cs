using Navento.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Navento.Data
{
    public static class DbInitializer
    {
        public static void Initialize(NaventoContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Produtos.Any())
            {
                return;   // DB has been seeded
            }

            //SIMULANDO UM USUARIO JA CADASTRADO e UMA COMPRA
            var usuario = new Usuario { Nome = "Jao", Email = "teste" };
            context.Usuarios.Add(usuario);
            context.SaveChanges();

            var produto1 = new Produto {Nome = "Prod1", PrecoUnitario = 1000};
            var produto2 = new Produto { Nome = "Prod2", PrecoUnitario = 2000 };
            var produto3 = new Produto { Nome = "Prod3", PrecoUnitario = 3000 };
            var produtos = new[] {produto1, produto2, produto3};
            context.Produtos.AddRange(produtos);
            context.SaveChanges();

            var pedido = new Pedido { UsuarioId = usuario.Id, Data = DateTime.Now };
            context.Pedidos.Add(pedido);
            context.SaveChanges();

            var produtosComprados = new List<Produto> { produto1, produto3 };
            //Salvando cada Item de Pedido
            foreach (var produto in produtosComprados)
            {
                var pedidoItem = new PedidoItem { PedidoId = pedido.Id, ProdutoId = produto.Id };
                context.PedidoItems.Add(pedidoItem);
                context.SaveChanges();
            }

            ////PARA uma visualização/cenário de Administrador / SAD-SIG

            //foreach (var prods in produtosComprados)
            //{
            //    var pedidosVm = new PedidoVm { PedidoId = pedido.Id, Produtos = produtosComprados, Preco = produtosComprados.Sum(x=>x.PrecoUnitario), Quantidade = produtosComprados.Count};
            //    context.PedidosVms.Add(pedidosVm);
            //    context.SaveChanges();
            //}

        }
    }
}