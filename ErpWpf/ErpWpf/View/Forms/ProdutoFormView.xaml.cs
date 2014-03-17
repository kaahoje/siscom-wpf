using System.Windows;
using Erp.Model.Forms;

namespace Erp.View.Forms
{
    /// <summary>
    /// Interaction logic for ProdutoFormView.xaml
    /// </summary>
    public partial class ProdutoFormView 
    {
        private FormDefaultActions FormDefaultActions { get; set; }
        public ProdutoFormView()
        {
            InitializeComponent();
            
            RestCommands.DataContext = DataContext;
            FormDefaultActions = new FormDefaultActions(this);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            // Load data by setting the CollectionViewSource.Source property:
            // produtoViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource ipptDictionaryViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("ipptDictionaryViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // ipptDictionaryViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource origemProdutoDictionaryViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("origemProdutoDictionaryViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // origemProdutoDictionaryViewSource.Source = [generic data source]
        }
    }
}
