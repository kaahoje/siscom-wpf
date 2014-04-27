using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using AutoMapper;
using Erp.Business.Entity.Contabil.Pessoa;
using Erp.Business.Entity.Estoque.Produto;
using Erp.Business.Entity.Vendas.Pedido;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using Erp.Business.Entity.Vendas.Pedido.Restaurante;
using Erp.Business.Entity.Vendas.Pedido.Restaurante.ClassesRelacionadas;
using Erp.Business.Enum;
using FluentNHibernate.Conventions;
using RestauranteService;
using Util;
using Util.Seguranca;
using Vendas.Component.View.Telas;
using Vendas.Properties;
using Vendas.ViewModel.Grids;

namespace Vendas.ViewModel.Forms
{

    public class PedidoRestauranteModel : PedidoModel
    {
        private global::RestauranteService.RestauranteService Service { get; set; }
        public PedidoRestauranteModel()
        {
            Service = new global::RestauranteService.RestauranteService();
            Entity = new PedidoRestaurante();

        }

        #region Propriedades



        private ObservableCollection<ComposicaoProduto> _produtos;


        private ComposicaoProduto _produtoAtual;


        private ProdutoPedido _produtoComposicaoAtual;
        private Visibility _telaPedidoVisible = Visibility.Hidden;
        private bool _isProdutoEditable;

        public PedidoRestaurante EntityRestaurante
        {
            get { return (PedidoRestaurante)Entity; }
        }



        public ProdutoPedido ProdutoComposicaoAtual
        {
            get { return _produtoComposicaoAtual; }
            set
            {
                _produtoComposicaoAtual = value;
                OnPropertyChanged("ProdutoComposicaoAtual");
            }
        }

        public ComposicaoProduto ProdutoAtual
        {
            get { return _produtoAtual; }
            set
            {
                _produtoAtual = value;
                if (value == null)
                {
                    IsProdutoEditable = true;
                }
                else
                {
                    IsProdutoEditable = false;
                }
                OnPropertyChanged("ProdutoAtual");
            }
        }




        public ObservableCollection<ComposicaoProduto> Produtos
        {
            get
            {

                return _produtos ?? (_produtos = new ObservableCollection<ComposicaoProduto>());
            }
            set
            {
                _produtos = value;
                OnPropertyChanged("Produtos");


            }
        }

        public Visibility TelaPedidoVisible
        {
            get { return _telaPedidoVisible; }
            set
            {
                _telaPedidoVisible = value;
                OnPropertyChanged();
            }
        }

        public bool IsProdutoEditable
        {
            get { return _isProdutoEditable; }
            set
            {
                _isProdutoEditable = value;
                OnPropertyChanged();
            }
        }

        #endregion Fim propriedades
        protected override void OnPropertyChanged(string propertyName = null)
        {
            if (propertyName != null)
            {
                base.OnPropertyChanged(propertyName);
                if (!String.IsNullOrEmpty(propertyName))
                {
                    switch (propertyName)
                    {

                        case "Pedido":
                            Produtos = new ObservableCollection<ComposicaoProduto>(Produtos);
                            Pagamento = new ObservableCollection<PagamentoPedido>(Entity.Pagamento);
                            break;
                        case "Desconto":
                            CalculaPedido();
                            break;
                        case "Acressimo":
                            CalculaPedido();
                            break;
                        case "Frete":
                            CalculaPedido();
                            break;
                    }
                }
            }
        }



        public bool NovoPedidoMesa()
        {
            var num = new NumeroView();
            var controle = NovoControle();
            if (controle == null)
            {
                return false;
            }
            num.ShowDialog();

            if (num.Value != 0)
            {
                Entity = new PedidoRestaurante()
                {
                    Local = LocalPedidoRestaurante.Mesa,
                    Mesa = num.Value,
                    Controle = controle
                };
            }
            else
            {
                return false;
            }
            return true;
        }

        private ControlePedido NovoControle()
        {
            var ctr = new ControlePedido()
            {
                Controle = Settings.Default.NumeroControle,
                Chave = new Criptografia.CriptHash().GetHash(DateTime.Now.ToString("ddMMyyyy") + Settings.Default.NumeroControle)
            };
            ControlePedidoRepository.Save(ctr);

            if (Settings.Default.NumeroControle + 1 > 500)
            {
                Settings.Default.NumeroControle = 1;
            }
            else
            {
                Settings.Default.NumeroControle += 1;
            }
            Settings.Default.Save();
            return ctr;
        }

        public bool NovoPedidoEntrega()
        {
            var controle = NovoControle();
            if (controle == null)
            {
                return false;
            }
            Entity = new PedidoRestaurante()
            {
                Local = LocalPedidoRestaurante.Entrega,
                Controle = controle
            };
            return true;
        }
        public bool NovoPedidoBalcao()
        {
            var controle = NovoControle();
            if (controle == null)
            {
                return false;
            }
            Entity = new PedidoRestaurante()
            {
                Local = LocalPedidoRestaurante.Balcao,
                Controle = NovoControle()
            };
            return true;
        }


        public bool ConfirmarPedido()
        {
            ((PedidoRestaurante)Entity).Confirmado = true;
            return true;
        }
        public bool FecharPedido()
        {
            if (Produtos.IsEmpty())
            {
                System.Windows.Forms.MessageBox.Show("Informe ao menos um produto para fechar o pedido");
                return false;
            }

            var pagamento = new PagamentoPedidoRestauranteView(this);
            if (pagamento.DataContext == null)
            {
                pagamento.DataContext = this;
            }
            Mapper.CreateMap(GetType(), GetType());
            Mapper.Map(this, pagamento.DataContext);
            CalculaPedido();
            IniciarPagamento();
            pagamento.ShowDialog();

            if (!IsPagamentoCancelado && IsPagamentoEfetuado)
            {
                Mapper.CreateMap<PedidoRestauranteModel, PedidoRestaurante>();
                Mapper.Map(this, Entity);
                if (Entity.Cliente == null)
                {
                    Entity.Cliente = PessoaRepository.GetById(1);
                }
                if (String.IsNullOrEmpty(Entity.Observacoes))
                {
                    Entity.Observacoes = "";
                }
                Entity.Caixa = Settings.Default.Caixa;
                Entity.Usuario = App.Usuario;
                Entity.Empresa = App.Proprietaria;
                CupomFiscal.FecharPedidoRestaurante((PedidoRestaurante)Entity);
                
                Entity = null;
                OnPedidoFinalizado(this, EventArgs.Empty);
            }
            else
            {
                return false;
            }
            return true;
        }

        public override Pedido Entity
        {
            get { return base.Entity; }
            set
            {
                base.Entity = value;
                OnPropertyChanged("EntityRestaurante");
            }
        }

        public ComposicaoProduto GerarComposicao(Produto prod, decimal quantidade)
        {
            return ComposicaoProdutoRepository.CreateComposicaoProduto(prod, quantidade);

        }

        public ComposicaoProduto GetProduto(int produto)
        {
            foreach (var composicaoProduto in Produtos)
            {
                if (composicaoProduto.Sequencia == produto)
                {
                    return composicaoProduto;
                }
            }
            return null;
        }

        public void AddProduto(ComposicaoProduto composicao)
        {
            Produtos.Add(composicao);
            CalculaPedido();
        }

        public override void CalculaPedido()
        {
            var ret = RestauranteModel.Service.CalcularPedido(EntityRestaurante);
            Mapper.CreateMap(typeof(PedidoRestaurante), typeof(PedidoRestaurante));
            Mapper.Map(EntityRestaurante, ret);
            TotalProduto = ret.ValorPedido;
            TotalPedido = ret.ValorPedido - Desconto + Frete + Acressimo;
            OnPropertyChanged("Entity");
            OnPropertyChanged("EntityRestaurante");
            OnPropertyChanged("Produtos");
        }



        public void RemoveProduto(ComposicaoProduto composicao)
        {

            var result = CustomMessageBox.MensagemConfirmacao("Deseja realmente excluir este item");
            if (result == MessageBoxResult.Yes)
            {
                if (composicao != null)
                {
                    if (EntityRestaurante.Confirmado)
                    {
                        var ret = Service.CancelarItemMesa(EntityRestaurante.Mesa, composicao);
                        if (ret == StatusComando.ConcluidoSucesso)
                        {
                            Produtos.Remove(composicao);
                        }
                        else
                        {
                            CustomMessageBox.MensagemErro(Service.GetLastException());
                        }
                    }
                    else
                    {
                        Produtos.Remove(composicao);
                    }
                }
            }
            ProdutoAtual = null;
            CalculaPedido();

        }

        public void AddProdutoComposicao(Produto prod)
        {
            var prodPedido = new ProdutoPedido()
            {
                Produto = prod
            };
            if (EntityRestaurante.Confirmado)
            {
                var ret = Service.AdicionarItemComposicaoMesa(EntityRestaurante.Mesa, ProdutoAtual.IdGuid, prodPedido);
                if (ret == StatusComando.ConcluidoSucesso)
                {
                    ProdutoAtual.Composicao.Add(prodPedido);
                }
                else
                {
                    CustomMessageBox.MensagemErro(Service.GetLastException());
                }
            }
            else
            {
                ProdutoAtual.Composicao.Add(prodPedido);
            }

            VerificaProdutoComposicao();
            CalculaPedido();
        }

        public void RemoveProdutoComposicao()
        {
            if (ProdutoComposicaoAtual != null)
            {
                var prodComposicao = ProdutoAtual.Composicao
                                .FirstOrDefault(x => x.IdGuid == ProdutoComposicaoAtual.IdGuid);
                if (CustomMessageBox.MensagemConfirmacao("Deseja realmente excluir o produto.") == MessageBoxResult.Yes)
                {
                    if (EntityRestaurante.Confirmado)
                    {
                        if (Service.CancelarItemComposicaoMesa(EntityRestaurante.Mesa, ProdutoAtual.IdGuid,
                            ProdutoComposicaoAtual.IdGuid) == StatusComando.ConcluidoSucesso)
                        {
                            
                            if (prodComposicao != null)
                            {
                                ProdutoAtual.Composicao.Remove(prodComposicao);
                            }
                        }
                        else
                        {
                            CustomMessageBox.MensagemErro(Service.GetLastException());
                        }
                    }
                    else
                    {
                        ProdutoAtual.Composicao.Remove(prodComposicao);
                    }
                }
                ProdutoComposicaoAtual = null;
                VerificaProdutoComposicao();
            }
        }
        private void VerificaProdutoComposicao()
        {
            var ret = RestauranteModel.Service.VerificaComposicao(ProdutoAtual);
            Mapper.CreateMap(typeof(ComposicaoProduto), typeof(ComposicaoProduto));
            Mapper.Map(ProdutoAtual, ret);
            CalculaPedido();
        }
    }
}
