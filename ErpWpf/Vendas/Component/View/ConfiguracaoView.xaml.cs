using System.Windows;
using Vendas.Properties;
using Vendas.ViewModel;

namespace Vendas.Component.View
{
    /// <summary>
    /// Interaction logic for ConfiguracaoView.xaml
    /// </summary>
    public partial class ConfiguracaoView 
    {
        public ConfiguracaoView()
        {
            InitializeComponent();
            DataContext = new ConfiguracaoModel();
        }

        private void DXWindow_Loaded(object sender, RoutedEventArgs e)
        {



            System.Windows.Data.CollectionViewSource tipoPdvDictionaryViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tipoPdvDictionaryViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // tipoPdvDictionaryViewSource.Source = [generic data source]
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Salvar_Click(object sender, RoutedEventArgs e)
        {
            ((Settings) DataContext).Save();
            Close();
        }
    }
}
