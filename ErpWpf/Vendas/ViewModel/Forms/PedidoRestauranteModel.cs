using System;
using System.Collections.ObjectModel;
using System.Windows;
using AutoMapper;
using Erp.Business;
using Erp.Business.Entity.Contabil.Pessoa;
using Erp.Business.Entity.Estoque.Produto;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using Erp.Business.Entity.Vendas.Pedido.Restaurante;
using Erp.Business.Entity.Vendas.Pedido.Restaurante.ClassesRelacionadas;
using Erp.Business.Enum;
using FluentNHibernate.Conventions;
using Util.Seguranca;
using Vendas.Component.View.Telas;
using Vendas.Properties;
using MessageBox = System.Windows.MessageBox;

namespace Vendas.ViewModel.Forms
{

    public class PedidoRestauranteModel : PedidoModel
    {
        public PedidoRestauranteModel()
        {
            Entity = new PedidoRestaurante();
            
        }

        #region Propriedades



        private ObservableCollection<ComposicaoProduto> _produtos;


        private ComposicaoProduto _produtoAtual;


        private ProdutoPedido _produtoComposicaoAtual;


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
                            IniciarPagamento();
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
            var pagamento = new PagamentoPedidoView(this);
            pagamento.ShowDialog();
            if (!pagamento.CancelarPagamento && IsPagamentoEfetuado)
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
                NHibernateHttpModule.Session.Flush();
                PedidoRestauranteRepository.Save((PedidoRestaurante)Entity);

            }
            else
            {
                return false;
            }
            return true;
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

        protected override void CalculaPedido()
        {
            decimal total = 0;

            int cont = 1;
            foreach (var composicaoProduto in _produtos)
            {
                composicaoProduto.Sequencia = cont;
                composicaoProduto.Valor = composicaoProduto.Quantidade * composicaoProduto.ValorUnitario;
                total += composicaoProduto.Valor;
                cont += 1;
            }
            Entity.ValorPedido = total;
            TotalProduto = total;
            TotalPedido = total - Desconto + Frete + Acressimo;
            AjustarSequencia();
        }

        private void AjustarSequencia()
        {
            for (int i = 0; i < Produtos.Count; i++)
            {
                Produtos[i].Sequencia = i + 1;
            }
            OnPropertyChanged("Produtos");
        }

        public void RemoveProduto(ComposicaoProduto composicao)
        {
            var result = MessageBox.Show("Deseja realmente excluir este item", "Excluir produto", MessageBoxButton.YesNo,
                MessageBoxImage.Asterisk, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                if (composicao != null)
                {
                    Produtos.Remove(composicao);
                }
            }
            ProdutoAtual = null;
            CalculaPedido();

        }

        public void AddProdutoComposicao(Produto prod)
        {

            ProdutoAtual.Composicao.Add(new ProdutoPedido()
            {
                Produto = prod
            });
            VerificaProdutoComposicao();
        }

        private void VerificaProdutoComposicao()
        {
            var prod = new Produto();
            foreach (var composicao in ProdutoAtual.Composicao)
            {
                if (composicao.Produto.PrecoVenda > prod.PrecoVenda)
                {
                    prod = composicao.Produto;
                    composicao.Quantidade = ProdutoAtual.Quantidade / ProdutoAtual.Composicao.Count;
                }
            }
            ProdutoAtual.Produto = prod;
            ProdutoAtual.Valor = ProdutoAtual.Quantidade * prod.PrecoVenda;
            ProdutoAtual.ValorUnitario = prod.PrecoVenda;
        }
    }
}
