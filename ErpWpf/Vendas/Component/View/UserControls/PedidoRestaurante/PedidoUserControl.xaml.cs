using System;
using System.Windows;
using System.Windows.Input;
using AutoMapper;
using Erp.Business.Entity.Estoque.Produto;
using Erp.Business.Entity.Vendas.Pedido.Restaurante.ClassesRelacionadas;
using Vendas.Component.View.Telas;
using Vendas.ViewModel.Forms;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Vendas.Component.View.UserControls.PedidoRestaurante
{
    /// <summary>
    /// Interaction logic for Pedido.xaml
    /// </summary>
    public partial class PedidoUserControl
    {
        private PedidoRestauranteModel Model
        {
            get { return (PedidoRestauranteModel)DataContext; }
        }

        public PedidoUserControl()
        {
            InitializeComponent();
            DataContext = new PedidoRestauranteModel();
            LimparProduto();

        }

        public void FocoEmProduto()
        {
            if (TxtProduto != null)
            {
                TxtProduto.Focus();
            }
            
        }

        public void FocoEmValores()
        {
           if(TxtAcressimo != null) TxtAcressimo.Focus();
        }
        private void TxtProdutoOnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.Key == Key.Enter)
            {
                if (Model.QuantidadeAtual <= 0)
                {
                    MessageBox.Show("A quantidade não pode ser igual ou inferior a 0");
                    TxtQuantidade.Focus();
                    return;

                }
                if (!String.IsNullOrEmpty(TxtProduto.Text))
                {

                    var telaProds = new ProdutosEncontradosView(ProdutoRepository.GetByRange(TxtProduto.Text));
                    var prod = telaProds.ProdutoSelecionado;
                    if (prod != null)
                    {
                        var comp = Model.GerarComposicao(prod, Model.QuantidadeAtual);
                        if (Model.ProdutoAtual == null)
                        {

                            Model.AddProduto(Model.GerarComposicao(prod, Model.QuantidadeAtual));

                        }
                        else
                        {
                            var prodAntigo = Model.GetProduto(Model.ProdutoAtual.Sequencia);
                            if (prodAntigo != null)
                            {

                                Mapper.CreateMap(typeof(ComposicaoProduto), typeof(ComposicaoProduto));
                                Mapper.Map(comp, prodAntigo);
                            }
                            else
                            {
                                MessageBox.Show("Produto não encontrado para alteração");
                            }

                        }
                        LimparProduto();
                    }
                    else
                    {
                        if (!telaProds.Cancelado)
                        {
                            MessageBox.Show("Produto não encontrado");
                        }
                        LimparProduto();
                    }
                }
                else
                {
                    TxtQuantidade.Focus();
                }
            }
        }

        private void LimparProduto()
        {
            Model.ProdutoAtual = null;
            Model.QuantidadeAtual = 1;
            TxtProduto.Text = "";
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
        }

        private void TxtQuantidade_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TxtProduto.Focus();
            }
        }

        private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                Model.RemoveProduto((ComposicaoProduto)GridProdutos.SelectedItem);
            }
        }

        private void TxtProudtoComposicao_OnKeyDown(object sender, KeyEventArgs e)
        {
            var prod = new ProdutosEncontradosView(ProdutoRepository.GetByRange(TxtProudtoComposicao.Text)).ProdutoSelecionado;
            if (prod != null)
            {
                Model.AddProdutoComposicao(prod);
            }
        }

        private void PedidoUserControl_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (DataContext == null)
            {
                Visibility = Visibility.Hidden;
            }
            else
            {
                Visibility = Visibility.Visible;
                FocoEmProduto();
            }
        }

        private void PedidoUserControl_OnKeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void TxtAcressimo_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TxtDesconto.Focus();
            }
        }

        private void TxtDesconto_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TxtFrete.Focus();
            }
        }

        private void TxtFrete_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                FocoEmProduto();
            }
        }
    }
}
