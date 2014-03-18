using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DevExpress.Xpf.Ribbon.Customization;
using Erp.Business.Entity.Estoque.Produto;
using FluentNHibernate.Conventions;
using Vendas.ViewModel.Grids;

namespace Vendas.Component.View.Telas
{
    /// <summary>
    /// Interaction logic for ProdutosEncontradosView.xaml
    /// </summary>
    public partial class ProdutosEncontradosView : Window
    {
        public bool Cancelado { get; set; }
        private ProdutoEncontradoModel Model { get; set; }
        public ProdutosEncontradosView(IEnumerable<Produto> prods )
        {
            InitializeComponent();
            Model = new ProdutoEncontradoModel();
            Model.Collection.AddRange(prods);
            Model.Adicionar += Model_Adicionar;
            Model.Cancelar += Model_Cancelar;
            PreviewKeyDown += ProdutosEncontradosView_PreviewKeyDown;
            if (!prods.IsEmpty())
            {
                Model.CurrentItem = prods.ToList()[0];
                if (prods.Count() > 1)
                {
                    GridProdutosEncontrados.Focus();
                    ShowDialog();
                    
                }
            }
            
        }

        void ProdutosEncontradosView_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Cancelar();
                
            }
            if (e.Key == Key.Enter)
            {
                Adicionar();
            }
        }

        private void Cancelar()
        {
            Model.CurrentItem = null;
            Cancelado = true;
            Hide();
        }

        void Model_Cancelar(object sender, System.EventArgs e)
        {
            Cancelar();
        }

        void Model_Adicionar(object sender, System.EventArgs e)
        {
            Adicionar();
        }

        private void Adicionar()
        {
            Cancelado = false;
            Hide();
        }

        public Produto ProdutoSelecionado
        {
            get { return Model.CurrentItem; }
        }

        private void ProdutosEncontradosView_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataContext = Model;
        }

        private void ProdutosEncontradosView_OnKeyDown(object sender, KeyEventArgs e)
        {
        
        }
    }
}
