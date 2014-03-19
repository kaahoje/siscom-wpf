using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using DevExpress.Xpf.Grid;
using Vendas.ViewModel.Forms;
using Vendas.ViewModel.Grids;

namespace Vendas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RestauranteWindow
    {
        private RestauranteModel Model
        {
            get { return (RestauranteModel) DataContext; }
        }

        public RestauranteWindow()
        {
            InitializeComponent();
            GridMesas.SelectedItemChanged += GridMesasOnSelectedItemChanged;
            //Model = new RestauranteModel();
            Model.PropertyChanged += Model_PropertyChanged;
            Model.AcaoConcluida += Model_AcaoConcluida;
            
        }

        void Model_AcaoConcluida(object sender, EventArgs e)
        {
            //PedidoUserControl.Visibility = Model.TelaPedidoVisible;
        }

        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CurrentItem")
            {
                PedidoUserControl.Visibility = Model.CurrentItem == null
                    ? Visibility.Hidden
                    : Visibility.Visible;
                PedidoUserControl.DataContext = Model.CurrentItem;
            }
            
        }

        private void GridMesasOnSelectedItemChanged(object sender, SelectedItemChangedEventArgs selectedItemChangedEventArgs)
        {
            Model.CurrentItem = (PedidoRestauranteModel) selectedItemChangedEventArgs.NewItem;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //EcfHelper.FabricanteEcf = Settings.Default.FabricanteEcf;
            //DataContext = Model;
            //var dia = EcfHelper.Ecf.DataMovimento();
            //var proprietaria = PessoaJuridicaRepository.GetById(Settings.Default.IdEmpresa);
            //var lancado = LancamentoInicialRepository.DiaLancado(Settings.Default.Caixa, dia, proprietaria) != null;

            //if (dia.Ticks == DateTime.MinValue.Ticks || lancado)
            //{
            //    new LancamentoInicialView().ShowDialog();

            //}
            
            // Load data by setting the CollectionViewSource.Source property:
            // restauranteModelViewSource.Source = [generic data source]
        }


        private void RestauranteWindow_OnClosed(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}
