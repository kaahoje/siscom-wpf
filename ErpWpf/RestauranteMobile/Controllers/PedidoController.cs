using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using DevExpress.Office.Utils;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio;
using Erp.Business.Entity.Estoque.Produto;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using Erp.Business.Entity.Vendas.Pedido.Restaurante;
using Erp.Business.Entity.Vendas.Pedido.Restaurante.ClassesRelacionadas;
using Erp.Business.Enum;
using RestauranteMobile.Extensions;
using RestauranteMobile.Models;
using RestauranteService;

namespace RestauranteMobile.Controllers
{
    public class PedidoController : BaseController
    {

        static global::RestauranteService.RestauranteService service = new global::RestauranteService.RestauranteService();

        //
        // GET: /Pedido/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TelaPedido(PedidoModel model)
        {
            //var mod = GetPedidoModel();
            //MapperModel(mod,model);
            return View(model);
        }

        public ActionResult CancelarPedido()
        {
            //SetPedidoModel(null);
            return View("Index");
        }

        //private void SetPedidoModel(PedidoModel pedido)
        //{
        //    Session["PedidoModel"] = pedido;
        //}
        //private PedidoModel GetPedidoModel()
        //{
        //    return (PedidoModel)Session["PedidoModel"];
        //}
        public ActionResult SolicitaNumeroMesa()
        {
            return View(new NovoPedidoModel());
        }
        [HttpPost]
        public ActionResult NovoPedido(NovoPedidoModel model)
        {
            var entity = new global::RestauranteService.RestauranteService().NovaMesa(model.Mesa);

            var mod = new PedidoModel()
            {
                Entity = entity
            };
            //SetPedidoModel(mod);
            return View("TelaPedido", mod);
        }

        public ActionResult NovoPedido(int mesa)
        {
            var entity = new global::RestauranteService.RestauranteService().NovaMesa(mesa);
            var mod = new PedidoModel()
            {
                Entity = entity
            };
            return View("TelaPedido",mod);
        }
        [HttpPost]
        public ActionResult ConfirmarPedido(PedidoModel model)
        {
            foreach (var comp in model.Entity.Produtos)
            {
                comp.Produto = ProdutoRepository.GetById(comp.Produto.Id);
                foreach (var prod in comp.Composicao)
                {
                    prod.Produto = ProdutoRepository.GetById(prod.Produto.Id);
                }
            }
            if (model.Entity.Garcon != null && model.Entity.Garcon.Id != 0)
            {
                model.Entity.Garcon = ParceiroNegocioPessoaFisicaRepository.GetById(model.Entity.Id);
            }
            try
            {
                if (PedidoRestauranteRepository.Validate(model.Entity))
                {
                    // Salva o pedido no servidor e verifica o retorno do mesmo.
                    if (service.ConfirmarPedido(model.Entity) == StatusComando.ConcluidoSucesso)
                    {
                        return View("Index");
                    }
                    // Caso não seja confirmado o salvamento do pedido o sistema retorna o erro.
                    ErrorMessage(service.GetLastException());
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message);
            }
            return View("TelaPedido", model);
        }
        [HttpPost]
        public ActionResult AddItemPedido(PedidoModel model)
        {

            //var mod = GetPedidoModel();
            model.Entity.Produtos.Add(ComposicaoProdutoRepository.CreateComposicaoProduto(
                            ProdutoRepository.GetById(model.ProdutoPedido.IdProduto),
                            model.ProdutoPedido.Quantidade));
            //MapperModel(mod, model);
            return View("TelaPedido", model);
        }

        //private void MapperModel(PedidoModel origem, PedidoModel destino)
        //{
        //    var prod = destino.ProdutoPedido;
        //    Mapper.CreateMap(typeof(PedidoModel), typeof(PedidoModel));
        //    Mapper.Map(origem, destino);
        //    destino.ProdutoPedido = prod;
        //}
        [HttpPost]
        public ActionResult RemoveItemPedido(PedidoModel model)
        {
            //PedidoModel model = GetPedidoModel();
            var mod = model.Entity.Produtos.SingleOrDefault(x => x.IdGuid == model.ProdutoPedido.Composicao);
            if (mod != null)
            {
                model.Entity.Produtos.Remove(mod);
            }

            return View("TelaPedido", model);
        }
        [HttpPost]
        public ActionResult ComporItem(PedidoModel model)
        {
            //var model = GetPedidoModel();
            var comp = model.Entity.Produtos.FirstOrDefault(x => x.IdGuid == model.ProdutoPedido.Composicao);
            if (comp == null)
            {
                ErrorMessage("Composição não encontrada.");
                return View("TelaPedido", model);
            }
            if (model.ProdutoPedido == null)
            {
                model.ProdutoPedido = new ProdutoPedidoModel();
            }
            model.ProdutoPedido.ComposicaoEdit = model.ProdutoPedido.Composicao;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddItemComposicaoPedido(PedidoModel model)
        {
            //var mod = GetPedidoModel();
            
            var prod = ProdutoRepository.GetById(model.ProdutoPedido.IdProduto);
            // Pega a composição do modelo que está na Session.
            var comp = model.Entity.Produtos.FirstOrDefault(x => x.IdGuid == model.ProdutoPedido.ComposicaoEdit);
            if (comp == null)
            {
                return View("TelaPedido", model);
            }
            // Adiciona o produto à composição
            comp.Composicao.Add(new ProdutoPedido()
            {
                Produto = prod,
                Quantidade = 1,
                Valor = prod.PrecoVenda,
                ValorUnitario = prod.PrecoVenda
            });
            Mapper.CreateMap(typeof (ComposicaoProduto), typeof (ComposicaoProduto));
            // Passa a composição ajustada para a composição do produto que está na session.
            Mapper.Map(service.VerificaComposicao(comp), comp);
            // Mapea os dados para o modelo que vai para a view.
            //MapperModel(mod,model);
            model.ProdutoPedido.ComposicaoEdit = comp.IdGuid;
            return View("ComporItem", model);
        }
        [HttpPost]
        public ActionResult RemoveItemComposicaoPedido(PedidoModel model)
        {
            //var mod = GetPedidoModel();
            var comp = model.Entity.Produtos.FirstOrDefault(x => x.IdGuid == model.ProdutoPedido.Composicao);
            if (comp == null)
            {
                ErrorMessage("Composição não encontrada.");
                return View("TelaPedido", model);
            }
            var prod = comp.Composicao.FirstOrDefault(x=>x.IdGuid == model.ProdutoPedido.Produto);
            if (prod == null)
            {
                ErrorMessage("Produto não encontrado.");
                return View("TelaPedido", model);
            }
            comp.Composicao.Remove(prod);
            if (comp.Composicao.Count == 0)
            {
                RemoveItemPedido(model);
                return View("TelaPedido", model);
            }
            model.ProdutoPedido.ComposicaoEdit = comp.IdGuid;
            //MapperModel(mod,model);
            return View("ComporItem",model);
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

        public ActionResult Consumo(int mesa)
        {
            var m = service.GetMesa(mesa);
            if (m == null)
            {
                ErrorMessage("Mesa não encontrada");
                if (ControllerContext.RequestContext.HttpContext.Request.Url != null)
                    return RedirectToAction("Index");
            }
            var model = new PedidoModel()
            {
                Entity = m
            };
            model = CalculaPedido(model);
            return View(model);
        }
        public ActionResult MesasConsumindo()
        {
            var mesas = service.GetMesasAbertas();
            var mod = mesas.Select(mesa => mesa.Mesa).ToList();
            return View(mod);
        }
        public ActionResult MesasEstabelecimento()
        {
            var list = service.GetMesasDisponiveis();
            return View(list);
            
        }

        public ActionResult ListarPedidosFeitos()
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
                return View(new PedidosGarconModel().GetPedidosAbertos(usuario.Id).Where(x => x.StatusProducao == statusProducao).ToList());
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

        public ActionResult GetProdutos(string term)
        {
            var list = ProdutoRepository.GetByRange(term, 20);
            var ret = list.Select(produto => AutoCompleteHelper.GetAutoCompleteItem(
                produto.Id.ToString(CultureInfo.InvariantCulture),
                produto.Descricao, produto.Descricao, "", new { preco = produto.PrecoVenda })).ToList();
            return Json(ret, JsonRequestBehavior.AllowGet);
        }
    }
}