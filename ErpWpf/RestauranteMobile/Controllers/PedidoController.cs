using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Erp.Business.Entity.Estoque.Produto;
using Erp.Business.Entity.Vendas.Pedido.Restaurante;
using Erp.Business.Entity.Vendas.Pedido.Restaurante.ClassesRelacionadas;
using Erp.Business.Enum;
using FluentNHibernate.Testing.Values;
using NHibernate.Mapping;
using RestauranteMobile.Models;

namespace RestauranteMobile.Controllers
{
    public class PedidoController : Controller
    {
        //
        // GET: /Pedido/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TelaPedido(PedidoModel model)
        {
            return View(model);
        }

        public ActionResult SolicitaNumeroMesa()
        {
            return View(new NovoPedidoModel());
        }
        
        public ActionResult NovoPedido(NovoPedidoModel model)
        {
            var mod = new PedidoModel()
            {
                Entity = new global::RestauranteService.RestauranteService().NovaMesa(model.Mesa)
            };

            return View("TelaPedido", mod);
        }
        [HttpPost]
        public ActionResult ConfirmarPedido(PedidoModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "ListaPedido");
            }
            return TelaPedido(model);
        }
        [HttpPost]
        public ActionResult AddItemPedido(PedidoModel model, int idProduto, decimal quantidade)
        {
            if (ModelState.IsValid)
            {
                model.Entity.Produtos.Add(ComposicaoProdutoRepository.CreateComposicaoProduto(
                    ProdutoRepository.GetById(idProduto),
                    quantidade));
            }
            return TelaPedido(model);
        }
        [HttpPost]
        public ActionResult RemoveItemPedido(PedidoModel model, Guid composicao)
        {
            if (ModelState.IsValid)
            {
                var mod = model.Entity.Produtos.SingleOrDefault(x => x.IdGuid == composicao);
                if (mod != null)
                {
                    model.Entity.Produtos.Remove(mod);
                }
            }
            return TelaPedido(model);
        }
        [HttpPost]
        public ActionResult AddItemComposicaoPedido(PedidoModel model, Guid composicao, int idProduto)
        {
            return View();
        }
        [HttpPost]
        public ActionResult RemoveItemComposicaoPedido(PedidoModel model, Guid composicao, Guid produto)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cliente(PedidoModel model)
        {
            return View();
        }
        [HttpPost]
        public ActionResult AlterarCliente(PedidoModel model, int cliente)
        {
            return View();
        }

        public ActionResult MesasConsumindo()
        {
            return View("MesasDisponiveis", new List<int>(){1,5,4});
        }
        public ActionResult MesasDisponiveis()
        {
            //return View(new global::RestauranteService.RestauranteService().GetMesasDisponiveis());
            return View(new List<int>(){1,2,3,4,5,6});
        }

        public ActionResult ListarPedidosFieitos()
        {
            try
            {
                var usuario = LoginController.GetPessoaLogada();
                return View(new PedidosGarconModel().GetPedidosAbertos(usuario.Id));
            }
            catch (Exception)
            {

                return View(new List<PedidoRestaurante>());
            }
            
        }
        [HttpPost]
        public ActionResult ListarPedidosFeitos(StatusProducaoPedido statusProducao)
        {
            try
            {
                var usuario = LoginController.GetPessoaLogada();
                return View(new PedidosGarconModel().GetPedidosAbertos(usuario.Id).Where(x=>x.StatusProducao == statusProducao).ToList());
            }
            catch (Exception)
            {
                return View(new List<PedidoRestaurante>());
            }

        }
        private PedidoModel CalculaPedido(PedidoModel model)
        {
            if (ModelState.IsValid)
            {

                Mapper.CreateMap(typeof(ComposicaoProduto), typeof(ComposicaoProduto));
                Mapper.Map(model.Entity, new global::RestauranteService.RestauranteService().CalcularPedido(model.Entity));
            }
            return model;
        }

    }
}