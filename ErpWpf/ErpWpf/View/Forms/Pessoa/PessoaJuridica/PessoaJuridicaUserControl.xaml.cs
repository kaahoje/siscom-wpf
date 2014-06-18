using System.Windows;
using System.Windows.Controls;

namespace Erp.View.Forms.Pessoa.PessoaJuridica
{
    /// <summary>
    /// Interaction logic for PessoaJuridicaUserControl.xaml
    /// </summary>
    public partial class PessoaJuridicaUserControl
    {
        public PessoaJuridicaUserControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
        }
    }
}
