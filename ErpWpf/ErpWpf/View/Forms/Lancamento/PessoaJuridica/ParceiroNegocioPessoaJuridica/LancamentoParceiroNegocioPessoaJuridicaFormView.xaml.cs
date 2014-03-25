using System.Windows;

namespace Erp.View.Forms.Lancamento.PessoaJuridica.ParceiroNegocioPessoaJuridica
{
    /// <summary>
    /// Interaction logic for LancamentoParceiroNegocioPessoaJuridicaFormView.xaml
    /// </summary>
    public partial class LancamentoParceiroNegocioPessoaJuridicaFormView : Window
    {
        public LancamentoParceiroNegocioPessoaJuridicaFormView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource parceiroNegocioPessoaJuridicaLargeDataModelViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("parceiroNegocioPessoaJuridicaLargeDataModelViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // parceiroNegocioPessoaJuridicaLargeDataModelViewSource.Source = [generic data source]
        }
    }
}
